using AutoMapper;
using CaresPlusMvc.Areas.Applicant.Models;
using Model;

namespace CaresPlusMvc
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            //Mapper.CreateMap<HttpPostedFileBase, byte[]>().ConvertUsing<HttpPostedFileBaseTypeConverter>();

            Mapper.CreateMap<Application, ApplicationViewModel>();
            Mapper.CreateMap<ApplicationViewModel, Application>();

            //Mapper.AssertConfigurationIsValid();
        }

        // Part 2
        public static TDestination Map<TSource, TDestination>(this TDestination destination, TSource source)
        {
            return Mapper.Map(source, destination);
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