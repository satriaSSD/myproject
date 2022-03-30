//using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
//using Microsoft.AspNetCore.Authentication;

namespace MyProject.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        //Login with Google
        //public string ReturnUrl { get; set; }
        //public IList<AuthenticationScheme> ExternaLogins { get; set; }
    }
}
