using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ServicesEditController : Controller
	{
		Context Context = new Context();

		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Services.ToList();
			return View(degerler);
		}

		[HttpPost]
		public IActionResult ServiceAdd(Service e)
		{
			if (e != null)
			{
				Context.Services.Add(e);
				Context.SaveChanges();
				return RedirectToAction("Index", "ServicesEdit");
			}
			return BadRequest("Servis eklenirken hata oluştu!");
		}

		[HttpPost]
		public IActionResult ServiceDelete(int id)
		{
			var silinecek = Context.Services.Find(id);
			if (silinecek != null)
			{
				Context.Services.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult ServiceGet(int id)
		{
			var getirilecek = Context.Services.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(new
			{
				Service_Id = getirilecek.Service_Id,
				Title = getirilecek.Title,
				ShortText = getirilecek.ShortText,
				Text = getirilecek.Text,
				PhotoURL = getirilecek.PhotoURL
			});
		}

		[HttpPost]
		public IActionResult ServiceUpdate([FromBody] Service c)
		{
			var guncellenecek = Context.Services.Find(c.Service_Id);
			if (guncellenecek != null)
			{
				guncellenecek.Title = c.Title;
				guncellenecek.ShortText = c.ShortText;
				guncellenecek.Text = c.Text;
				guncellenecek.PhotoURL = c.PhotoURL;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}
	}
}
