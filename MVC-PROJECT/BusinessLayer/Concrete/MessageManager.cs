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
    public class MessageManager : IMessageService

    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x=>x.MessageID==id);
        }

        public List<Message> GetListInbox(string p )
        {

            return _messageDal.List(x => x.ReceiverMail == p);
        }

      

   

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == "asd@gmail.com");
        }

        public void MessageAdd(Message m)
        {
            _messageDal.Insert(m);
        }

        public void MessageDelete(Message m)
        {
            _messageDal.Delete(m);
        }

     
    

        public void MessageUpdate(Message m)
        {
            _messageDal.Update(m);
        }
    }
}
