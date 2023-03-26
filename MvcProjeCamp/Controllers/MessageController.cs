using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        MessageValidator validator = new MessageValidator();

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

        public ActionResult DraftBox()
        {
            var values = messageService.GetListDraftbox();
            return View(values);
        }

        public ActionResult TrashBox()
        {
            var values = messageService.GetListTrashbox();
            return View(values);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string draftBox, string sendBox, string trashBox)
        {
            ValidationResult results = validator.Validate(message);
            if (results.IsValid)
            {
                if (sendBox != null)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.MessageStatusId = 1;
                    messageService.Add(message);
                    return RedirectToAction("SendBox");
                    
                }
                else if (draftBox != null)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.MessageStatusId = 2;
                    messageService.Add(message);
                    return RedirectToAction("DraftBox");
                }
                else if (trashBox != null)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.MessageStatusId = 3;
                    messageService.Add(message);
                    return RedirectToAction("TrashBox");
                }

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}