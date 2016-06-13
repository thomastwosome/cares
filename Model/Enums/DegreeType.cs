using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum DegreeType
    {
        [Display(Name = "Associate's Degree")]
        AA	=1,
        [Display(Name = "Bachelor's Degree (4 year degree)")]
        BS	=2,
        [Display(Name = "Master's Degree")]
        MS	=3,
        [Display(Name = "Doctorate or Other Advanced Degree")]
        PhD	=4
    }
}
