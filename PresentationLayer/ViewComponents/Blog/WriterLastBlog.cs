using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Blog
{
    public class WriterLastBlog:ViewComponent
    {
        IBlogService _blogService;
        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var getAll = _blogService.GetBlogListByWriter(1);
            return View(getAll);
        }
    }
}
