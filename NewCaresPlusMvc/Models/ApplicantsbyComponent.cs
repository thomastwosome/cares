using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewCaresPlusMvc.Models
{
    public class ApplicantsbyComponent
    {
        [Display(Name = "Component A")]
        public bool CompA { get; set; }
        [Display(Name = "Component B")]
        public bool CompB { get; set; }
        [Display(Name = "Component C")]
        public bool CompC { get; set; }
        [Display(Name = "Component D")]
        public bool CompD { get; set; }
        [Display(Name = "Employer")]
        public string EmployerName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string PrimaryPosition { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Mailing Address")]
        public string MailingAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "City")]
        public string MailingCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "State")]
        public string MailingState { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(5)]
        [Display(Name = "Zip")]
        public string MailingZip { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
    }
}