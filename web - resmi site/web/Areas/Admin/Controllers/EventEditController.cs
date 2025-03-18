using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventEditController : Controller
    {
        Context Context=new Context();
        [HttpGet]
        public IActionResult Index()
        {
            var degerler = Context.Events.ToList();
            return View(degerler);
        }
        [HttpPost]
        public IActionResult EventAdd(Event e)
        {
            Context.Events.Add(e);
            Context.SaveChanges();
            return RedirectToAction("Index","EventEdit");
		}
		[HttpPost]
		public IActionResult EventDelete(int id)
		{
			var silinecek = Context.Events.Find(id);
			if (silinecek != null)
			{
				Context.Events.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true }); // AJAX çağrısı başarılı olursa JSON dön
			}
			return Json(new { success = false });
		}
		public IActionResult EventGet(int id)
		{
			var getirilecek = Context.Events.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(getirilecek); // JSON formatında geri dön
		}

		[HttpPost]
		public IActionResult ClassUpdate([FromBody] Event c)
		{
			var guncellenecek = Context.Events.Find(c.Event_Id);
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
