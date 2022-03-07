using Microsoft.AspNetCore.Mvc;

namespace BlazorWasmHostedWithMVCV.Server.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "This message is from MVC Controller";
            // return Content("This message is from MVC Controller from updated");
            return View();
            //  return View("ViewName", model)
            //return RedirectToAction("Index");
            //return PartialView("PartialViewName", Model);
            //return View("~/Views/FolderName/ViewName.aspx");
        }
    }
}
