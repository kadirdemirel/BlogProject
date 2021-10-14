using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterService
    {
        void Add(NewsLetter newsLetter);
        void Delete(NewsLetter newsLetter);
        void Update(NewsLetter newsLetter);
        List<NewsLetter> GetAll();
        NewsLetter GetById(int newsLetterId);
    }
}
