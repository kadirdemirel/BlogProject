using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class MessageController : Controller
    {
        IMessageTwoService _messageTwoService;
        public MessageController(IMessageTwoService messageTwoService)
        {
            _messageTwoService = messageTwoService;
        }
        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 2;
            var inbox = _messageTwoService.GetInboxListByWriter(id);
            return View(inbox);
        }
        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var messageDetails = _messageTwoService.GetById(id);
           
            return View(messageDetails);
        }
    }
}
