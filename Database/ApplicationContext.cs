using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API
            #region Tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("Regiones");
            modelBuilder.Entity<Tipo>().ToTable("Tipos");
            #endregion

            #region Primary Key
            modelBuilder.Entity<Pokemon>().HasKey(Pokemon => Pokemon.Id);
            modelBuilder.Entity<Region>().HasKey(Region => Region.Id);
            modelBuilder.Entity<Tipo>().HasKey(Tipo => Tipo.Id);
            #endregion

            #region Relationship
            #region Regiones
            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(Region => Region.Pokemons)
                .WithOne(Pokemon => Pokemon.Region)
                .HasForeignKey(Pokemon => Pokemon.RegionId).OnDelete(DeleteBehavior.ClientCascade);

            #endregion

            #region Tipo Primario
            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemon>(Tipo => Tipo.PokemonsPri)
                .WithOne(Pokemon => Pokemon.TipoPri)
                .HasForeignKey(Pokemon => Pokemon.TipoPriId).OnDelete(DeleteBehavior.ClientCascade);


            #endregion

            #region Tipo Secundario
            modelBuilder.Entity<Tipo>()
                .HasMany<Pokemon>(Tipo => Tipo.PokemonsSec)
                .WithOne(Pokemon => Pokemon.TipoSec)
                .HasForeignKey(Pokemon => Pokemon.TipoSecId).OnDelete(DeleteBehavior.ClientCascade);
            #endregion

            #endregion

            #region Property configuration
            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(Pokemon => Pokemon.Name)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(Pokemon => Pokemon.ImageUrl)
                .IsRequired();
 

            #endregion
            #region Tipo
            modelBuilder.Entity<Tipo>()
                .Property(Tipo => Tipo.Name)
                .IsRequired();

            #endregion
            #region Region
            modelBuilder.Entity<Region>()
                .Property(Region => Region.Name)
                .IsRequired();
            #endregion
            #endregion



        }




    }
}
