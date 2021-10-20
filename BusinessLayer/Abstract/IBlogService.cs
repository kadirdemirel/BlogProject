using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {

        List<Blog> GetListWithCategory();
        List<Blog> GetBlogById(int id);
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetLast3Blog();
    }
}
