using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var getAll = _blogService.GetListWithCategory();
            return View(getAll);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.id = id;
            var blogDetails = _blogService.GetBlogById(id);
            
            return View(blogDetails);
        }

        
    }
}
