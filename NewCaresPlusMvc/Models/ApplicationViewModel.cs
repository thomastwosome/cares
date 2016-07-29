using NewCaresPlusMvc.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NewModel;

namespace NewCaresPlusMvc.Models
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[StringLength(13, ErrorMessage = "Required number of characters: 13")]
        //public string ParticipantId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[StringLength(8, ErrorMessage = "Required number of characters: 8")]
        //public string OrgCode { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        //public string TrainName { get; set; }

        //[Column(TypeName = "date")]
        //[Required(ErrorMessage = "This field is required")]
        //public DateTime TrainDate { get; set; }

        public bool CompA { get; set; }
        public bool CompB { get; set; }
        public bool CompC { get; set; }
        public bool CompD { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "City of Birth")]
        public string BirthCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(CommonConstants.Last5SsnRegex, ErrorMessage = "Please enter five numbers.")]
        [Display(Name = "Last 5 Digits of SSN")]
        public string Ssn5 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Highest Level of Education")]
        public int Education { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Degree from Foreign Country?")]
        public int Foreign { get; set; }

        [Display(Name = "ECE/Child or Human Development?")]
        public bool AaEce { get; set; }

        [Display(Name = "Education Psychology/Social Work?")]
        public bool AaEd { get; set; }

        [Display(Name = "Business/Math/Science/Health")]
        public bool AaBus { get; set; }

        [Display(Name = "Other")]
        public bool AaOther { get; set; }

        [Display(Name = "ECE/Child or Human Development?")]
        public bool BaEce { get; set; }

        [Display(Name = "Education Psychology/Social Work?")]
        public bool BaEd { get; set; }

        [Display(Name = "Business/Math/Science/Health")]
        public bool BaBus { get; set; }

        [Display(Name = "Other")]
        public bool BaOther { get; set; }

        [Display(Name = "ECE/Child or Human Development?")]
        public bool MaEce { get; set; }

        [Display(Name = "Education Psychology/Social Work?")]
        public bool MaEd { get; set; }

        [Display(Name = "Business/Math/Science/Health")]
        public bool MaBus { get; set; }

        [Display(Name = "Other")]
        public bool MaOther { get; set; }

        [Display(Name = "ECE/Child or Human Development?")]
        public bool DocEce { get; set; }

        [Display(Name = "Education Psychology/Social Work?")]
        public bool DocEd { get; set; }

        [Display(Name = "Business/Math/Science/Health")]
        public bool DocBus { get; set; }

        [Display(Name = "Other")]
        public bool DocOther { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Current Permit Level")]
        public int Permit { get; set; }

        [Display(Name = "I have a credential")]
        public bool CredNone { get; set; }

        [Display(Name = "Administrative Services")]
        public bool CredAdmin { get; set; }

        [Display(Name = "Bilingual Specialist")]
        public bool CredBilingual { get; set; }

        [Display(Name = "Clinical/Rehabilitative Services")]
        public bool CredClinical { get; set; }

        [Display(Name = "Early Childhood Special Ed.")]
        public bool CredEarly { get; set; }

        [Display(Name = "Multiple Subject")]
        public bool CredMultiple { get; set; }

        [Display(Name = "Pupil Personnel Services")]
        public bool CredPupil { get; set; }

        [Display(Name = "Reading/Language Arts")]
        public bool CredReading { get; set; }

        [Display(Name = "School Nurse Services")]
        public bool CredSchool { get; set; }

        [Display(Name = "Single Subject")]
        public bool CredSingle { get; set; }

        [Display(Name = "Specialist Instruction")]
        public bool CredSpec { get; set; }

        [Display(Name = "Speech-Language Pathology")]
        public bool CredSpeech { get; set; }

        [Display(Name = "Other")]
        public bool CredOther { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Work Setting")]
        public int Setting { get; set; }

        //[RequiredIf("Setting", 5, ErrorMessage ="Please provide another Setting")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify Other")]
        public string SettingSpecify { get; set; }

        //[RequiredIf("FccPosition", "", ErrorMessage = "Please provide a Primary Position for either Program or Family Child Care Home")]
        [Display(Name = "Primary Position for Center")]
        public int? Position { get; set; }

        //[RequiredIf("Position", 11, ErrorMessage = "Please provide another Position")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify Other")]
        public string PositionSpecify { get; set; }

        //[RequiredIf("Position", "", ErrorMessage = "Please provide a Primary Position for either Program or Family Child Care Home")]
        [Display(Name = "Primary Position for Family Child Care Home")]
        public int? FccPosition { get; set; }

        //[RequiredIf("FccPosition", 3, ErrorMessage = "Please provide another Position")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify Other")]
        public string FccSpecify { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "City of Employment")]
        public string WorkCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "County of Employment")]
        public string WorkCounty { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(5, ErrorMessage = "Required number of characters: 5")]
        [Display(Name = "Zip Code of Employment")]
        [RegularExpression(CommonConstants.ZipRegex, ErrorMessage = "Please enter a valid zip code")]
        public string WorkZip { get; set; }

        [Display(Name ="Years in ECE field (if less than 1 year, enter 1")]
        public int TenureEce { get; set; }

        [Display(Name = "Years Employed with Current Employer")]
        public int TenureEmploy { get; set; }

        [Display(Name = "Years in Current Position with Current Employer")]
        public int TenurePosition { get; set; }

        [Display(Name = "Number of Paid Hours per Week")]
        public int HoursWeek { get; set; }

        [Display(Name = "Number of Paid Months per Year")]
        public int MonthsYear { get; set; }

        [Display(Name = "Total Number of Children Enrolled")]
        public int TotalKids { get; set; }

        [Display(Name = "Number of Children Less than One Year Old")]
        public int LessThanOne { get; set; }

        [Display(Name = "Number of Children One Year Old")]
        public int OneYear { get; set; }

        [Display(Name = "Number of Children Two Years Old")]
        public int TwoYears { get; set; }

        [Display(Name = "Number of Children Three Years Old")]
        public int ThreeYears { get; set; }

        [Display(Name = "Number of Children Four Years Old through Kindergarten")]
        public int FourYears { get; set; }

        [Display(Name = "Number of School Age Children in Before/After School Program")]
        public int SchoolAge { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Do you Care for Dual Language Learners?")]
        public int Dll { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Do you Care for Children with ISFP or IEP?")]
        public int IsfpIep { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Do you Care for Children Ages 0-36 Months?")]
        public int ZeroToThirtySixMonths { get; set; }

        [Display(Name = "Current Gross Salary per Hour")]
        public decimal? SalaryHour { get; set; }

        [Display(Name = "Current Gross Salary per Month")]
        public decimal? SalaryMonth { get; set; }

        [Display(Name = "Current Gross Salary per Year")]
        public decimal SalaryYear { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(6, ErrorMessage = "Maximum of 6 characters")]
        [Display(Name ="Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Race/Ethnicity")]
        public int Race { get; set; }

        //[RequiredIf("Race", 8, ErrorMessage = "Please provide another Race")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify Other")]
        public string RaceSpecify { get; set; }

        [Display(Name = "English")]
        public bool PlEnglish { get; set; }

        [Display(Name = "Mandarin")]
        public bool PlMandarin { get; set; }

        [Display(Name = "Russian")]
        public bool PlRussian { get; set; }

        [Display(Name = "Spanish")]
        public bool PlSpanish { get; set; }

        [Display(Name = "Tagalog")]
        public bool PlTagalog { get; set; }

        [Display(Name = "Vietnamese")]
        public bool PlViet { get; set; }

        [Display(Name = "Hmong")]
        public bool PlHmong { get; set; }

        [Display(Name = "Other")]
        public bool PlOther { get; set; }

        //[RequiredIf("PlOther", true, ErrorMessage = "Please provide another Language")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify other")]
        public string PlSpecify { get; set; }

        [Display(Name = "English")]
        public bool FlEnglish { get; set; }

        [Display(Name = "Mandarin")]
        public bool FlMandarin { get; set; }

        [Display(Name = "Russian")]
        public bool FlRussian { get; set; }

        [Display(Name = "Spanish")]
        public bool FlSpanish { get; set; }

        [Display(Name = "Tagolog")]
        public bool FlTagalog { get; set; }

        [Display(Name = "Vietnamese")]
        public bool FlViet { get; set; }

        [Display(Name = "Hmong")]
        public bool FlHmong { get; set; }

        [Display(Name = "Other")]
        public bool FlOther { get; set; }

       //[RequiredIf("FlOther", true, ErrorMessage = "Please provide another Language")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Specify other")]
        public string FlSpecify { get; set; }

        //public bool Registry { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[StringLength(9, ErrorMessage = "Required number of characters: 9")]
        //public string RegistryId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

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
        [RegularExpression(CommonConstants.ZipRegex, ErrorMessage = "Please enter a valid zip code")]
        public string MailingZip { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Email")]
        [RegularExpression(CommonConstants.EmailRegex, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Home Phone")]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a valid phone number")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Work Phone")]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a valid phone number")]
        public string WorkPhone { get; set; }

        [StringLength(50, ErrorMessage = "Maximum of 14 characters")]
        [Display(Name = "Cell Phone")]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a valid phone number")]
        public string CellPhone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "Maximum of 100 characters")]
        [Display(Name = "Employer")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Director's First Name")]
        public string DirectorFirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        [Display(Name = "Director's Last Name")]
        public string DirectorLastName { get; set; }
    }
}