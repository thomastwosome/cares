using System.ComponentModel.DataAnnotations;

namespace Model.Enums
{
    public enum CredentialResponseType
    {
        [Display(Name = "Yes, from California")]
        California	=1,
        [Display(Name = "Yes, out of state/country")]
        Not_California	=2,
        No	=3
    }
}
