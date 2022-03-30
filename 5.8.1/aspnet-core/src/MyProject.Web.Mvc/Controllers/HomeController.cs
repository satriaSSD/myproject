using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyProject.Controllers;
//using Google.Apis.Auth.AspNetCore3;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;


namespace MyProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        //[GoogleScopedAuthorize(DriveService.ScopeConstants.DriveReadonly)]
        //public async Task<IActionResult> DriveFileList([FromServices] IGoogleAuthProvider auth)
        //{
        //    GoogleCredential cred = await auth.GetCredentialAsync();
        //    var service = new DriveService(new BaseClientService.Initializer
        //    {
        //        HttpClientInitializer = cred
        //    });
        //    var files = await service.Files.List().ExecuteAsync();
        //    var fileNames = files.Files.Select(x => x.Name).ToList();
        //    return View(fileNames);
        //}

    }
}
