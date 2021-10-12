using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<CommentUser>
            {
                new CommentUser
                {
                    ID=1,
                    UserName="Kadir"
                },
                 new CommentUser
                {
                    ID=2,
                    UserName="Ahmet"
                },
                   new CommentUser
                {
                    ID=3,
                    UserName="Çiğdem"
                }
            };
            return View(commentValues);
        }
    }
}
