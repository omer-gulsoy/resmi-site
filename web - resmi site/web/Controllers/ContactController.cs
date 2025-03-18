using Microsoft.AspNetCore.Mvc;
using data.Concrate;
using entity.Concrate;

namespace web.Controllers
{
	public class ContactController : Controller
	{
		Context Context = new Context();
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Phone = Context.Contacts.Where(x => x.ContactType_Id == 1).ToList();
			ViewBag.Email = Context.Contacts.Where(x => x.ContactType_Id == 2).ToList();
			ViewBag.Adress = Context.Contacts.Where(x => x.ContactType_Id == 3).ToList();
			ViewBag.AdressLink = Context.Contacts.Where(x => x.ContactType_Id == 4).ToList();
			return View();
		}
		[HttpPost]
		public IActionResult Index(ContactForm c) 
		{
			Context.ContactForms.Add(c);
			Context.SaveChanges();
			return RedirectToAction("Thanks","Contact");
		}
		[HttpGet]
		public IActionResult Thanks()
		{
			return View();
		}
	}
}