using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IConcatService
    {
        List<Concat> GetList();
        void ConcatAdd(Concat c);
        Concat GetByID(int id);
        void ConcatDelete(Concat c);

        void ConcatUpdate(Concat c);
    }
}
