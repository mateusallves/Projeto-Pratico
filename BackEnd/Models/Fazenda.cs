
using System.ComponentModel.DataAnnotations;

namespace CRUD_4t.Models
{
    public class Fazenda
    {
        [Key]
        public int Cod_fazenda { get; set; }
        public String Nome {  get; set; }
        public String Area_HA {  get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
    }
}
