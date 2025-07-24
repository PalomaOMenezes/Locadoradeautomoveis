using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Domain
{
    public class Veiculos
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Ano {  get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public decimal Preco { get; set; }
        public DateTime Ultima_Atualizacao { get; set; }
    }
}
