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
        IMessageTwoService _messageService;
        public WriterMessageNotification(IMessageTwoService messageService)
        {
            _messageService = messageService;
        }
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var inbox = _messageService.GetInboxListByWriter(id);
            return View(inbox);
        }
    }
}
