using System.ComponentModel.DataAnnotations;

namespace CRUD_4t.Models
{
    public class Produtor
    {
        [Key]
        public int Cod_Produtor { get; set; }
        public String Nome { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
