using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
    {

        List<Category> GetList();
        void CategoryAdd( Category c);
        Category GetByID(int id);
        void CategoryDelete(Category c);

        void CategoryUpdate(Category c);
    }
}
