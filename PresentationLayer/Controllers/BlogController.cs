﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        ICategoryService _categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
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

        public IActionResult BlogListByWriter()
        {
            var writerBlogs = _blogService.GetListWithCategoryByWriter(1);
            return View(writerBlogs);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> selectListItems = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString()


                                                    }).ToList();
            ViewBag.categories = selectListItems;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(blog);

            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;


                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
