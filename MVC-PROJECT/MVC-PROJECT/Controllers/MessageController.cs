using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class MessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: Message
        public ActionResult Inbox(string p)
        {
            var messageList = messageManager.GetListInbox(p);
            return View(messageList); 
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = messageManager.GetListSendbox(p);
            return View(messageList);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message m)
        {
            m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.MessageAdd(m);
            return RedirectToAction("Sendbox");
        }


        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = messageManager.GetByID(id);
            return View(Values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = messageManager.GetByID(id);
            return View(Values);
        }


    }

}