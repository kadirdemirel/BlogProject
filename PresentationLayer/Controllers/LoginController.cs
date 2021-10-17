using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer writer)
        {
            Context context = new Context();
            var data = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.Password == writer.Password);
            if (data != null)
            {
                HttpContext.Session.SetString("username", writer.WriterMail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        
        }
    }
}
