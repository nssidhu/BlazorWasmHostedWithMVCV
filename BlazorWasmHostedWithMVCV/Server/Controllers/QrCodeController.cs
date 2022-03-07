using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace BlazorWasmHostedWithMVCV.Server.Controllers
{
    public class QrCodeController : Controller
    {
        public IActionResult Index(string tokenGuid)
        {
            //https://github.com/codebude/QRCoder/

            ViewBag.Message = "This message is from MVC QRCode Controller" + tokenGuid;
            ViewBag.QrCode = tokenGuid;

            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(tokenGuid, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytesCode(qrCodeImage));

            // return Content("This message is from MVC Controller from updated");
            //return View();
            //  return View("ViewName", model)
            //return RedirectToAction("Index");
            //return PartialView("PartialViewName", Model);
            //return View("~/Views/FolderName/ViewName.aspx");
        }

        [NonAction]
        private static byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


    }
}
