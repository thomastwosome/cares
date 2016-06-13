using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum PositionType
    {
        [Display(Name = "Teacher/Director")]
        TeacherDirector	=1,
        [Display(Name = "Teacher/Lead Teacher")]
        TeacherLeadTeacher	=2,
        [Display(Name = "Assistant Teacher/Teacher Aide")]
        AssistantTeacher_TeacherAide	=3,
        Other	=6,
        [Display(Name = "Director, Multi - site")]
        Director_MultiSite	=7,
        [Display(Name = "Specialized Teaching Staff (e.g. Special Education Teacher, Supervising Master Teacher)")]
        Specialized_Teaching_Staff	=8,
        [Display(Name = "Professional Support Staff (e.g. Curriculum Specialist, Mental Health Consultant)")]
        Professional_Support_Staff	=9,
        Site_Supervisor	=10,
        Assistant_Director	=11,
        [Display(Name = "Director, Single - site")]
        Director_SingleSite	=12,
        Executive_Director	=13
    }
}
