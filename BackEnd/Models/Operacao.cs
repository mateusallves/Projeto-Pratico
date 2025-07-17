using System.ComponentModel.DataAnnotations;

namespace CRUD_4t.Models
{
    public class Operacao
    {
        [Key]
        public int Cod_Operacao {  get; set; }
        public String Descricao { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
