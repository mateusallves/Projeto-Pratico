using CRUD_4t.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUD_4t.Entities
{
    public class dbEntity : DbContext
    {
        public dbEntity(DbContextOptions<dbEntity> options) : base(options) { }
        public DbSet<Fazenda> Fazendas { get; set; }
        public DbSet<Produtor> Produtores { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Fazenda)
                .WithMany(f => f.Movimentacoes)
                .HasForeignKey(m => m.Cod_Fazenda);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Produtor)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(m => m.Cod_Produtor);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Operacao)
                .WithMany(o => o.Movimentacoes)
                .HasForeignKey(m => m.Cod_Operacao);
        }
    }
}
