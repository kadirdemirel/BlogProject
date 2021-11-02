using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Writer
{
 
   
    public class WriterAboutOnDashboard:ViewComponent
    {
        IWriterService _writerService;
        public WriterAboutOnDashboard(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var selectedItems = _writerService.GetWriterById(1);
            return View(selectedItems);
        }
    }
}
