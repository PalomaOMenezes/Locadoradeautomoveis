using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Domain
{
    public class SolicitacaoDeAlugueis
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Veiculo { get; set; }
        public DateTime Data_Aluguel { get; set; }
        public DateTime Data_Devolucao {  get; set; }
        public decimal Valor_Diaria { get; set; }
        public decimal Valor_Seguto { get; set; }
        public decimal Valor_Total {  get; set; }
        public DateTime Ultima_Atualizacao { get; set; }
    }
}
