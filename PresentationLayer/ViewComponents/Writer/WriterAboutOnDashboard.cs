using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
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
            var userMail = User.Identity.Name;
            Context context = new Context();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var selectedItems = _writerService.GetWriterById(writerID);
            return View(selectedItems);
        }
    }
}
