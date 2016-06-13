using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("tblParticipant")]
    public class Application
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214DoNotCallOverridableMethodsInConstructors")]
        public Application()
        {
            Ethnicities = new HashSet<Ethnicity>();
            Programs = new HashSet<Program>();
            Degrees = new HashSet<Degree>();
            CredentialTypes = new HashSet<CredentialType>();
        //    tblParticipantBenefits = new HashSet<tblParticipantBenefit>();
        //    tblParticipantHours = new HashSet<tblParticipantHour>();
        //    tblParticipantLanguages = new HashSet<tblParticipantLanguage>();
        //    tblParticipantProgramTypes = new HashSet<tblParticipantProgramType>();
        //    tblParticipantPZS = new HashSet<tblParticipantPZ>();
        //    tblParticipantRaces = new HashSet<tblParticipantRace>();
        }

        [Key]
        [Required(ErrorMessage = "This field is required")]
        [Column("ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("AppDate")]
        [Display(Name ="Date")]
        public DateTime DateOfApplication { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Consent")]
        [Display(Name = "Do you agree to participate in the program evaluation analyses and have you signed the consent form?")]
        public bool GaveConsent { get; set; }

        //TEACHER
        [Required(ErrorMessage = "This field is required")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(15, ErrorMessage = "Limited to 15 chars")]
        public string FirstName { get; set; }

        [Column("MiddleInitial")]
        [Display(Name = "M.I.")]
        [StringLength(1, ErrorMessage = "Limited to 1 char")]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Limited to 20 chars")]
        public string LastName { get; set; }

        [Column("PreviousLastName")]
        [Display(Name = "Previous Last Name")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string PreviousLastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("BirthDate")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        [Column("CityBorn")]
        [Display(Name = "City of Birth")]
        public string CityOfBirth { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("County")]
        [Display(Name = "County of Participation")]
        public CountyType County { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("LastFiveSSN")]
        [Display(Name = "Last 5 Digits of SSN")]
        [StringLength(5, ErrorMessage = "Limited to 5 chars")]
        public string LastFiveSSN { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Gender")]
        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Ethnicity")]
        [Display(Name = "How do you identify your Race/Ethnicity?")]
        [StringLength(200, ErrorMessage = "Limited to 200 chars")]
        public string Ethnicity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("PrimaryLanguage")]
        [Display(Name = "What is your Primary Language?")]
        public LanguageType PrimaryLanguage { get; set; }

        [Column("HomeAddress1")]
        [Display(Name = "Alternate Address")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string HomeAddress1 { get; set; }

        [Column("HomeAddress2")]
        [Display(Name = "Alternate Address, cont.")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string HomeAddress2 { get; set; }

        [Column("HomeAddressCity")]
        [Display(Name = "Alternate City")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string HomeAddressCity { get; set; }

        [Column("HomeAddressState")]
        [Display(Name = "Alternate State")]
        [StringLength(50)]
        public string HomeAddressState { get; set; }

        [Column("HomeAddressZip")]
        [Display(Name = "Alternate Zip Code")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.ZipRegex, ErrorMessage = "Please enter a valid zip code.")]
        public string HomeAddressZip { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("MailingAddress1")]
        [Display(Name = "Mailing Address")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string MailingAddress1 { get; set; }

        [Column("MailingAddress2")]
        [Display(Name = "Mailing Address, cont.")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string MailingAddress2 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("MailingAddressCity")]
        [Display(Name = "Mailing City")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string MailingAddressCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("MailingAddressState")]
        [StringLength(50)]
        [Display(Name = "Mailing State")]
        public string MailingAddressState { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("MailingAddressZip")]
        [Display(Name = "Mailing Zip Code")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.ZipRegex, ErrorMessage = "Please enter a valid zip code.")]
        public string MailingAddressZip { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("HomePhone")]
        [Display(Name = "Home Phone")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a 10-digit number.")]
        public string HomePhone { get; set; }

        [Column("CellPhone")]
        [Display(Name = "Mobile Phone")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a 10-digit number.")]
        public string CellPhone { get; set; }

        [Column("Carrier")]
        [Display(Name = "Mobile Phone Carrier")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string Carrier { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Email")]
        [Display(Name = "Email Address")]
        [StringLength(100, ErrorMessage = "Limited to 100 chars")]
        [RegularExpression(CommonConstants.EmailRegex, ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("participate1")]
        [Display(Name = "Did you participate in the Cares program between 2000 and 2010?")]
        public bool Participate1 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("participate2")]
        [Display(Name = "Have you participated in the CARES Plus Program since 2011?")]
        public bool Participate2 { get; set; }

        [Column("PriorUnits1")]
        [Display(Name = "If you have participated in CARES Plus Program since 2011, what is the total number of Early Childhood Education/Child Development (ECE/CD) units that you completed prior to entry into CARES Plus?")]
        public double? PriorUnits1 { get; set; }

        [Column("PriorUnits2")]
        [Display(Name = "If you are a first time CARES Plus Program applicant, what is the total number of Early Childhood Education/Child Development (ECE/CD) units you have completed to date?")]
        public double? PriorUnits2 { get; set; }

        //PROGRAM COMPONENT
        [Column("Core")]
        [Display(Name = "Core Program (first-time applicants must select Core)")]
        public bool Core { get; set; }

        [Column("AgeGroup")]
        [Display(Name = "Age Group for Online CLASS Training (you must be directly serving the Age Group selected)")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string AgeGroup { get; set; }

        [Column("ProgramComponentApplying")]
        [Display(Name = "?")]
        public int? ProgramComponentApplying { get; set; }

        [Column("AgeGroup2")]
        [Display(Name = "?")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string AgeGroup2 { get; set; }

        [Column("Language")]
        [Display(Name = "Language")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string Language { get; set; }


        //CURRENT WORK FACILITY
        [Required(ErrorMessage = "This field is required")]
        [Column("WorkName")]
        [Display(Name = "Name of Employer (including Site Name)")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string Site { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("WorkAddress1")]
        [Display(Name = "Site Address")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string SiteAddress1 { get; set; }

        [Column("WorkAddress2")]
        [Display(Name = "Site Address (cont.)")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string SiteAddress2 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("WorkAddressCity")]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "Limited to 50 chars")]
        public string SiteCity { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("WorkAddressState")]
        [StringLength(50)]
        [Display(Name = "State")]
        public string SiteState { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("WorkAddressZip")]
        [Display(Name = "Zip Code")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.ZipRegex, ErrorMessage = "Please enter a valid zip code.")]
        public string SiteZip { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("WorkPhone")]
        [Display(Name = "Site Phone Number")]
        [StringLength(10)]
        [RegularExpression(CommonConstants.PhoneRegex, ErrorMessage = "Please enter a 10-digit number.")]
        public string WorkPhone { get; set; }

        [Column("OperatorFirstName")]
        [Display(Name = "Director's First Name")]
        [StringLength(15, ErrorMessage = "Limited to 15 chars")]
        public string DirectorFirstName { get; set; }

        [Column("OperatorLastName")]
        [Display(Name = "Director's Last Name")]
        [StringLength(20, ErrorMessage = "Limited to 20 chars")]
        public string DirectorLastName { get; set; }

        [Column("LicenseNumber")]
        [Display(Name = "Employer Program Number (Facility License Number)")]
        [StringLength(30, ErrorMessage = "Limited to 30 chars")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("ProgramType")]
        [Display(Name = "Which best describes your child care program?")]
        [StringLength(500, ErrorMessage = "Limited to 500 chars")]
        public string ProgramType { get; set; }

        //CURRENT EMPLOYMENT
        [Required(ErrorMessage = "This field is required")]
        [Column("TimeInField")]
        [Display(Name = "Number of Years you have been employed in the ECE field?")]
        public int TimeInField { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("TimeWithCurrent")]
        [Display(Name = "Number of Years you have been employed with your current employer?")]
        public int TimeWithCurrent { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("StartDate")]
        [Display(Name = "Employment Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("AnnualSalary", TypeName = "money")]
        [Display(Name = "Estimated Annual Salary from ECE Employment")]
        public decimal? AnnualSalary { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("SettingType")]
        [Display(Name = "Setting or Program Type")]
        public SettingType SettingType { get; set; }

        [Column("PositionTitle1")]
        [Display(Name = "If you work in a Center or School-Based ECE Program, what is your Primary Position?")]
        public PositionType PositionTitle1 { get; set; }

        [Column("PositionTitle2")]
        [Display(Name = "If you work in a Family Child Care Home, what is your Primary Position?")]
        [StringLength(20, ErrorMessage = "Limited to 20 chars")]
        public string PositionTitle2 { get; set; }

        //Numbers
        [Required(ErrorMessage = "This field is required")]
        [Column("Num0To17")]
        [Display(Name = "Infants (Birth to 17 months)")]
        public int Num0To17 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Num18To35")]
        [Display(Name = "Toddlers (18 to 35 months)")]
        public int Num18To35 { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Num36Up")]
        [Display(Name = "Pre-K (36 months to Kindergarten entry)")]
        public int Num36Up { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("KinderUp")]
        [Display(Name = "Kindergarten and School Aged (must also include children 0-5 years old for CARES Plus eligibility)")]
        public int KinderUp { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("NumInProgram")]
        [Display(Name = "Number of Children in Program (not Classroom)")]
        public int NumInProgram { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("NumIEPs")]
        [Display(Name = "What is the total number of children with IFSP/IEP (Individual Family Services Plan or Individual Education Plan) in your classroom?")]
        public int NumIEPs { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("DualLanguage")]
        [Display(Name = "Do you currently care for children who are Dual Language Learners?")]
        public bool DualLanguage { get; set; }

        [Column("AddtlInfo")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Please identify any additional information that would assist in assigning an observer (e.g., bilingual classroom, substitute or floating teacher, facility is closed from November 1 to February 1 each year, children use American Sign Language, etc.)")]
        public string AddtlInfo { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("ClassroomLanguage")]
        [Display(Name = "What is the primary language you speak with children in the classroom?")]
        public LanguageType ClassroomLanguage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("CoachingLanguage")]
        [Display(Name = "For Component D applicants only, what is your language preference for coaching?")]
        public LanguageType CoachingLanguage { get; set; }

        //EDUCATION
        [Required(ErrorMessage = "This field is required")]
        [Column("LevelEducation")]
        [Display(Name = "Highest level of education attained?")]
        public EducationType LevelEducation { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("DateOfAttainment")]
        [Display(Name = "Date of Attainment")]
        public DateTime DateOfAttainment { get; set; }

        [Column("Degrees")]
        [Display(Name = "Please indicate the degree(s) you have obtained to date from an accredited college or university in ECE/CD or related field")]
        [StringLength(500, ErrorMessage = "Limited to 500 chars")]
        public string DegreesOld { get; set; }

        [Column("Field")]
        [Display(Name = "Field of Bachelor's Degree previously completed (required if applying for Component C)?")]
        [StringLength(20, ErrorMessage = "Limited to 20 chars")]
        public string Field { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("Permits")]
        [Display(Name = "Child Development Permit Held")]
        public PermitType Permits { get; set; }

        [Column("TeachingCredential")]
        [Display(Name = "Do you have a Teaching Credential?")]
        public CredentialResponseType TeachingCredential { get; set; }

        [Column("CredentialType")]
        [Display(Name = "What type(s) of credential?")]
        [StringLength(500, ErrorMessage = "Limited to 500 chars")]
        public string CredentialTypeOld { get; set; }

        //SIGNATURE
        [Required(ErrorMessage = "This field is required")]
        [Column("Signature")]
        [Display(Name = "Signature (type your full name)")]
        [StringLength(50)]
        public string Signature { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Column("SignatureDate")]
        [Display(Name = "Date")]
        public DateTime SignatureDate { get; set; }

        public virtual ICollection<Ethnicity> Ethnicities { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<CredentialType> CredentialTypes { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantBenefit> tblParticipantBenefits { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantHour> tblParticipantHours { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantLanguage> tblParticipantLanguages { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantProgramType> tblParticipantProgramTypes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantPZ> tblParticipantPZS { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblParticipantRace> tblParticipantRaces { get; set; }
    }
}
