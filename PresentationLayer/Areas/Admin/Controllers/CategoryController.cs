using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index(int page=1)
        {
            //page:sayfalama işleminin kaçıncı sayfadan başlayacağını belirler.
            var categoryList = _categoryService.GetAll().ToPagedList(page, 10);
            return View(categoryList);
        }
    }
}
