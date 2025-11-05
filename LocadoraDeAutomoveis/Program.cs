using System.ComponentModel.Design;
using LocadoraDeAutomoveis.Domain;
using LocadoraDeAutomoveis.Repository;

namespace LocadoradeAutomoveis
{
    public class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {

            bool exit = true;
            
            while (exit == true)
            {             
                Console.WriteLine(@"---------------------------------------------
Bem-vindo a PopCar. Sua melhor escolha para locação do seu veiculo!
---------------------------------------------

É novo por aqui? Selecione a opção 1 para se cadastrar.
Se você ja tem cadastro, pode selecionar a opção 2 para fazer a sua reserva do veiculo.
Ou aperte 0 para sair do programa.");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Clientes cliente = new Clientes();
                            cliente.CadastrarCliente();
                            break;

                        case 2:
                            var solicitacao = new SolicitacaoDeAlugueis();
                            solicitacao.CadastroDaSolicicacao();
                            break;

                        case 0:
                            exit = false;
                            Console.WriteLine("Obrigado por utilizar a PopCar. Volte sempre!");
                            return;

                        default:
                            Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                            Console.ReadKey(); // Espera o usuário pressionar uma tecla.
                            Menu(); // Chama o menu novamente.
                            break;
                    }
                }

                else
                {
                    // 3. SE A CONVERSÃO FALHAR (usuário digitou texto ou nada), executa isso
                    Console.WriteLine("Entrada inválida! Você deve digitar um número. Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    Menu(); // Chama o menu novamente
                }
            }
        }
    };
};