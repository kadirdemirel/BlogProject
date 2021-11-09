using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        INotificationService _notificationService;
        public WriterNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IViewComponentResult Invoke()
        {
            var notificationList = _notificationService.GetAll();
            return View(notificationList);
        }
    }
}