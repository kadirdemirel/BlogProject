using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
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
            var userMail = User.Identity.Name;
            ViewBag.userName = userMail;
            Context context = new Context();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var writerBlogs = _blogService.GetListWithCategoryByWriter(writerID);
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

            var userMail = User.Identity.Name;
            ViewBag.userName = userMail;
            Context context = new Context();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();


            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = writerID;


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
        public IActionResult DeleteBlog(int id)
        {
            var blogItem = _blogService.GetById(id);
            _blogService.Delete(blogItem);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogItem = _blogService.GetById(id);
            List<SelectListItem> selectListItems = (from x in _categoryService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryID.ToString()


                                                    }).ToList();
            ViewBag.categories = selectListItems;
            return View(blogItem);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            ViewBag.userName = userMail;
            Context context = new Context();
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            blog.WriterID = writerID;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
