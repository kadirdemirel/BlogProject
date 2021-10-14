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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }
        public void Add(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
        }

        public void Delete(NewsLetter newsLetter)
        {
            _newsLetterDal.Delete(newsLetter);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetterDal.GetAll();
        }

        public NewsLetter GetById(int newsLetterId)
        {
            return _newsLetterDal.Get(newsLetterId);
        }

        public void Update(NewsLetter newsLetter)
        {
            _newsLetterDal.Update(newsLetter);
        }
    }
}
