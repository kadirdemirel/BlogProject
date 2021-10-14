using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page404(int code)
        {
            return View();
        }
    }
}
