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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public List<Writer> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int writerId)
        {
            return _writerDal.Get(writerId);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetAll(x => x.WriterID == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
