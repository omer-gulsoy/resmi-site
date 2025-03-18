using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DemoFormController : Controller
    {
        Context Context=new Context();
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Demos=Context.DemoBasvurus.ToList();
            return View();
        }
		public IActionResult DemoDelete(int id)
        {
            var silinecek =Context.DemoBasvurus.Find(id);
            Context.SaveChanges();
            return RedirectToAction("Index","DemoForm");
        }

	}
}
