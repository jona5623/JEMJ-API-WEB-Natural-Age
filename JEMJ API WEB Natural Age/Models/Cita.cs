namespace JEMJ_API_WEB_Natural_Age.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cita")]
    public partial class Cita
    {
        [Key]
        [Column("Id Cita")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Cita { get; set; }

        public int Especialista { get; set; }

        public int Paciente { get; set; }

        public int Tratamiento { get; set; }

        public DateTime Fecha { get; set; }

        public virtual Especialista Especialista1 { get; set; }

        public virtual Paciente Paciente1 { get; set; }

        public virtual Tratamiento Tratamiento1 { get; set; }
    }
}
