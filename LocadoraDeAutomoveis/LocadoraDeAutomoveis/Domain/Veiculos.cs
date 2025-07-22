using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Domain
{
    public class Veiculos
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string ano {  get; set; }
        public string tipo { get; set; }
        public bool ativo { get; set; }
        public decimal preco { get; set; }
        public DateTime ultima_atualizacao { get; set; }
    }
}
