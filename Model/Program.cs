using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("tblProgramType")]
    public class Program
    {
        public Program()
        {
            Applications = new HashSet<Application>();
        }

        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("ProgramType")]
        public string Name { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
