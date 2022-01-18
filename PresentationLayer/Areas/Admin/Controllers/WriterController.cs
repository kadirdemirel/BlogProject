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

        public IActionResult GetWriterById(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterModel writerModel)
        {
            writers.Add(writerModel);
            var jsonWriters = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterModel writerModel)
        {
            var writer = writers.FirstOrDefault(x => x.Id == writerModel.Id);
            writer.Name = writerModel.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriter);


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
