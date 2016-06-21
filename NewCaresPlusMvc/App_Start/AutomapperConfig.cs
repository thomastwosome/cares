using NewCaresPlusMvc.Models;
using NewModel;
using AutoMapper;
using System.Linq;
using NewCaresPlusMvc.Helpers;

namespace NewCaresPlusMvc
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            //Mapper.CreateMap<HttpPostedFileBase, byte[]>().ConvertUsing<HttpPostedFileBaseTypeConverter>();

            Mapper.CreateMap<Application, AllApplicationsReport>();
            Mapper.CreateMap<AllApplicationsReport, Application>();

            Mapper.CreateMap<Application, ApplicationViewModel>();
            Mapper.CreateMap<ApplicationViewModel, Application>()
                .ForMember(d => d.HomePhone, op => op.MapFrom(s => s.HomePhone.StripPunctuation()))
                .ForMember(d => d.WorkPhone, op => op.MapFrom(s => s.WorkPhone.StripPunctuation()))
                .ForMember(d => d.CellPhone, op => op.MapFrom(s => s.CellPhone.StripPunctuation()));

            Mapper.CreateMap<Application, ApplicantsbyComponent>()
                .ForMember(d => d.HomePhone, op => op.MapFrom(s => s.HomePhone.FormatPhoneNumber()))
                .ForMember(d => d.WorkPhone, op => op.MapFrom(s => s.WorkPhone.FormatPhoneNumber()))
                .ForMember(d => d.CellPhone, op => op.MapFrom(s => s.CellPhone.FormatPhoneNumber()))
                .ForMember(d => d.PrimaryPosition, op => op.ResolveUsing(new BothPositionResolver()));

            Mapper.CreateMap<Application, SingleApplicationViewModel>()
                .ForMember(d => d.HomePhone, op => op.MapFrom(s => s.HomePhone.FormatPhoneNumber()))
                .ForMember(d => d.WorkPhone, op => op.MapFrom(s => s.WorkPhone.FormatPhoneNumber()))
                .ForMember(d => d.CellPhone, op => op.MapFrom(s => s.CellPhone.FormatPhoneNumber()))
                .ForMember(d => d.Languages, op => op.ResolveUsing(new LanguageResolver()))
                .ForMember(d => d.Race, op => op.ResolveUsing(new RaceResolver()))
                .ForMember(d => d.Education, op => op.ResolveUsing(new EducationResolver()))
                .ForMember(d => d.Foreign, op => op.ResolveUsing(new ForeignResolver()))
                .ForMember(d => d.Permit, op => op.ResolveUsing(new PermitResolver()))
                .ForMember(d => d.Setting, op => op.ResolveUsing(new SettingResolver()))
                .ForMember(d => d.Position, op => op.ResolveUsing(new BothPositionResolver()))
                //.ForMember(d => d.FccPosition, op => op.ResolveUsing(new FccPositionResolver()))
                .ForMember(d => d.Dll, op => op.ResolveUsing(new DllResolver()))
                .ForMember(d => d.IsfpIep, op => op.ResolveUsing(new IsfpIepResolver()))
                .ForMember(d => d.ZeroToThirtySixMonths, op => op.ResolveUsing(new ZeroToResolver()))
                ;
            Mapper.CreateMap<SingleApplicationViewModel, Application>();

            //Mapper.AssertConfigurationIsValid();
        }
    }

    public class LanguageResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var languages = string.Empty;
            if (source.PlEnglish)
                languages += "English, ";
            if (source.PlMandarin)
                languages += "Mandarin, ";
            if (source.PlRussian)
                languages += "Russian, ";
            if (source.PlSpanish)
                languages += "Spanish, ";
            if (source.PlTagalog)
                languages += "Tagalog, ";
            if (source.PlViet)
                languages += "Vietnamese, ";
            if (source.PlHmong)
                languages += "Hmong, ";
            if (source.PlOther)
                languages += source.PlSpecify;
            return languages;
        }
    }

    public class RaceResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.Races.FirstOrDefault(x => x.Id == source.Race);
            return item?.Description;
        }
    }

    public class BothPositionResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var answer = string.Empty;
            if (source.Position == CommonConstants.CenterOther)
            {
                answer = source.PositionSpecify;
            }
            else
            {
                var position = cxt.Positions.FirstOrDefault(x => x.Id == source.Position);
                if (position != null)
                    answer = position.Description;
            }
            if (answer == string.Empty)
            {
                if (source.FccPosition == CommonConstants.FccOther)
                {
                    answer = source.FccSpecify;
                }
                else
                {
                    var position = cxt.FccPositions.FirstOrDefault(x => x.Id == source.FccPosition);
                    if (position != null)
                        answer = position.Description;
                }
            }
            return answer;
        }
    }

    public class EducationResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.Educations.FirstOrDefault(x => x.Id == source.Education);
            return item?.Description;
        }
    }

    public class ForeignResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.Foreigns.FirstOrDefault(x => x.Id == source.Foreign);
            return item?.Description;
        }
    }

    public class PermitResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.Permits.FirstOrDefault(x => x.Id == source.Permit);
            return item?.Description;
        }
    }

    public class SettingResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            if (source.Setting == 5)
            {
                return source.SettingSpecify;
            }
            var item = cxt.Settings.FirstOrDefault(x => x.Id == source.Setting);
            return item?.Description;
        }
    }

    public class PositionResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.Positions.FirstOrDefault(x => x.Id == source.Position);
            return item?.Description;
        }
    }

    public class FccPositionResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.FccPositions.FirstOrDefault(x => x.Id == source.FccPosition);
            return item?.Description;
        }
    }

    public class DllResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.YesNoDontKnows.FirstOrDefault(x => x.Id == source.Dll);
            return item?.Description;
        }
    }

    public class IsfpIepResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.YesNoDontKnows.FirstOrDefault(x => x.Id == source.IsfpIep);
            return item?.Description;
        }
    }

    public class ZeroToResolver : ValueResolver<Application, string>
    {
        protected override string ResolveCore(Application source)
        {
            var cxt = new DataContext();
            var item = cxt.YesNoDontKnows.FirstOrDefault(x => x.Id == source.ZeroToThirtySixMonths);
            return item?.Description;
        }
    }

    //public class HttpPostedFileBaseTypeConverter : ITypeConverter<HttpPostedFileBase, byte[]>
    //{
    //    public byte[] Convert(ResolutionContext ctx)
    //    {
    //        var fileBase = (HttpPostedFileBase)ctx.SourceValue;

    //        MemoryStream target = new MemoryStream();
    //        fileBase.InputStream.CopyTo(target);
    //        return target.ToArray();
    //    }
    //}
}