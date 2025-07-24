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
                    Console.WriteLine("Conexão com o MySQL bem-sucedida!");

                    // Exemplo: Executando uma consulta com Dapper
                    var veiculos = connection.Query<Veiculos>("SELECT * FROM veiculos LIMIT 5");

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

    }
}
