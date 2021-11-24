using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
