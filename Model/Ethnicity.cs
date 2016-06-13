using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("tblRaceEthnicity")]
    public class Ethnicity
    {
        public Ethnicity()
        {
            Applications = new HashSet<Application>();
        }

        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("RaceEthnicity")]
        [Display(Name = "How do you identify your Race/Ethnicity?")]
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
