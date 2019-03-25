using Dominio;
using Infra.Configuracao;
using Infra.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class GerenciadorContext : DbContext
    {
        public GerenciadorContext() : base("GerenciadorConnectionStrings")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GerenciadorContext, Configuration>());
        }

        public DbSet<Usuario> DbSetUsuario { get; set; }
        public DbSet<Tarefa> DbSetTarefa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new TarefaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
