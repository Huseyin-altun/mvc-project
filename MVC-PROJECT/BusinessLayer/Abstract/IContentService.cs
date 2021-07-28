using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {


        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListById(int id);
        void ContentAdd(Content c);
        Content GetByID(int id);
        void ContentDelete(Content c);

        void ContentUpdate(Content c);
    }
}
