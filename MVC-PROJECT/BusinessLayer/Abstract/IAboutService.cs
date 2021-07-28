using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IAboutService
    {
        List<About> GetList();
        void AboutAdd(About a);
        About GetByID(int id);
        void AboutDelete(About a);

        void AboutUpdate(About a);

    }
}
