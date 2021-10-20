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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Add(about);
        }

        public void Delete(About about)
        {
            _aboutDal.Delete(about);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public List<About> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
