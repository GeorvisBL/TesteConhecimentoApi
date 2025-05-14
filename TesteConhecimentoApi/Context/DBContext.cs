using Microsoft.EntityFrameworkCore;
using TesteConhecimentoApi.Models;

namespace TesteConhecimentoApi.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }


        public virtual DbSet<Contato> Contatos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(entity =>
            {
                entity.ToTable("Contato");
                entity.HasKey(e => e.Id).HasName("PK_Contato");
                entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).HasColumnName("Nome").HasColumnType("VARCHAR(50)").IsRequired();
                entity.Property(e => e.Telefone).HasColumnName("Telefone").HasColumnType("VARCHAR(17)").IsRequired();
            });
        }


    }

}
