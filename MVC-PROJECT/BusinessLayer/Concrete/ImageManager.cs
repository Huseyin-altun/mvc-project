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
   public class ImageManager : IImageService
    {
        IImageDal _ımageDal;

        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public List<Image> GetList()
        {
            return _ımageDal.List();
        }
    }
}
