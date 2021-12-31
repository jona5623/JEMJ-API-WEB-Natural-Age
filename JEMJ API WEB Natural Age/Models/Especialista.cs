namespace JEMJ_API_WEB_Natural_Age.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Especialista")]
    public partial class Especialista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialista()
        {
            Cita = new HashSet<Cita>();
        }

        [Key]
        [Column("Id Especialista")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Especialista { get; set; }

        [Column("Id Persona")]
        public int Id_Persona { get; set; }

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
