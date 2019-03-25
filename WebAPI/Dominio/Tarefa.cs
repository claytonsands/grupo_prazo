namespace Dominio
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Conluido { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario _Usuario { get; set; }
    }
}
