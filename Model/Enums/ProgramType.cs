using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum ProgramType
    {
        [Display(Name= "Head Start (including Early and Migrant Head Start")]
        Head_Start	=1,
        State_Preschool	=2,
        CDE_General_Child_Care	=3,
        [Display(Name = "Private/Subsidized (e.g. City, County or First 5)")]
        Private_Subsidized	=4,
        [Display(Name = "Private/Non-Subsidized")]
        Private_NonSubsidized	=5,
        Public_School	=6,
        Military_Base	=7,
        [Display(Name = "Race to the Top/High 5 for Quality")]
        Race_to_the_Top	=8,
        Other	=9
    }
}
