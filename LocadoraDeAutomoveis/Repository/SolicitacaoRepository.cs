using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeAutomoveis.Domain;
using MySqlConnector;

namespace LocadoraDeAutomoveis.Repository
{
    internal class SolicitacaoRepository
    {
        private string ConnectionString = "Server=localhost;Database=locadoradeautomoveis;Uid=root;Pwd=teste;";

        public void SalvandoSolicitacao(SolicitacaoDeAlugueis solicitacaoDeAlugueis)
        {
            using (var conexao = new MySqlConnection(ConnectionString))
            {
                conexao.Open();

                string sql = @"INSERT INTO soliticaodealugueis (id_cliente, id_veiculos, data_aluguel, data_devolucao, valor_diaria, 
valor_seguro, valor_total, ultima_atualizacao) VALUES (@idCliente, @idVeiculo ,@dataAluguel, @dataDevolucao, @valorDiaria, 
@valorSeguro, @valorTotal, @ultimaAtualizacao)";


                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@idCliente", solicitacaoDeAlugueis.Id_Cliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", solicitacaoDeAlugueis.Id_Veiculo);
                    cmd.Parameters.AddWithValue("@dataAluguel", solicitacaoDeAlugueis.Data_Aluguel);
                    cmd.Parameters.AddWithValue("@dataDevolucao", solicitacaoDeAlugueis.Data_Devolucao);
                    cmd.Parameters.AddWithValue("@valorDiaria", solicitacaoDeAlugueis.Valor_Diaria);
                    cmd.Parameters.AddWithValue("@valorSeguro", solicitacaoDeAlugueis.Valor_Seguro);
                    cmd.Parameters.AddWithValue("@valorTotal", solicitacaoDeAlugueis.Valor_Total);
                    cmd.Parameters.AddWithValue("@ultimaAtualizacao", solicitacaoDeAlugueis.Ultima_Atualizacao);

                    cmd.ExecuteNonQuery();
                }

            }
        }

    }
}
