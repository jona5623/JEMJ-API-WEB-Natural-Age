using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace JEMJ_API_WEB_Natural_Age.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model_Natural")
        {
        }

        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Especialista> Especialista { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialista>()
                .Property(e => e.Especialidad)
                .IsFixedLength();

            modelBuilder.Entity<Especialista>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Especialista1)
                .HasForeignKey(e => e.Especialista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Paciente1)
                .HasForeignKey(e => e.Paciente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellido)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.Direccion)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .Property(e => e.Correo)
                .IsFixedLength();

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Especialista)
                .WithRequired(e => e.Persona)
                .HasForeignKey(e => e.Id_Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Paciente)
                .WithRequired(e => e.Persona)
                .HasForeignKey(e => e.Id_Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tratamiento>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Tratamiento>()
                .HasMany(e => e.Cita)
                .WithRequired(e => e.Tratamiento1)
                .HasForeignKey(e => e.Tratamiento)
                .WillCascadeOnDelete(false);
        }
    }
}
