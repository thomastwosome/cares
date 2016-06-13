using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("tblTeachingCredentialType")]
    public class CredentialType
    {
        public CredentialType()
        {
            Applications = new HashSet<Application>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        [Column("TeachingCredentialType")]
        public string Name { get; set; }
        public virtual ICollection<Application> Applications { get; set; }

    }
}
