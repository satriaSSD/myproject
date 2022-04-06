using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Authorization;
using MyProject.Controllers;

using QRCoder;

//chatapi
using ChatApi.Core.Connect.Interfaces;
using ChatApi.Core.Response.Interfaces;
using ChatApi.Instances;
using ChatApi.Instances.Models;
using ChatApi.Instances.Connect;
using ChatApi.Instances.Requests;
using ChatApi.Instances.Requests.Interfaces;
using ChatApi.Instances.Responses.Interfaces;

//chatapi wa
using ChatApi.WA.Account;
using ChatApi.Core.Connect;
using ChatApi.WA.Account.Responses.Interfaces;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using MyProject.Web.Models.QR;

namespace MyProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Contact)]
    public class ContactController : MyProjectControllerBase
    {
        //private readonly IWhatsAppConnect whatsAppConnect;
        internal static IWhatsAppConnect whatsAppConnect { get; set; }

        public async Task<IActionResult> IndexAsync()
        {
            //IChatApiInstanceConnect connect = new ChatApiInstanceConnect("3encfzWtU0gJe8YA3UO8xL7rZln2");
            //IChatApiInstanceOperations instanceOperations = new ChatApiInstanceOperations(connect);

            //IChatApiCreateInstanceRequest request = new ChatApiCreateInstanceRequest
            //{
            //    TypeInstance = ChatApiInstanceType.WhatsAppDev
            //};

            //IChatApiResponse<IChatApiCreateInstanceResponse?> chatApiResponse = instanceOperations.CreateChatApiInstance(request);
            //if (!chatApiResponse.IsSuccess) throw chatApiResponse.Exception!;

            //var response = chatApiResponse.GetResult();
            var respUrl = "https://api.chat-api.com/instance421819/"; //response.Result.InstanceParameters.ApiUrl;
            var respInstance = 421819; //response.Result.InstanceParameters.Instance;
            var respToken = "l81t3su8z95denro"; //response.Result.InstanceParameters.Token;
            //Console.WriteLine(response);

            //ApiUrl = https://api.chat-api.com/instance421819/
            //Instance = 421819
            //Token = l81t3su8z95denro

            //get whatsapp qr code
            whatsAppConnect = new WhatsAppConnect(respUrl, respInstance, respToken);
            IAccountOperation accountOperation = new AccountOperation(whatsAppConnect);

            IChatApiResponse<IQrCodeResponse?>? chatApiResponse2 = await accountOperation.GetQrCodeAsync().ConfigureAwait(true);
            if (!chatApiResponse2.IsSuccess) throw chatApiResponse2.Exception!;

            var response2 = chatApiResponse2.GetResult();

            //byte[] data = Convert.FromBase64String(response2.QrCodeImage);

            //QRCodeModel model = new QRCodeModel();
            //model.QRCodeText = response2.QrCodeImage;

            //string path = Server.MapPath("~/images/computer.png");
            //byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            //string imageBase64Data = Convert.ToBase64String(imageByteData);
            //string imageDataURL = string.Format("data:image/png;base64,{0}", response2.QrCodeImage);
            ViewBag.ImageData = response2.QrCodeImage; //imageDataURL;

            //byte[] img = Convert.FromBase64String(response2.QrCodeImage);

            //QRCodeGenerator QrGenerator = new QRCodeGenerator();
            //QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(response2.QrCodeImage, QRCodeGenerator.ECCLevel.Q);
            //QRCode QrCode = new QRCode(QrCodeInfo);
            //Bitmap QrBitmap = QrCode.GetGraphic(60);
            //byte[] BitmapArray = QrBitmap.BitmapToByteArray();
            //string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            //ViewBag.QrCodeUri = QrUri;

            return View();
        }

        //public static byte[] BitmapToByteArray(this Bitmap bitmap)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitmap.Save(ms, ImageFormat.Png);
        //        return ms.ToArray();
        //    }
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var permissions = (await _roleAppService.GetAllPermissions()).Items;
        //    var model = new RoleListViewModel
        //    {
        //        Permissions = permissions
        //    };

        //    return View(model);
        //}
    }
}
