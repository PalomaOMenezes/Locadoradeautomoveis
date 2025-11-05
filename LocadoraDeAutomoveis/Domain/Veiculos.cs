using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeAutomoveis.Repository;

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

        private string ConnectionString = "Server=localhost;Database=locadoradeautomoveis;Uid=root;Pwd=teste;";


        public void MostraVeiculos()
        {

            var _veiculoRepository = new VeiculoRepository();

            try
            {
                var veiculos = _veiculoRepository.RetornaListaVeiculos();

                if (veiculos != null && veiculos.Any())
                {
                    Console.WriteLine(@"Carros disponiveis:
----------------------------");

                    foreach (var veiculo in veiculos)
                    {
                        Console.WriteLine($"- ID: {veiculo.Id}, Nome: {veiculo.Nome}, Ano: {veiculo.Ano}, Preço {veiculo.Preco}");
                    }                
                }
                else
                {
                    Console.WriteLine("Nenhum veículo disponível no momento.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os veículos.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            }     
        }

        public Veiculos BuscarCarroPorId(int id)
        {
            VeiculoRepository veiculoRepository = new VeiculoRepository();

            var carroSelecionado = veiculoRepository.RetornarCarro(id);

            return carroSelecionado;
        }
    }
}

