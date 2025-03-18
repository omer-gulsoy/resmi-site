using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class DemoController : Controller
    {
        Context Context=new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DemoBasvuru d)
        {
            Context.DemoBasvurus.Add(d);
            Context.SaveChanges();
            return View("Thanks","Contact");
        }
    }
}
