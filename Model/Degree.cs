using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("tblDegree")]
    public class Degree
    {
        public Degree()
        {
            Applications = new HashSet<Application>();
        }

        [Key]
        [Column("DegreeId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Degree")]
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

    }
}
