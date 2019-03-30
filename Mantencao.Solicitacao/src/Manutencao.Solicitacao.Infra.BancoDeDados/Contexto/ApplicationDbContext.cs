﻿using System.Threading.Tasks;
using Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao;
using Microsoft.EntityFrameworkCore;

namespace Manutencao.Solicitacao.Infra.BancoDeDados.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<SolicitacaoDeManutencao> SolicitacaoesDeManutencao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .ToTable("SolicitacaoDeManutecao");
            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .OwnsOne(p => p.Solicitante);
            modelBuilder.Entity<SolicitacaoDeManutencao>()
                .OwnsOne(p => p.Contrato);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
