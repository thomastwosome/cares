using AutoMapper;
using NewCaresPlusMvc.Models;
using NewModel;

namespace NewCaresPlusMvc.Helpers
{
    public static class MappingExtensions
    {
        public static ApplicationViewModel ToModel(this Application entity)
        {
            return Mapper.Map<Application, ApplicationViewModel>(entity);
        }

        public static Application ToEntity(this ApplicationViewModel model)
        {
            return Mapper.Map<ApplicationViewModel, Application>(model);
        }

        public static Application ToEntity(this ApplicationViewModel model, Application entity)
        {
            return Mapper.Map(model, entity);
        }

        //Reports
        public static AllApplicationsReport ToAllApplicationsReport(this Application entity)
        {
            return Mapper.Map<Application, AllApplicationsReport>(entity);
        }

        public static SingleApplicationViewModel ToSingleApplicationViewModel(this Application entity)
        {
            return Mapper.Map<Application, SingleApplicationViewModel>(entity);
        }


    }
}