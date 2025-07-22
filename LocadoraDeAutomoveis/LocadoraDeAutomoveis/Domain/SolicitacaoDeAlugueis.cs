using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Domain
{
    public class SolicitacaoDeAlugueis
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_veiculo { get; set; }
        public DateTime data_aluguel { get; set; }
        public DateTime data_devolucao {  get; set; }
        public decimal valor_diaria { get; set; }
        public decimal valor_seguto { get; set; }
        public decimal valor_total {  get; set; }
        public DateTime ultima_atualizacao { get; set; }
    }
}
