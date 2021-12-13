using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {

        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            //ViewBag.toplamBlogSayisi = _blogService.GetAll().Count();
            ViewBag.lastBlog = context.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.comment = context.Comments.Count();
            return View();
        }
    }
}
