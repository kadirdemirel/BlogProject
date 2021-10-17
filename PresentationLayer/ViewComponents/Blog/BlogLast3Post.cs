using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        IBlogService _blogService;
        public BlogLast3Post(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var getAll = _blogService.GetLast3Blog();
            return View(getAll);
        }
    }
}
