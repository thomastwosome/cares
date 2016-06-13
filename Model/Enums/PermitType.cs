using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum PermitType
    {
        Do_not_have_a_permit	=1,
        Assistant	=2,
        Associate_Teacher	=3,
        Teacher	=4,
        Master_Teacher	=5,
        Site_Supervisor	=6,
        Program_Director	=7,
        [Display(Name = "Children's Center Instructional Permit")]
        Instructional_Permit	=8,
        [Display(Name = "Children's Center Supervisor Permit")]
        Children_Center_Supervisor_Permit	=9,
        [Display(Name = "Teaching Credential plus 12 ECE/CD units")]
        Teaching_Credential_Plus	=10
    }
}
