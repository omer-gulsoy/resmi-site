using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class CompanyController : Controller
	{
		Context Context = new Context();
		public IActionResult AboutUs()
		{
			var degerler = Context.Services.Take(6).ToList();
			return View(degerler);
		}
		public IActionResult Message()
		{
			return View();
		}
		public IActionResult VisionAndMission()
		{
			var degerler=Context.Services.Take(6).ToList();
			return View(degerler);
		}
		public IActionResult QualityPolicy()
		{
			return View();
		}
		public IActionResult ApplyJob()
		{
			return View();
		}
		public IActionResult JobList()
		{
			return View();
		}
		public IActionResult ApplyIntern()
		{
			return View();
		}
		[HttpGet]
		public IActionResult NewsDetail(int id)
		{
			ViewBag.Oneri = Context.News
				.OrderByDescending(n => n.Date)
				.Take(2)
				.ToList();
			var degerler = Context.News.Find(id);
			return View("NewsDetail", degerler);
		}
		[HttpGet]
		public IActionResult News()
		{
			ViewBag.Haber = Context.News.ToList();
			return View();
		}
		[HttpPost]
		public IActionResult News(MailRegister m)
		{
			Context.MailRegisters.Add(m);
			Context.SaveChanges();
			return View();
		}
		public IActionResult Notices()
		{
			var degerler=Context.Notices
				.OrderByDescending(n => n.Notice_Id)
				.ToList();
			return View(degerler);
		}
		public IActionResult Events()
		{
			var degerler=Context.Events
				.OrderByDescending(n => n.Event_Id)
				.ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult _FooterPartial()
		{
			var lastTwoNews = Context.News
				.OrderByDescending(n => n.Date)
				.Take(2)
				.ToList();
			return PartialView(lastTwoNews);
		}
		[HttpGet]
		public IActionResult QualityDocs()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SecuritySystem()
		{
			return View();
		}
	}
}
