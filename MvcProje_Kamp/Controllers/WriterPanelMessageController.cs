using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje_Kamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = cm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = cm.GetListSendBox(p);
            return View(messagelist);
        }

        public ActionResult Draft()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = cm.GetListDraft(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messagevalidator.Validate(p);
            if (button == "send")
            {
                if (result.IsValid)
                {
                    p.SenderMail = sender;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.Draft = false;
                    cm.MessageAdd(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

            }
            else if (button == "draft")
            {
                if (result.IsValid)
                {
                    p.SenderMail = sender;
                    p.MessageDate = DateTime.Now;
                    p.Draft = true;
                    cm.MessageAdd(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
    }
}