using System.ComponentModel.DataAnnotations;
namespace CRUD_4t.Models
{
    public class Movimentacao
    {
        [Key]
        public int Cod_movimentacao { get; set; }
        
        public int Cod_Fazenda { get; set; }
        public Fazenda Fazenda { get; set; }

        public int Cod_Produtor { get; set; }
        public Produtor Produtor { get; set; }

        public int Cod_Operacao { get; set; }
        public Operacao Operacao { get; set; }

        public String data {  get; set; }
    }
}
