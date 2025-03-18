using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsEditController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.News.ToList();
			return View(degerler);
		}
		[HttpPost]
		public IActionResult NewsAdd(News e)
		{
			Context.News.Add(e);
			Context.SaveChanges();
			return RedirectToAction("Index", "NewsEdit");
		}
		[HttpPost]
		public IActionResult NewsDelete(int id)
		{
			var silinecek = Context.News.Find(id);
			if (silinecek != null)
			{
				Context.News.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true }); // AJAX çağrısı başarılı olursa JSON dön
			}
			return Json(new { success = false });
		}
		public IActionResult NewsGet(int id)
		{
			var getirilecek = Context.News.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(getirilecek); // JSON formatında geri dön
		}

		[HttpPost]
		public IActionResult NewsUpdate([FromBody] News c)
		{
			var guncellenecek = Context.News.Find(c.News_Id);
			if (guncellenecek != null)
			{
				guncellenecek.Title = c.Title;
				guncellenecek.Date = c.Date;
				guncellenecek.PreDescription = c.PreDescription;
				guncellenecek.Content = c.Content;
				guncellenecek.PhotoURL = c.PhotoURL;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

	}
}
