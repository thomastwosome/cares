using NewCaresPlusMvc.Helpers;
using NewCaresPlusMvc.Models;
using NewModel;
using NewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace NewCaresPlusMvc.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly UnitOfWork _cxt = new UnitOfWork();
        private readonly DataContext _db = new DataContext();
        private readonly HttpContextBase _httpContext;

        public AdministratorController()
        {

        }

        public AdministratorController(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        #region Reports

        [HttpGet]
        public ActionResult Reports()
        {
            ViewBag.Reports = CommonHelpers
                    .EnumToList(typeof(ReportType))
                    .ToSelectList(t => t.Value, t => t.Key.ToString())
                    .OrderBy(t => t.Text);

            return View("~/Views/Administrator/Reports/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetReport(int? page, int reportTypeId, int? formatId)
        {
            if (formatId.HasValue && !Enum.IsDefined(typeof(ReportViewModel.ReportFormat), formatId))
                return RedirectToAction("Index");

            var pageNumber = page ?? 1;

            switch ((ReportType)reportTypeId)
            {
                #region All Applications Report

                case ReportType.All_Applications:
                    var apps = _cxt.Applications.Get().ToList();
                    var vms = new List<AllApplicationsReport>();

                    apps.ForEach(c =>
                    {
                        var x = c.ToAllApplicationsReport();
                        vms.Add(x);
                    });

                    vms = vms
                        .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                        .ToList();

                    if (formatId.HasValue)
                    {
                        var reportViewModel = new ReportViewModel();
                        //var foo = _httpContext.Server.MapPath("~/Reports/AllApplicationsReport.rdlc");
                        reportViewModel.FileName = "Reports\\AllApplicationsReport.rdlc";
                        reportViewModel.Name = "AllApplicationsReport";
                        reportViewModel.ReportLanguage = "en-US";
                        reportViewModel.Format = (ReportViewModel.ReportFormat)formatId;
                        reportViewModel.ViewAsAttachment = false;

                        reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet()
                        {
                            DataSetData = vms.ToList<object>(),
                            DataSetName = "AllApplicationsReportDS"
                        });

                        var renderedBytes = reportViewModel.RenderReport();

                        if (reportViewModel.ViewAsAttachment)
                            Response.AddHeader("content-disposition", reportViewModel.ReportExportFileName);

                        return File(renderedBytes, reportViewModel.LastmimeType, reportViewModel.ReportExportFileName);
                    }

                    ViewBag.Count = apps.Count();
                    return PartialView(
                        "~/Views/Administrator/Reports/_AllApplicationsReport.cshtml", vms.ToList());

                #endregion

                #region Applications by Component Report

                case ReportType.Applications_by_Component:
                    var apps2 = _cxt.Applications.Get().ToList();
                    var vms2 = new List<ApplicantsbyComponent>();

                    foreach (var app in apps2)
                    {
                        var vm2 = AutoMapper.Mapper.Map<ApplicantsbyComponent>(app);
                        vms2.Add(vm2);
                    }

                    vms2 = vms2
                        .OrderByDescending(x => x.CompA)
                        .ThenByDescending(x => x.CompB)
                        .ThenByDescending(x => x.CompC)
                        .ThenByDescending(x => x.CompD)
                        .ThenBy(x => x.LastName)
                        .ThenBy(x => x.FirstName)
                        .ToList();

                    if (formatId.HasValue)
                    {
                        var reportViewModel = new ReportViewModel();
                        //var foo = _httpContext.Server.MapPath("~/Reports/AllApplicationsReport.rdlc");
                        reportViewModel.FileName = "Reports\\ApplicationsByComponentReport.rdlc";
                        reportViewModel.Name = "ApplicationsByComponentReport";
                        reportViewModel.ReportLanguage = "en-US";
                        reportViewModel.Format = (ReportViewModel.ReportFormat)formatId;
                        reportViewModel.ViewAsAttachment = false;

                        reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet()
                        {
                            DataSetData = vms2.ToList<object>(),
                            DataSetName = "ApplicantsByComponentReportDS"
                        });

                        var renderedBytes = reportViewModel.RenderReport();

                        if (reportViewModel.ViewAsAttachment)
                            Response.AddHeader("content-disposition", reportViewModel.ReportExportFileName);

                        return File(renderedBytes, reportViewModel.LastmimeType, reportViewModel.ReportExportFileName);
                    }

                    ViewBag.Acount = apps2.Where(x => x.CompA).Count();
                    ViewBag.Bcount = apps2.Where(x => x.CompB).Count();
                    ViewBag.Ccount = apps2.Where(x => x.CompC).Count();
                    ViewBag.Dcount = apps2.Where(x => x.CompD).Count();
                    return PartialView(
                        "~/Views/Administrator/Reports/_ApplicationsByComponent.cshtml", vms2.ToList());

                #endregion

                //#region Single Application Report

                //case ReportType.Single_Application:
                //    var apps2 = _cxt.Applications.Get().ToList();
                //    var vms2 = new List<SingleApplicationViewModel>();

                //    apps2.ForEach(c =>
                //    {
                //        var x = c.ToSingleApplicationViewModel();
                //        vms2.Add(x);
                //    });

                //    vms2 = vms2
                //        .OrderBy(x => x.LastName).ThenBy(x => x.FirstName)
                //        .ToList();

                //    if (formatId.HasValue)
                //    {
                //        var reportViewModel = new ReportViewModel();
                //        //var foo = _httpContext.Server.MapPath("~/Reports/AllApplicationsReport.rdlc");
                //        reportViewModel.FileName = "Reports\\AllApplicationsReport.rdlc";
                //        reportViewModel.Name = "AllApplicationsReport";
                //        reportViewModel.ReportLanguage = "en-US";
                //        reportViewModel.Format = (ReportViewModel.ReportFormat)formatId;
                //        reportViewModel.ViewAsAttachment = false;

                //        reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet()
                //        {
                //            DataSetData = vms2.ToList<object>(),
                //            DataSetName = "AllApplicationsReportDS"
                //        });

                //        var renderedBytes = reportViewModel.RenderReport();

                //        if (reportViewModel.ViewAsAttachment)
                //            Response.AddHeader("content-disposition", reportViewModel.ReportExportFileName);

                //        return File(renderedBytes, reportViewModel.LastmimeType, reportViewModel.ReportExportFileName);
                //    }

                //    ViewBag.Count = vms2.Count();
                //    //IEnumerable<SelectListItem> genders = (new List<string>() { "Female", "Male" }).ToSelectList(s => s, s => s, s => s == Model.Gender);
                //    return PartialView(
                //        "~/Views/Administrator/Reports/_SingleApplicationReport.cshtml", vms2.ToPagedList(pageNumber, 1));

                //#endregion


                default:
                    return PartialView("_Fail", "No report found");
            }

            #endregion

        }

        public ActionResult GetSingleReport(int id)
        {
            var app = _cxt.Applications.GetById(id);
            var vm = app.ToSingleApplicationViewModel();

            return PartialView("~/Views/Administrator/Reports/_SingleApplicationReport.cshtml", vm);

        }
        public ActionResult PrintSingleApplication(int id)
        {
            var app = _cxt.Applications.GetById(id);
            var vm = app.ToSingleApplicationViewModel();

            return View("~/Views/Administrator/Reports/PrintSingleApplication.cshtml", vm);

        }
    }
}