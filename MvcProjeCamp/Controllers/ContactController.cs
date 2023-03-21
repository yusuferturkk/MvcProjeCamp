﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeCamp.Controllers
{
    public class ContactController : Controller
    {

        IContactService contactService = new ContactManager(new EfContactDal());
        ContactValidator validator = new ContactValidator();

        IMessageService messageService = new MessageManager(new EfMessageDal());
        IDraftService draftService = new DraftManager(new EfDraftDal());

        public ActionResult Index()
        {
            var values = contactService.GetList();
            return View(values);
        }

        public PartialViewResult PartialContactSideMenu()
        {
            var inboxCount = messageService.GetListInbox().Count();
            var sendboxCount = messageService.GetListSendbox().Count();
            var draftCount = draftService.GetList().Count();
            var contactCount = contactService.GetList().Count();

            ViewBag.inboxCount = inboxCount;
            ViewBag.sendboxCount = sendboxCount;
            ViewBag.draftCount = draftCount;
            ViewBag.contactCount = contactCount;
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var value = contactService.GetById(id);
            return View(value);
        }
    }
}