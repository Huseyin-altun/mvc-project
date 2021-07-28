using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin a)
        {
            _adminDal.Insert(a);
        }

        public void AdminDelete(Admin a)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdate(Admin a)
        {
            _adminDal.Update(a);
        }

        public Admin GetAdmin(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id ); 
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
