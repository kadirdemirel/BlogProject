using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationLayer.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id=1,
                Name="Ayşe"
            },
             new WriterModel
            {
                Id=2,
                Name="Ahmet"
            },
              new WriterModel
            {
                Id=3,
                Name="Buse"
            },
        };
    }
}
