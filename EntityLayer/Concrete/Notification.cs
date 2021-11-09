using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
        public string NotificationColor { get; set; }

    }
}
