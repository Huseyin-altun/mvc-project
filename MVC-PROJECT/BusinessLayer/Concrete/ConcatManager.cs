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
   public class ConcatManager : IConcatService
    {

        IConcatDal _concatDal;

        public ConcatManager(IConcatDal concatDal)
        {
             _concatDal = concatDal;
        }

        public void ConcatAdd(Concat c)
        {
            _concatDal.Insert(c);
                
                }

        public void ConcatDelete(Concat c)
        {
            _concatDal.Delete(c);
        }

        public void ConcatUpdate(Concat c)
        {
            _concatDal.Update(c);
        }

        public Concat GetByID(int id)
        {
           return _concatDal.Get(x=>x.ConcatID==id);
        }

        public List<Concat> GetList()
        {
            return _concatDal.List();
        }
    }
}
