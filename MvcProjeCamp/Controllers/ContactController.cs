using BusinessLayer.Abstract;
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

        public ActionResult Index()
        {
            var values = contactService.GetList();
            return View(values);
        }

        public PartialViewResult PartialContactSideMenu()
        {
            var inboxCount = messageService.GetListInbox().Count();
            var sendboxCount = messageService.GetListSendbox().Count();
            var draftboxCount = messageService.GetListDraftbox().Count();
            var contactCount = contactService.GetList().Count();
            var trashboxCount = messageService.GetListTrashbox().Count();

            ViewBag.inboxCount = inboxCount;
            ViewBag.sendboxCount = sendboxCount;
            ViewBag.contactCount = contactCount;
            ViewBag.draftboxCount = draftboxCount;
            @ViewBag.trashboxCount = trashboxCount;
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var value = contactService.GetById(id);
            return View(value);
        }
    }
}