using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Configuracao
{
    public class TarefaConfiguration : EntityTypeConfiguration<Tarefa>
    {
        public TarefaConfiguration()
        {
            ToTable("TB_TAREFAS");

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Titulo).HasColumnName("TITULO").HasColumnType("VARCHAR").HasMaxLength(100);
            Property(c => c.Conluido).HasColumnName("CONCLUIDO").HasColumnType("BIT");

            HasRequired(it => it._Usuario).WithMany(it => it._Tarefas).HasForeignKey(it => it.IdUsuario);
        }
    }
}
