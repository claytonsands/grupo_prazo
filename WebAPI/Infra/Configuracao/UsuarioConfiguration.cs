using Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Configuracao
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("TB_USUARIO");

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasColumnName("NOME").HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Email).HasColumnName("EMAIL").HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Permissao).HasColumnName("COD_PERMISSAO").HasColumnType("INT");
            Property(c => c.Senha).HasColumnName("SENHA").HasColumnType("VARCHAR").HasMaxLength(100);

            HasMany(it => it._Tarefas).WithRequired(it => it._Usuario).HasForeignKey(it => it.IdUsuario);
        }
    }
}
