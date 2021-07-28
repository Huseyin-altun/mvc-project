using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {

        Admin GetAdmin(string username, string password);

        List<Admin> GetList();
        void AdminAdd(Admin a);
        Admin GetByID(int id);
        void AdminDelete(Admin a);

        void AdminUpdate(Admin a);
    }
}
