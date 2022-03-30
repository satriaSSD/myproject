using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Authorization;
using MyProject.Controllers;

namespace MyProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Contact)]
    public class ContactController : MyProjectControllerBase
    {
        public ActionResult Index() => View();
    }
}
