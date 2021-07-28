using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public   interface IMessageService
    {

        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void MessageAdd(Message m);
        Message GetByID(int id);
        void MessageDelete(Message m);

        void MessageUpdate(Message m);
    }
}
