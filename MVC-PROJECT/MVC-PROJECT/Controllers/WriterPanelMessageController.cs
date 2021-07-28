using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectMVC.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
        
           string p = (string)Session["WriterMail"];
           
            var messageList = messageManager.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {

            return PartialView();
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



        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message m)
        {
            m.SenderMail = (string)Session["WriterMail"]; 
            m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.MessageAdd(m);
            return RedirectToAction("Sendbox");
        }



    }
}