using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum EducationType
    {
        [Display(Name = "Less than high school diploma/GED")]
        Less_than_high_school_diploma_GED	=1,
        [Display(Name = "High school diploma/GED")]
        High_school_diploma_GED	=2,
        [Display(Name = "")]
        Some_college	=3,
        [Display(Name = "AA in ECE/CD")]
        AA_in_ECECD	=4,
        [Display(Name = "BA in ECE/CD")]
        BA_in_ECECD	=5,
        [Display(Name = "Graduate degree in non-ECE/CD")]
        Graduate_degree_in_nonECECD	=6,
        [Display(Name = "Graduate degree in ECE/CD")]
        Graduate_degree_in_ECECD	=7,
        [Display(Name = "AA in Non-ECE/CD")]
        AA_in_NonECECD	=8,
        [Display(Name = "BA in Non-ECE/CD")]
        BA_in_NonECECD	=10,
        Other	=11
    }
}
