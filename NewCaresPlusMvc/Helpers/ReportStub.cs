using NewCaresPlusMvc.Models;
using System.Collections.Generic;

namespace NewCaresPlusMvc.Helpers
{
    public class ReportStub
    {
        public List<AllApplicationsReport> StubForAllApplicationsReportDataSet()
        {
            //this is used only to help in adding the dataset of type AllApplicationsReport to the report definition
            return null;
        }

        public List<ApplicantsbyComponent> ApplicantsbyComponentReportDataSet()
        {
            //this is used only to help in adding the dataset of type ApplicantsbyComponent to the report definition
            return null;
        }

    }
}