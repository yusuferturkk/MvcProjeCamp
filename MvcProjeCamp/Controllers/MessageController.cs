using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class MessageController : Controller
    {

        IMessageService messageService = new MessageManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            var values = messageService.GetListInbox();
            return View(values);
        }

        public ActionResult SendBox()
        {
            var values = messageService.GetListSendbox();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            messageService.Add(message);
            return RedirectToAction("SendBox");
        }
    }
}