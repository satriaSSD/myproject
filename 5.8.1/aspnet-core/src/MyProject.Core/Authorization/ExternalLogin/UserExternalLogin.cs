using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProject.Authorization.ExternalLogin
{
    [Table("UserExternalLogin")]
    public class UserExternalLogin : Entity
    {
        public const int StringLength = 128;
        public const int TokenStringLength = 256;

        [StringLength(StringLength)]
        public string LoginProvider { get; set; }

        [StringLength(TokenStringLength)]
        public string TokenKey { get; set; }

        public int TenantId { get; set; }
        public int UserId { get; set; }
    }
}
