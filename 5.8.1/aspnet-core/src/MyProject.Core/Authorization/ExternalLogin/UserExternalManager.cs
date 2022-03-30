using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using MyProject.MultiTenancy;
using MyProject.Authorization.Users;
using Abp.Domain.Repositories;

namespace MyProject.Authorization.ExternalLogin
{
    public class UserExternalManager : DomainService
    {
        public IAbpSession AbpSession { get; set; }

        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly IRepository<UserExternalLogin> _repository;


        public UserExternalManager(
            TenantManager tenantManager,
            UserManager userManager,
            IRepository<UserExternalLogin> repository)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _repository = repository;

            AbpSession = NullAbpSession.Instance;
        }

        public async Task<UserExternalLogin> RegisterUserExternalAsync(string loginProvider, string tokenKey, int userId)
        {
            CheckForTenant();

            var tenant = await GetActiveTenantAsync();
            //var user = await GetActiveUserAsync();

            var usr = new UserExternalLogin
            {
                LoginProvider = loginProvider,
                TokenKey = tokenKey,
                TenantId = tenant.Id,
                UserId = userId
            };

            await _repository.InsertAsync(usr);
            await CurrentUnitOfWork.SaveChangesAsync();

            return usr;
        }

        private void CheckForTenant()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("Can not register host users!");
            }
        }

        private async Task<Tenant> GetActiveTenantAsync()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return await GetActiveTenantAsync(AbpSession.TenantId.Value);
        }

        private async Task<User> GetActiveUserAsync()
        {
            if (!AbpSession.UserId.HasValue)
            {
                return null;
            }

            return await GetActiveUserAsync(AbpSession.UserId.ToString());
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            var tenant = await _tenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }

        private async Task<User> GetActiveUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", userId));
            }

            if (!user.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", userId));
            }

            return user;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
