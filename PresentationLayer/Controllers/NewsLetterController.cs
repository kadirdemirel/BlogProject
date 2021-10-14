using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class NewsLetterController : Controller
    {
        INewsLetterService _newsLetterService;
        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.Status = true;
            _newsLetterService.Add(newsLetter);
            return PartialView();
        }
    }
}
