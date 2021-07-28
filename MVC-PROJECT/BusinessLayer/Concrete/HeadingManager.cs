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
    public class HeadingManager : IHeadingService
    {


        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();

        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID ==id);
        }

        public void HeadingAdd(Heading h)
        {
            _headingDal.Insert(h);
        }

        public void HeadingDelete(Heading h)
        {
           
            _headingDal.Update(h);
        }

        public void HeadingUpdate(Heading h)
        {
            _headingDal.Update(h);
        }
    }
}
