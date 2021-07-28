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
    public class ContentManager : IContentService

    {


        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        } 

        public void ContentAdd(Content c)
        {
            throw new NotImplementedException();
        }

        public void ContentDelete(Content c)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content c)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));
        }



        public List<Content> GetListById(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);    
        }

        public List<Content> GetListByWriter(int id)
        {
        return _contentDal.List(x => x.WriterID == 1);
        }
    }
}
