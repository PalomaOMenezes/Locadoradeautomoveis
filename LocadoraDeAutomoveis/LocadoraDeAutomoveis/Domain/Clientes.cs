using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Domain
{
    public class Clientes
    {
        public int id {  get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public DateOnly data_nascimento { get; set; }
        public string estado { get; set; }
    }
}
