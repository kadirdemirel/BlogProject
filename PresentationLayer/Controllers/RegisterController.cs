using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules.FluentValidation;
using EntityLayer.Concrete;

using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        IWriterService _writerService;
        ICityService _cityService;
        public RegisterController(IWriterService writerService, ICityService cityService)
        {
            _writerService = writerService;
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> selectListItems = (from x in _cityService.GetAll()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CityName,
                                                        Value = x.CityID.ToString()

                                                    }).ToList();
            
            ViewBag.city = selectListItems;

            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(writer);

            if (validationResult.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme";

                _writerService.Add(writer);
                return RedirectToAction("Index", "Blog");
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
