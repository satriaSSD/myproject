using Abp.MultiTenancy;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace MyProject.Web.Models.Account
{
    public class LoginFormViewModel
    {
        public string ReturnUrl { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public bool IsSelfRegistrationAllowed { get; set; }

        public MultiTenancySides MultiTenancySide { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
