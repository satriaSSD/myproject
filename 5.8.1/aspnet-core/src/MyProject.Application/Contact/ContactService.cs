using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using MyProject.Authorization;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Contact.Dto;

namespace MyProject.Contact
{
    [AbpAuthorize(PermissionNames.Pages_Contact)]
    public class ContactService : IContactService
    {
        public Task<ListResultDto<GmailDto>> GetAllPermissions()
        {
            throw new System.NotImplementedException();
        }
    }
}
