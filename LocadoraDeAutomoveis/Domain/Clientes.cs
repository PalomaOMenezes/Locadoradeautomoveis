using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeAutomoveis.Repository;
using MySqlConnector;

namespace LocadoraDeAutomoveis.Domain
{
    public class Clientes
    {
        public int Id {  get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string Estado { get; set; }


       public void CadastrarCliente()
        {

            ClienteRepository clienteRepository = new ClienteRepository();

            Console.WriteLine(@"--Cadastro do cliente--
Preencha as informações abaixo:");


            Console.WriteLine("CPF: ");
            this.Cpf = Console.ReadLine();
            Console.WriteLine("Nome: ");
            this.Nome = Console.ReadLine();
            Console.WriteLine("Data de nascimento: ");
            this.DataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Estado: ");
            this.Estado = Console.ReadLine();

            clienteRepository.CadastroCliente(this);
        }

        public Clientes ConsultarCliente(string cpf)
        {
            ClienteRepository clienteRepository = new ClienteRepository();

            var cliente = clienteRepository.ConsultarCliente(cpf);

            return cliente;

        }
    }
}
