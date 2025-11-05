using System;
using LocadoraDeAutomoveis.Repository;

namespace LocadoraDeAutomoveis.Domain
{
    public class SolicitacaoDeAlugueis
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Veiculo { get; set; }
        public DateTime Data_Aluguel { get; set; }
        public DateTime Data_Devolucao {  get; set; }
        public decimal Valor_Diaria { get; set; }
        public decimal Valor_Seguro { get; set; }
        public decimal Valor_Total {  get; set; }
        public DateTime Ultima_Atualizacao { get; set; }

        public void CadastroDaSolicicacao()
        {

            bool incluirSeguro;
            var veiculos = new Veiculos();
            var clientes = new Clientes();
            var solicitacaoRepository = new SolicitacaoRepository();

            Console.WriteLine(@"--------------------------
Selecione o carro desejado:");

            veiculos.MostraVeiculos();

            int idCarroEscolhido = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o a data que deseja pegar o veiculo: (dd/mm/aaaa)");
            var dataDigitada = Console.ReadLine();

            var data = Convert.ToDateTime(dataDigitada);


            Console.WriteLine("Por quantos dias deseja alugar? :");
            var dias = Console.ReadLine();


            int diasAlugados = Convert.ToInt32(dias);

            Console.WriteLine($"A data final é : {data.AddDays(diasAlugados).ToShortDateString()}.");
            var dataFinal = data.AddDays(diasAlugados);

        

            Console.WriteLine("Deseja adicionar o Seguro Proteção (acrescimo de 10% do valor da diaria)? (S/N)");
            string opcaoSeguro = Console.ReadLine();
            if (opcaoSeguro == "s")
            {
                incluirSeguro = true;
            }
            else
            {
                incluirSeguro = false;
            }


            Console.WriteLine("Informe o cpf");
            string cpf = Console.ReadLine();


            var cliente = clientes.ConsultarCliente(cpf);



            Console.WriteLine($"Nome : {cliente.Nome} esta correto? (S/N)");
            string validaNome = Console.ReadLine();

            if (validaNome == "n")
            {
                Console.WriteLine("Cliente nao encontrado.");
            }

            var carroSelecionado = veiculos.BuscarCarroPorId(idCarroEscolhido);

            var valorTotal = Calcular(carroSelecionado.Preco, incluirSeguro, diasAlugados);

            Console.WriteLine("Calculando valor final...");
            Thread.Sleep(2000);
            Console.WriteLine($"O valor final das suas diarias, com seguro e a taxa é: {valorTotal:C2}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Deseja efetuar a reserva? (S/N)");
            string validaReserva = Console.ReadLine();

            if (validaReserva == "s")
            {
                //Inserido dados na propriedade da classe
                this.Id_Veiculo = idCarroEscolhido;
                this.Data_Devolucao = dataFinal;
                this.Data_Aluguel = data;
                this.Valor_Diaria = carroSelecionado.Preco;
                this.Id_Cliente = cliente.Id;
                this.Valor_Total = valorTotal;              
                this.Ultima_Atualizacao = DateTime.Now;
                if (incluirSeguro == true)
                {
                    this.Valor_Seguro = ValorSeguro(carroSelecionado.Preco, diasAlugados);
                }

                solicitacaoRepository.SalvandoSolicitacao(this);

                Console.WriteLine("Obrigada por confiar na PopCar! Aguarde as demais informações no seu e-mail.");
            }
            else
            {
                Console.WriteLine("Esperamos que retorne em breve.");
            }
        }

        public decimal ValorSeguro(decimal precoDiaria, decimal diasAlugados)
        {
            decimal seguro = 0;

            decimal valorAluguel = precoDiaria * diasAlugados;

                // Se for verdade, calculamos e SOMAMOS o acréscimo ao valor final.
                seguro = valorAluguel * 0.10m;
                
            return seguro;
        }


        public decimal Calcular(decimal precoDiaria, bool incluirSeguro, int diasAlugados)
        {
            decimal valorFinal = 0;
            decimal acrescimo = 0;

            decimal taxa = 150;

            decimal valorAluguel = precoDiaria * diasAlugados;
            
            if (incluirSeguro == true)
            {
                // Se for verdade, calculamos e SOMAMOS o acréscimo ao valor final.
                acrescimo = valorAluguel * 0.10m;
                valorFinal = valorFinal + acrescimo;
            }

            valorFinal = valorAluguel + acrescimo + taxa;

            return valorFinal;
        }
    }
}
