using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PresentationLayer.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        IBlogService _blogService;
        public Statistic1(IBlogService blogService)
        {
            _blogService = blogService;
        }
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.toplamBlogSayisi = _blogService.GetAll().Count();
            ViewBag.contact = context.Contacts.Count();
            ViewBag.comment = context.Comments.Count();

            string api = "4d45f4dac6a09b46d48b6824a4f8cebc";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=mersin&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.heat = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
