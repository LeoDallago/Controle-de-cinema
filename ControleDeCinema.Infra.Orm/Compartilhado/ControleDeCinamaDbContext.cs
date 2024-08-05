using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinamaDbContext : DbContext
{
   public DbSet<Filme> Filmes { get; set; }
   
   public DbSet<Sala> Salas { get; set; }
   
   public DbSet<Sessao> Sessoes { get; set; }
   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      IConfigurationRoot config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json")
         .Build();

      string connectionString = config.GetConnectionString("SqlServer");

      optionsBuilder.UseSqlServer(connectionString);
      
      base.OnConfiguring(optionsBuilder);
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Filme>(filmeBuilder =>
      {
         filmeBuilder.ToTable("TBFilme");

         filmeBuilder.Property(f => f.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

         filmeBuilder.Property(f => f.Titulo)
            .IsRequired()
            .HasColumnType("varchar(250)");

         filmeBuilder.Property(f => f.Duracao)
            .HasColumnType("varchar(250)");

         filmeBuilder.Property(f => f.Genero)
            .HasColumnType("varchar(250)");
      });

      modelBuilder.Entity<Sala>(salaBuilder =>
      {
         salaBuilder.ToTable("TBSala");

         salaBuilder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

         salaBuilder.Property(s => s.Numero)
            .IsRequired()
            .HasColumnType("varchar(10)");

         salaBuilder.Property(s => s.Capacidade)
            .IsRequired()
            .HasColumnType("int");
      });


      modelBuilder.Entity<Sessao>(sessaoBuilder =>
      {
         sessaoBuilder.ToTable("TBSessao");

         sessaoBuilder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

         sessaoBuilder.Property(s => s.Filme)
            .IsRequired()
            .HasColumnType("varchar(250)");

         sessaoBuilder.Property(s => s.Sala)
            .IsRequired()
            .HasColumnType("varchar(250)");

         sessaoBuilder.Property(s => s.HorarioDeInicio)
            .IsRequired()
            .HasColumnType("varchar(100)");
      });
      base.OnModelCreating(modelBuilder);
   }
}