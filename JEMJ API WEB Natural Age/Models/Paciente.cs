namespace JEMJ_API_WEB_Natural_Age.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Cita = new HashSet<Cita>();
        }

        [Key]
        [Column("Id Paciente")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Paciente { get; set; }

        [Column("Id Persona")]
        public int Id_Persona { get; set; }

        [Column("Fecha Nacimineto")]
        public DateTime Fecha_Nacimineto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Cita { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
