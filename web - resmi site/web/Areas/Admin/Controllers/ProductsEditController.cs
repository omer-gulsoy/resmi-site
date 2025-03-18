using data.Concrate;
using entity.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductsEditController : Controller
	{
		Context Context = new Context();

		[HttpGet]
		public IActionResult Index()
		{
			var degerler = Context.Products.ToList();
			return View(degerler);
		}

		[HttpPost]
		public IActionResult ProductAdd(Product e)
		{
			if (e != null)
			{
				Context.Products.Add(e);
				Context.SaveChanges();
				return RedirectToAction("Index", "ProductsEdit");
			}
			return BadRequest("Ürün eklenirken hata oluştu!");
		}

		[HttpPost]
		public IActionResult ProductDelete(int id)
		{
			var silinecek = Context.Products.Find(id);
			if (silinecek != null)
			{
				Context.Products.Remove(silinecek);
				Context.SaveChanges();
				return Json(new { success = true });
			}
			return Json(new { success = false });
		}

		[HttpGet]
		public IActionResult ProductGet(int id)
		{
			var getirilecek = Context.Products.Find(id);
			if (getirilecek == null)
			{
				return NotFound();
			}
			return Json(new
			{
				Product_Id = getirilecek.Product_Id,
				Title = getirilecek.Title,
				ShortText = getirilecek.ShortText,
				Text = getirilecek.Text,
				PhotoURL = getirilecek.PhotoURL
			});
		}

		[HttpPost]
		public IActionResult ProductUpdate([FromBody] Product c)
		{
			var guncellenecek = Context.Products.Find(c.Product_Id);
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
