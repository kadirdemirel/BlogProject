using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageTwoRepository : GenericRepository<MessageTwo>, IMessageTwoDal
    {
        public List<MessageTwo> GetListWithMessageTwoByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.MessageTwos.Include(x => x.SenderUser).Where(x => x.Receiver == id).ToList();
            }
        }
    }
}
