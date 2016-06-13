using System.Web.Mvc;
using Model;
using Model.Infrastructure;
using CaresPlusMvc.Helpers;
using Model.Enums;
using CaresPlusMvc.Areas.Applicant.Models;
using System;
using Model.Helpers;
using CaresPlusMvc.Extensions;
using System.Linq;

namespace CaresPlusMvc.Areas.Applicant.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly UnitOfWork _cxt = new UnitOfWork();

        public ActionResult Create()
        {
            Application entity = null;
            entity = _cxt.Applications.Get(filter: x=>x.Id == 2, includeProperties: "Ethnicities,Programs,Degrees,CredentialTypes").FirstOrDefault();
            var model = PrepareApplicationViewModel(entity);
            //var model = PrepareApplicationViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationViewModel model)
        {
            Application entity = null;
            entity = _cxt.Applications.GetById(model.Id);

            if (ModelState.IsValid)
            {
                entity = model.ToEntity(entity);

                _cxt.Applications.Update(entity);

                //var cViewModel = PrepareApplicationViewModel(entity: entity);

                return View("ThankYou");
            }

            model = PrepareApplicationViewModel(iModel: model);

            return View(model);
        }

        private ApplicationViewModel PrepareApplicationViewModel(Application entity = null, ApplicationViewModel iModel = null)
        {
            //put iModel in model, unless it's null; in that case create a new model
            var oModel = iModel ?? new ApplicationViewModel();

            if (entity != null && iModel == null)
                oModel = entity.ToApplicationViewModel(); //only on POST
            oModel.Application = _cxt.Applications.Get(filter: x => x.Id == 2, includeProperties: "Ethnicities,Programs,Degrees,CredentialTypes").FirstOrDefault();
            oModel.DateOfApplication = DateTime.Now.ToPstTime();
            oModel.SignatureDate = DateTime.Now.ToPstTime();
            ViewBag.MailingStates = CommonHelpers.GetUsStates().ToSelectList(s => s.Name, s => s.Name, s => s.Name == oModel.MailingAddressState);
            ViewBag.HomeStates = CommonHelpers.GetUsStates().ToSelectList(s => s.Name, s => s.Name, s => s.Name == oModel.HomeAddressState);
            ViewBag.WorkStates = CommonHelpers.GetUsStates().ToSelectList(s => s.Name, s => s.Name, s => s.Name == oModel.SiteState);
            ViewBag.CountyChoices = CommonHelpers.EnumToList(typeof(CountyType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.GenderChoices = CommonHelpers.EnumToList(typeof(GenderType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.LanguageChoices = CommonHelpers.EnumToList(typeof(LanguageType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            //ViewBag.RaceChoices = CommonHelpers.EnumToList(typeof(RaceType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            //ViewBag.RaceChoices = new MultiSelectList(categories, "CategoryID", "CategoryName");
            //ViewBag.ProgramChoices = CommonHelpers.EnumToList(typeof(ProgramType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.EducationChoices = CommonHelpers.EnumToList(typeof(EducationType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.PermitChoices = CommonHelpers.EnumToList(typeof(PermitType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.CredentialResponseChoices = CommonHelpers.EnumToList(typeof(CredentialResponseType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.SettingChoices = CommonHelpers.EnumToList(typeof(SettingType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            ViewBag.PositionChoices = CommonHelpers.EnumToList(typeof(PositionType)).ToSelectList(x => x.Value, x => x.Key.ToString());
            var ethnicities = _cxt.Ethnicities.Get();
            oModel.AllEthnicities = ethnicities.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var programs = _cxt.Programs.Get();
            oModel.AllPrograms = programs.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var degrees = _cxt.Degrees.Get();
            oModel.AllDegrees = degrees.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var credentialTypes = _cxt.CredentialTypes.Get();
            oModel.AllCredentialTypes = credentialTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            oModel = TempFillViewModel(oModel);
            return oModel;

        }

        private ApplicationViewModel TempFillViewModel(ApplicationViewModel model)
        {
            model.FirstName = "Laura";
            model.LastName = "Thomas";
            model.DateOfBirth = new DateTime(1971, 11, 24);
            model.CityOfBirth = "Los Angeles";
            model.Gender = GenderType.Female;
            model.County = CountyType.El_Dorado;
            model.HomePhone = "9169396765";
            model.Email = "lthomas@edcoe.org";
            model.MailingAddress1 = "5001 Morrill Court";
            model.MailingAddressCity = "EDH";
            model.MailingAddressState = "California";
            model.MailingAddressZip = "95762";
            model.LastFiveSSN = "33662";
            model.Site = "EDCOE";
            model.WorkPhone = "5306227130";
            model.SiteAddress1 = "6767 Green Valley Road";
            model.SiteCity = "Pville";
            model.SiteState = "California";
            model.SiteZip = "95667";
            model.StartDate = new DateTime(2016, 03, 29);
            model.DateOfAttainment = new DateTime(2016, 03, 29);
            model.AnnualSalary = 100000;
            model.Signature = "Laura A. Thomas";
            model.GaveConsent = true;
            model.PrimaryLanguage = LanguageType.English;
            model.ClassroomLanguage = LanguageType.English;
            model.CoachingLanguage = LanguageType.English;
            model.SettingType = SettingType.Licensed_Family_Child_Care_Home;
            model.PositionTitle1 = PositionType.Executive_Director;
            return model;
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
