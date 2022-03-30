using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyProject.Contact
{
    [Table("Contacts")]
    public class Contacts : Entity
    {
        public const int StringLength = 128;

        [StringLength(StringLength)]
        public string UserEmail { get; set; }

        [StringLength(StringLength)]
        public string Contact { get; set; }

        [StringLength(StringLength)]
        public string OtherContacts { get; set; }

        public int TenantId { get; set; }
        public int UserId { get; set; } 
    }
}
