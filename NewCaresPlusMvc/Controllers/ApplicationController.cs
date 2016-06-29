using NewCaresPlusMvc.Helpers;
using NewCaresPlusMvc.Models;
using NewModel;
using NewModel.Helpers;
using NewModel.Infrastructure;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace NewCaresPlusMvc.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly UnitOfWork _cxt = new UnitOfWork();
        private readonly DataContext _db = new DataContext();

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = PrepareApplicationViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationViewModel model)
        {
            Application entity = new Application();

            var x = 0;
            if (model.CompA) { x++; }
            if (model.CompB) { x++; }
            if (model.CompC) { x++; }
            if (model.CompD) { x++; }

            if (x < 1)
            {
                ModelState.AddModelError(string.Empty, "You must apply for at least one incentive.");
            }

            if (x > 2)
            {
                ModelState.AddModelError(string.Empty, "You can apply for no more than two incentives.");
            }

            if (ModelState.IsValid)
            {
                entity = model.ToEntity(entity);
                entity.OrgCode = CommonConstants.OrgCode;
                entity.TrainName = CommonConstants.TrainName;
                entity.TrainDate = DateTime.Now.ToPstTime();
                entity.Registry = true;
                entity.RegistryId = CommonConstants.RegistryId;
                var month = entity.Dob.Month;
                var day = entity.Dob.Day;
                var year = entity.Dob.Year;
                entity.ParticipantId = month + day.ToString() + year + entity.Ssn5;

                _db.Applications.Add(entity);
                _db.SaveChanges();

                SendThankYouEmail(model.Email);
                SendNotificationEmail();
                return View("ThankYou");
            }

            //if (ViewData.ModelState[""] != null && ViewData.ModelState[""].Errors.Any())
            //{
                model = PrepareApplicationViewModel(iModel: model);
                return View(model);
            //}
        }

        private ApplicationViewModel PrepareApplicationViewModel(Application entity = null, ApplicationViewModel iModel = null)
        {
            //put iModel in model, unless it's null; in that case create a new model
            var oModel = iModel ?? new ApplicationViewModel();

            var components = _cxt.Components.Get();
            ViewBag.Components = new SelectList(components, "Id", "Description");
            var edLevels = _cxt.EdLevels.Get();
            ViewBag.EdLevels = new SelectList(edLevels, "Id", "Description");
            var foreignDegrees = _cxt.ForeignDegrees.Get();
            ViewBag.ForeignDegrees = new SelectList(foreignDegrees, "Id", "Description");
            var permits = _cxt.Permits.Get();
            ViewBag.Permits = new SelectList(permits, "Id", "Description");
            var positions = _cxt.Positions.Get();
            ViewBag.Positions = new SelectList(positions, "Id", "Description");
            var fccPositions = _cxt.FccPositions.Get();
            ViewBag.FccPositions = new SelectList(fccPositions, "Id", "Description");
            var races = _cxt.Races.Get();
            ViewBag.Races = new SelectList(races, "Id", "Description");
            var settings = _cxt.Settings.Get();
            ViewBag.Settings = new SelectList(settings, "Id", "Description");
            var yesNoDontKnows = _cxt.YesNoDontKnows.Get();
            ViewBag.YesNoDontKnows = new SelectList(yesNoDontKnows, "Id", "Description");
            ViewBag.States = CommonHelpers.GetUsStates().ToSelectList(s => s.Name, s => s.Name);

            return oModel;
        }

        private void SendThankYouEmail(string email)
        {
            var filename = Server.MapPath("~/App_Data/ThankYou.htm");
            var mailBody = System.IO.File.ReadAllText(filename);

            var myMessage = new MailMessage
            {
                Subject = "Response from CARES Application 2016-17",
                Body = mailBody,
                IsBodyHtml = true
            };

            myMessage.To.Add(new MailAddress(email, email));
            var attachment1 = Server.MapPath("~/Documents/Application Docs.pdf");
            myMessage.Attachments.Add(new Attachment(attachment1));
            var attachment2 = Server.MapPath("~/Documents/Application Docs (Spanish).pdf");
            myMessage.Attachments.Add(new Attachment(attachment2));

            var mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);

        }

        private void SendNotificationEmail()
        {
            var filename = Server.MapPath("~/App_Data/Notification.htm");
            var mailBody = System.IO.File.ReadAllText(filename);

            var myMessage = new MailMessage
            {
                Subject = "New CARES Application 2016-17",
                Body = mailBody,
                IsBodyHtml = true
            };

            myMessage.To.Add(new MailAddress("lblackburn@edcoe.org", "Lori Blackburn"));

            var mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);

        }
    }
}