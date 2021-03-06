namespace NewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permit")]
    public partial class Permit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
