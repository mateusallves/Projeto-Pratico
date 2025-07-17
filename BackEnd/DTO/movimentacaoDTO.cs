using System;

namespace CRUD_4t.DTO
{
    public class MovimentacaoDTO
    {
        public int Cod_movimentacao { get; set; }
        public int Cod_Fazenda { get; set; }
        public int Cod_Produtor { get; set; }
        public int Cod_Operacao { get; set; }
        public string Data { get; set; }
    }
}