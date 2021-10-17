using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetAll();
        Blog GetById(int blogId);
        List<Blog> GetListWithCategory();
        List<Blog> GetBlogById(int id);
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetLast3Blog();
    }
}
