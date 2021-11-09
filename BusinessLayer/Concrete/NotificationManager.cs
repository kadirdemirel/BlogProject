using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.Get(id);
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}
