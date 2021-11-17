using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public bool WriterStatus { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<City> Cities { get; set; }
        public virtual ICollection<MessageTwo> WriterSender { get; set; }
        public virtual ICollection<MessageTwo> WriterReceiver { get; set; }

    }
}
