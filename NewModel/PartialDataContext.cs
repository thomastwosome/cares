using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Text;

namespace NewModel
{
    public partial class DataContext : DbContext
    {
        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var sb = new StringBuilder();

        //        foreach (var failure in ex.EntityValidationErrors)
        //        {
        //            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        //            foreach (var error in failure.ValidationErrors)
        //            {
        //                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
        //                sb.AppendLine();
        //            }
        //        }

        //        throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex); // Add the original exception as the innerException
        //    }
        //    //catch (SqlException sqlEx)
        //    //{
        //    //    var sb = new StringBuilder();

        //    //    for (int i = 0; i < sqlEx.Errors.Count; i++)
        //    //    {
        //    //        sb.Append("Index #" + i + "\n" +
        //    //            "Message: " + sqlEx.Errors[i].Message + "\n" +
        //    //            "LineNumber: " + sqlEx.Errors[i].LineNumber + "\n" +
        //    //            "Source: " + sqlEx.Errors[i].Source + "\n" +
        //    //            "Procedure: " + sqlEx.Errors[i].Procedure + "\n");
        //    //    }
        //    //    Console.WriteLine(sb.ToString());

        //    //    throw new SqlException("Database operation failed - errors follow:\n" + sb.ToString(), sqlEx); // Add the original exception as the innerException
        //    //}
        //}
    }
}
