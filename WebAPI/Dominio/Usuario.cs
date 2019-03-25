using Dominio.Enumeradores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Permissao Permissao { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Tarefa> _Tarefas { get; set; }

        
    }
}
