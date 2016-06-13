using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum SettingType
    {
        [Display(Name = "Licensed Child Care Center/Early Childhood Program")]
        Licensed_Child_Care_Center_Early_Childhood_Program	=1,
        Licensed_Family_Child_Care_Home	=2,
        [Display(Name = "License-Exempt Center or School-Age Program (e.g. Cal-SAFE, Military Child Care, Parent Co-Op)")]
        LicenseExempt_Center_or_School_Age_Program	=3,
        Other	=4
    }
}
