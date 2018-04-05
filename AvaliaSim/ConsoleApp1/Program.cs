using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeEventSync objsync = new ConsumeEventSync();
            int opcao;
            do
            {
                Console.WriteLine("[ 1 ] Listar Todas as Avaliações.");
                Console.WriteLine("[ 2 ] Buscar uma Avaliação.");
                Console.WriteLine("[ 3 ] Add uma Avaliação.");
                Console.WriteLine("[ 4 ] Editar uma Avaliação.");
                Console.WriteLine("[ 5 ] Deletar uma Avaliação.");
                Console.WriteLine("[ 6 ] Sair do Software");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        imprimeTodos();
                        break;
                    case 2:
                        buscarPorNome();
                        break;
                    case 3:
                        criar();
                        break;
                    case 4:
                        editar();
                        break;
                    case 5:
                        deletar();
                        break;
                    default:
                        saiPrograma();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
        }

        private static void imprimeTodos()
        {

            ConsumeEventSync syncGet = new ConsumeEventSync();
            syncGet.GetAllEventData();

            fim();
        }

        private static void buscarPorNome()
        {
            Console.Write("Digite o nome ou parte dele:");
            String nome = Console.ReadLine();

            ConsumeEventSync syncSearch = new ConsumeEventSync();
            syncSearch.GetAllEventData_ByEventID(nome); //Get All Events Records By ID

            fim();
        }

        private static void saiPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Bye Bye, vc saiu do Programa. Clique qq tecla para sair...");
            Console.ReadLine();
        }

        private static void criar()
        {
            AddAvaliacao avaliacao = new AddAvaliacao();

            Console.Write("Digite [ 1 ] para Produto e [ 2 ] para Serviço: ");
            int tipo = Int32.Parse(Console.ReadLine());

            if (tipo == 1)
            {
                Console.Write("Nome: ");
                avaliacao.nome = Console.ReadLine();
                Console.Write("Cidade: ");
                avaliacao.cidade = Console.ReadLine();
                Console.Write("Estado (Ex: RJ): ");
                avaliacao.estado = Console.ReadLine();
                avaliacao.tipo = "Produto";
            }
            else
            {
                Console.Write("Nome: ");
                avaliacao.nome = Console.ReadLine();
                Console.Write("Cidade: ");
                avaliacao.cidade = Console.ReadLine();
                Console.Write("Estado (Ex: RJ): ");
                avaliacao.estado = Console.ReadLine();
                avaliacao.tipo = "Serviço";
            }

            ConsumeEventSync syncAdd = new ConsumeEventSync();
            syncAdd.PostEvent_data(avaliacao); //Adding Event 
            fim();
        }

        private static void editar()
        {
            Avaliacao avaliacao = new Avaliacao();
            Console.Write("Digite o id da Avaliação: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.Write("Novo nome: ");
            avaliacao.nome = Console.ReadLine();
            Console.Write("Nova cidade: ");
            avaliacao.cidade = Console.ReadLine();
            Console.Write("Novo estado (ex: RJ): ");
            avaliacao.estado = Console.ReadLine();

            ConsumeEventSync syncEdit = new ConsumeEventSync();
            syncEdit.PutEvent_data(id, avaliacao); //Update Event
        }

        private static void deletar()
        {
            Console.Write("Digite o id da avaliação para apagar: ");
            int id = Int32.Parse(Console.ReadLine());

            ConsumeEventSync asycDelete = new ConsumeEventSync();
            asycDelete.DeleteEvent_data(id); //Delete Event

            Console.WriteLine("Item Provávelmente apagado.");
            fim();
        }

        private static void fim()
        {
            Console.WriteLine("FIM...");
            Console.WriteLine("Tecle para continuar...");
            Console.ReadLine();
        }
    }

}
