using data.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactFormController : Controller
    {
        Context Context=new Context();
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Contacts=Context.ContactForms.ToList();
            return View();
        }
        public IActionResult ContactDelete(int id) 
        {
            var silinecek = Context.ContactForms.Find(id);
            Context.ContactForms.Remove(silinecek);
            Context.SaveChanges();
            return RedirectToAction("Index","ContactForm");
        }
    }
}