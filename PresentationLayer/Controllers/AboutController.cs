using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{


    public class AboutController : Controller
    {
        IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            var socialMedia = _aboutService.GetAll();
            return View(socialMedia);
        }
        public PartialViewResult SocialMedia()
        {
            
            return PartialView();
        }
    }
}
