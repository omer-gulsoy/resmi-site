using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Home")]
	public class HomeController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Haberler = Context.News
	.OrderByDescending(n => n.Date)
	.Take(6)
	.ToList();
			ViewBag.Duyurular = Context.Notices
	.OrderByDescending(n => n.Notice_Id)
	.Take(6)
	.ToList();
			ViewBag.Etkinlikler = Context.Events
	.OrderByDescending(n => n.Event_Id)
	.Take(6)
	.ToList();
			ViewBag.Form = Context.ContactForms
	.OrderByDescending(n => n.ContactForm_Id)
	.Take(5)
	.ToList();
			ViewBag.Demo = Context.DemoBasvurus
	.OrderByDescending(n => n.DemoBasvuru_Id)
	.Take(5)
	.ToList();
			return View();
		}
	}
}
