using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Yazılım",
                categorycount = 8
            });
            categoryModels.Add(new CategoryModel
            {
                categoryname = "Spor",
                categorycount = 9
            });
            return Json(new { jsonlist = categoryModels });
        }
    }
}
