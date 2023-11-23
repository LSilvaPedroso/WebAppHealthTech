using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using WebAppHealthTech.Models;

namespace WebAppHealthTech.Connections
{
    public class SqlContext : DbContext
    {
        public DbSet<AgendaModel> Agenda { get; set; }
        public DbSet<HospitalModel> Hospital { get; set; }
        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<MedicoEspecModel> MedicoEspec { get; set; }
        public DbSet<HospMedicoModel> HospMedico { get; set; }
        public DbSet<EspecialidadeModel> Especialidade { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospMedicoModel>()
                    .HasKey(cw => new { cw.MedicoId, cw.HospitalId});

            modelBuilder.Entity<HospMedicoModel>()
                .HasOne(cw => cw.HospitalModel)
                .WithMany(w => w.HospMedico)
                .HasForeignKey(cw => cw.HospitalId);

            modelBuilder.Entity<HospMedicoModel>()
                .HasOne(cw => cw.MedicoModel)
                .WithMany(c => c.HospMedico)
                .HasForeignKey(cw => cw.MedicoId);


            modelBuilder.Entity<MedicoEspecModel>()
                    .HasKey(cw => new { cw.MedicoId, cw.EspecialidadeId });

            modelBuilder.Entity<MedicoEspecModel>()
                .HasOne(cw => cw.Especialidade)
                .WithMany(w => w.MedicoEspec)
                .HasForeignKey(cw => cw.EspecialidadeId);

            modelBuilder.Entity<MedicoEspecModel>()
                .HasOne(cw => cw.Medico)
                .WithMany(c => c.MedicoEspec)
                .HasForeignKey(cw => cw.MedicoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WebAppHealthTech.Models.HospMedicoModel>? HospMedicoModel { get; set; }

        public DbSet<WebAppHealthTech.Models.MedicoEspecModel>? MedicoEspecModel { get; set; }
    }
}
