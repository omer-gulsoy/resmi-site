using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModulsEditController : Controller
	{
		Context Context = new Context();

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Products = Context.Products.ToList();
			var degerler = Context.Moduls.ToList();
			return View(degerler);
		}

		[HttpPost]
		public IActionResult ModulAdd(Modul e)
		{
			if (e != null)
			{
				Context.Moduls.Add(e);
				Context.SaveChanges();
				return RedirectToAction("Index", "ModulsEdit");
			}
			return BadRequest("Servis eklenirken hata oluştu!");
		}

		[HttpPost]
		public IActionResult ModulDelete(int id)
		{
			var silinecek = Context.Moduls.Find(id);
			if (silinecek != null)
			{
				Context.Moduls.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult ModulGet(int id)
		{
			var getirilecek = Context.Moduls.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(new
			{
				Modul_Id = getirilecek.Modul_Id,
				Title = getirilecek.Title,
				ShortText = getirilecek.ShortText,
				Text = getirilecek.Text,
				PhotoURL = getirilecek.PhotoURL,
				Product_Id = getirilecek.Product_Id,
			});
		}

		[HttpPost]
		public IActionResult ModulUpdate([FromBody] Modul c)
		{
			var guncellenecek = Context.Moduls.Find(c.Modul_Id);
			if (guncellenecek != null)
			{
				guncellenecek.Title = c.Title;
				guncellenecek.ShortText = c.ShortText;
				guncellenecek.Text = c.Text;
				guncellenecek.PhotoURL = c.PhotoURL;
				guncellenecek.Product_Id = c.Product_Id;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}
