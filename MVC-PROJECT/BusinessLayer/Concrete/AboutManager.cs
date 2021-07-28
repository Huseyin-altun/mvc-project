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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About a)
        {
            _aboutDal.Insert(a);
        }

        public void AboutDelete(About a)
        {
            _aboutDal.Delete(a);
        }

        public void AboutUpdate(About a)
        {
            _aboutDal.Update(a);
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List(); 
        }
    }
}
