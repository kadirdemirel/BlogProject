using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        IBlogService _blogService;
        public BlogListDashboard(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var selectedItems = _blogService.GetListWithCategory();
            return View(selectedItems);
        }
    }
}
