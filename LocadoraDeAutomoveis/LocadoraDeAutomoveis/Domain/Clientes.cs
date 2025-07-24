using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace LocadoraDeAutomoveis.Domain
{
    public class Clientes
    {
        public int Id {  get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Estado { get; set; }


        private string ConnectionString = "Server=localhost;Database=locadoradeautomoveis;Uid=root;Pwd=teste;";


        public void CadastroCliente()
        {
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

            using (var conexao = new MySqlConnection(ConnectionString))
            {
                // Abre a comunicação com o banco de dados
                conexao.Open();

                // Comando SQL para inserir os dados. Usamos parâmetros (@nome, @cpf, etc.)
                // para evitar um ataque de segurança chamado SQL Injection.
                string sql = "INSERT INTO clientes (nome, cpf, estado, data_nascimento) VALUES (@nome, @cpf, @estado, @dataNascimento)";

                // Cria o comando que será executado no banco
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    // Substitui os parâmetros (@) pelos valores que o usuário digitou
                    cmd.Parameters.AddWithValue("@nome", this.Nome);
                    cmd.Parameters.AddWithValue("@cpf", this.Cpf);
                    cmd.Parameters.AddWithValue("@estado", this.Estado);
                    cmd.Parameters.AddWithValue("@dataNascimento", this.DataNascimento);

                    // Executa o comando no banco. ExecuteNonQuery() é usado para INSERT, UPDATE e DELETE.
                    cmd.ExecuteNonQuery();
                }
            } // A conexão é fechada aqui automaticamente.

        }


    }
}
