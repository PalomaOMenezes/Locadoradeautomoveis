using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LocadoraDeAutomoveis.Domain;
using MySqlConnector;

namespace LocadoraDeAutomoveis.Repository
{
    public class ClienteRepository
    {
        private string ConnectionString = "Server=localhost;Database=locadoradeautomoveis;Uid=root;Pwd=teste;";


        public void CadastroCliente(Clientes cliente)
        {
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
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);

                    // Executa o comando no banco. ExecuteNonQuery() é usado para INSERT, UPDATE e DELETE.
                    cmd.ExecuteNonQuery();
                }
            } // A conexão é fechada aqui automaticamente.

        }

        public Clientes ConsultarCliente(string cpf)
        {

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Exemplo: Executando uma consulta com Dapper
                    var cliente = connection.QueryFirstOrDefault<Clientes>("SELECT * FROM Clientes Where Cpf = @Cpf", new { Cpf = cpf });

                    return cliente;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao conectar: {ex.Message}");
                    return null;
                }
                finally
                {
                    connection.Clone();
                }
            }
        }
    }

}

