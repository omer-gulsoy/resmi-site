using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class NoticeEditController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Notices.ToList();
			return View(degerler);
		}
		[HttpPost]
		public IActionResult NoticeAdd(Notice e)
		{
			Context.Notices.Add(e);
			Context.SaveChanges();
			return RedirectToAction("Index", "NoticeEdit");
		}
		[HttpPost]
		public IActionResult NoticeDelete(int id)
		{
			var silinecek = Context.Notices.Find(id);
			if (silinecek != null)
			{
				Context.Notices.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true }); // AJAX çağrısı başarılı olursa JSON dön
			}
			return Json(new { success = false });
		}
		public IActionResult NoticeGet(int id)
		{
			var getirilecek = Context.Notices.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(getirilecek); // JSON formatında geri dön
		}

		[HttpPost]
		public IActionResult NoticeUpdate([FromBody] Notice c)
		{
			var guncellenecek = Context.Notices.Find(c.Notice_Id);
			if (guncellenecek != null)
			{
				guncellenecek.Title = c.Title;
				guncellenecek.ShortText = c.ShortText;
				guncellenecek.Text = c.Text;
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

	}
}
