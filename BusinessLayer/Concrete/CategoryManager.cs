using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class CategoryManager : ICategoryService
    {
        CategoryRepository _categoryRepository;
        public CategoryManager(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            if (category.CategoryName != "" && category.CategoryDescription != "" && category.CategoryName.Length >= 3 && category.CategoryStatus == true)
            {
                _categoryRepository.Add(category);
            }
            else
            {
                //hata mesajı
            }

        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
