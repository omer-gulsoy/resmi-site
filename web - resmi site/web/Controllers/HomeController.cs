using Microsoft.AspNetCore.Mvc;
using data.Concrate;
using entity.Concrate;

namespace web.Controllers
{
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.News.OrderByDescending(x => x.Date).Take(3).ToList();
			ViewBag.Title = "Anasayfa";
			return View(degerler);
		}
	}
}
