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
    public class VeiculoRepository
    {
        string connectionString = "Server=localhost;Database=locadoradeautomoveis;Uid=root;Pwd=teste;";

        public List<Veiculos> RetornaListaVeiculos()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Exemplo: Executando uma consulta com Dapper
                    var veiculos = connection.Query<Veiculos>("SELECT * FROM veiculos");

                    return veiculos.ToList();
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

        public Veiculos RetornarCarro(int id)
        {
            Veiculos carroSelecionado = null;

            using (var connection = new MySqlConnection(connectionString))
            {  
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Exemplo: Executando uma consulta com Dapper
                    carroSelecionado = connection.QueryFirstOrDefault<Veiculos>("SELECT * FROM Veiculos Where Id = @Id", new { Id = id });

                    
                }
                catch (Exception ex) // Nomeamos a exceção como 'ex',é uma variavel do tipo Exception, que captura o erro que der.
                {
                    // Agora a mensagem de erro real será exibida em ex.message, após a minha msg.
                    Console.WriteLine($"Ocorreu um erro ao buscar o veículo. {ex.Message}");               
                }               
            }
            return carroSelecionado;
        }
    }
}
