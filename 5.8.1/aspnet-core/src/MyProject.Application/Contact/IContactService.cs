using Abp.Application.Services.Dto;
using MyProject.Contact.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contact
{
    public interface IContactService
    {
        Task<ListResultDto<GmailDto>> GetAllPermissions();
    }
}
