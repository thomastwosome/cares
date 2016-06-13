using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NewModel;

namespace NewCaresPlusMvc.Controllers
{
    public class VanillaApplicationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Applicant/VanillaApplication
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: Applicant/VanillaApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applicant/VanillaApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicant/VanillaApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrgCode,TrainName,TrainDate,Dob,BirthCity,Ssn5,Education,Foreign,AaEce,AaEd,AaBus,AaOther,BaEce,BaEd,BaBus,BaOther,MaEce,MaEd,MaBus,MaOther,DocEce,DocEd,DocBus,DocOther,Permit,CredNone,CredAdmin,CredBilingual,CredClinical,CredEarly,CredMultiple,CredPupil,CredReading,CredSchool,CredSingle,CredSpec,CredSpeech,CredOther,Setting,SettingSpecify,Position,PositionSpecify,FccPosition,FccSpecify,WorkCity,WorkCounty,WorkZip,TenureEce,TenureEmploy,TenurePosition,HoursWeek,MonthsYear,TotalKids,LessThanOne,OneYear,TwoYears,ThreeYears,FourYears,SchoolAge,Dll,IsfpIep,SalaryHour,SalaryMonth,SalaryYear,Gender,Race,RaceSpecify,PlEnglish,PlMandarin,PlRussian,PlSpanish,PlTagalog,PlViet,PlHmong,PlOther,PlSpecify,FlEnglish,FlMandarin,FlRussian,FlSpanish,FlTagalog,FlViet,FlHmong,FlOther,FlSpecify,Registry,RegistryId,FirstName,LastName,MailingAddress,MailingCity,MailingState,MailingZip,Email,EmployerName,DirectorFirstName,DirectorLastName")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        // GET: Applicant/VanillaApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applicant/VanillaApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrgCode,TrainName,TrainDate,Dob,BirthCity,Ssn5,Education,Foreign,AaEce,AaEd,AaBus,AaOther,BaEce,BaEd,BaBus,BaOther,MaEce,MaEd,MaBus,MaOther,DocEce,DocEd,DocBus,DocOther,Permit,CredNone,CredAdmin,CredBilingual,CredClinical,CredEarly,CredMultiple,CredPupil,CredReading,CredSchool,CredSingle,CredSpec,CredSpeech,CredOther,Setting,SettingSpecify,Position,PositionSpecify,FccPosition,FccSpecify,WorkCity,WorkCounty,WorkZip,TenureEce,TenureEmploy,TenurePosition,HoursWeek,MonthsYear,TotalKids,LessThanOne,OneYear,TwoYears,ThreeYears,FourYears,SchoolAge,Dll,IsfpIep,SalaryHour,SalaryMonth,SalaryYear,Gender,Race,RaceSpecify,PlEnglish,PlMandarin,PlRussian,PlSpanish,PlTagalog,PlViet,PlHmong,PlOther,PlSpecify,FlEnglish,FlMandarin,FlRussian,FlSpanish,FlTagalog,FlViet,FlHmong,FlOther,FlSpecify,Registry,RegistryId,FirstName,LastName,MailingAddress,MailingCity,MailingState,MailingZip,Email,EmployerName,DirectorFirstName,DirectorLastName")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: Applicant/VanillaApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applicant/VanillaApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
