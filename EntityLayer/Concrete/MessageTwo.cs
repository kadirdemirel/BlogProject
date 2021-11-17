using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageTwo
    {
        [Key]
        public int MessageId { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
