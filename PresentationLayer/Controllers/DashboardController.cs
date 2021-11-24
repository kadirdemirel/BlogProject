using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        IBlogService _blogService;
       
        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
      
        }
  
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.toplamBlogSayisi = context.Blogs.Count().ToString();
            ViewBag.yazarBlogSayisi = context.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.toplamKategoriSayisi = context.Categories.Count();
            return View();
        }
    }
}
