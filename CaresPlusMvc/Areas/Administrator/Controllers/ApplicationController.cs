using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Infrastructure;

namespace CaresPlusMvc.Areas.Administrator.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly UnitOfWork _cxt = new UnitOfWork();

        public ActionResult Index()
        {
            var applications = _cxt.Applications.Get(orderBy: q => q.OrderBy(d => d.DateOfApplication));
            return View(applications.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Application application = _cxt.Applications.GetById(id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            if (ModelState.IsValid)
            {
                _cxt.Applications.Insert(application);
                _cxt.Save();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = _cxt.Applications.GetById(id);
            if (application == null)
            {
                return HttpNotFound();
            }

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Application application)
        {
            if (ModelState.IsValid)
            {
                _cxt.Applications.Update(application);
                _cxt.Save();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = _cxt.Applications.GetById(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = _cxt.Applications.GetById(id);
            _cxt.Applications.Delete(application);
            _cxt.Save();
            return RedirectToAction("Index");
        }
    }
}
