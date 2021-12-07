using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.Name;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }

        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel
                {
                     Id=1,Name="C# Programlamaya Giriş"
                },
                 new BlogModel
                {
                     Id=2,Name="Java Programlamaya Giriş"
                },
                  new BlogModel
                {
                     Id=3,Name="2020 Olimpiyat Oyunları"
                },
            };
            return blogModels;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.Name;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
        }
        public List<DynamicBlog> BlogTitleList()
        {
            List<DynamicBlog> dynamicBlogs = new List<DynamicBlog>();
            using (var context = new Context())
            {
                dynamicBlogs = context.Blogs.Select(x => new DynamicBlog
                {
                    Id = x.BlogID,
                    Name = x.BlogTitle
                }).ToList();

            }
            return dynamicBlogs;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
