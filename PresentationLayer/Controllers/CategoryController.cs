using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var getAll = categoryManager.GetAll();
            return View(getAll);
        }
    }
}
