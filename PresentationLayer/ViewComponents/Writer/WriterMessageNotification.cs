using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Writer
{

    public class WriterMessageNotification : ViewComponent
    {
        IMessageService _messageService;
        public WriterMessageNotification(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public IViewComponentResult Invoke()
        {
            string mail;
            mail = "deneme@gmail.com";
            var inbox = _messageService.GetInboxListByWriter(mail);
            return View(inbox);
        }
    }
}
