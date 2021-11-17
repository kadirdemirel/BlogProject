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
  public  class MessageTwoManager:IMessageTwoService
    {
        IMessageTwoDal _messageTwoDal;
        public MessageTwoManager(IMessageTwoDal messageTwoDal)
        {
            _messageTwoDal = messageTwoDal;
        }

        public void Add(MessageTwo messageTwo)
        {
            throw new NotImplementedException();
        }

        public void Delete(MessageTwo messageTwo)
        {
            throw new NotImplementedException();
        }

        public List<MessageTwo> GetAll()
        {
            return _messageTwoDal.GetAll();
        }

        public List<MessageTwo> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public MessageTwo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MessageTwo> GetInboxListByWriter(int id)
        {
            return _messageTwoDal.GetAll(x => x.Receiver == id);
        }

        public void Update(MessageTwo messageTwo)
        {
            throw new NotImplementedException();
        }
    }
}
