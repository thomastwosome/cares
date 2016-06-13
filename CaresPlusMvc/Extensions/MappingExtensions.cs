using AutoMapper;
using CaresPlusMvc.Areas.Applicant.Models;
using Model;

namespace CaresPlusMvc.Extensions
{
    public static class MappingExtensions
    {
        public static ApplicationViewModel ToApplicationViewModel(this Application entity)
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

    }
}