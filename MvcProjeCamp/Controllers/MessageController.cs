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
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = validator.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageService.Add(message);
                return RedirectToAction("Sendbox");
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