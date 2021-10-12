using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
        List<Writer> GetAll();
        Writer GetById(int writerId);
    }
}
