using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
	public class ProductAndServiceController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Services()
		{
			var degerler = Context.Services.OrderBy(n => n.Title).ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult ServiceDetails(int id)
		{
			ViewBag.Servisler = Context.Services.ToList();
			var degerler = Context.Services.Find(id);
			return View(degerler);
		}
		[HttpGet]
		public IActionResult Moduls()
		{
			var degerler = Context.Moduls.OrderBy(n => n.Title).ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult ModulDetails(int id)
		{
			ViewBag.Urunler = Context.Products.ToList();
			ViewBag.Moduller = Context.Moduls.ToList();
			var degerler = Context.Moduls.Find(id);
			return View(degerler);
		}
		[HttpGet]
		public IActionResult Products()
		{
			var degerler = Context.Products.OrderBy(n => n.Title).ToList();
			return View(degerler);
		}
		[HttpGet]
		public IActionResult ProductDetails(int id)
		{
			ViewBag.Urunler = Context.Products.ToList();
			ViewBag.Moduller = Context.Moduls.ToList();
			var degerler = Context.Products.Find(id);
			return View(degerler);
		}
	}
}
