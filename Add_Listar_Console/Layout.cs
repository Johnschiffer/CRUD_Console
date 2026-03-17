using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Add_Listar_Console
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        //private static int opcao = 0;
        private static void AddPessoa()
        {
            Console.Clear();
            Pessoa pessoa = new Pessoa();

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            pessoa.SetNome(nome);

            pessoas.Add(pessoa);
            Console.WriteLine("Cadastrado com sucesso!");
            Thread.Sleep(500);
            Console.WriteLine();
            MenuPrincipal();
        }

        private static void ListarPessoas()
        {
            Console.Clear();
            Console.WriteLine("-- LISTA DE PESSOAS --");
            Console.WriteLine();
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"{pessoa.Id} - {pessoa.GetNome()}");
            }
            Console.WriteLine("-- FIM DA LISTA --");
            Console.WriteLine();
            Thread.Sleep(1000);
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("1 - Adicionar Pessoa");
            Console.WriteLine("2 - Listar Pessoas");
            Console.WriteLine("3 - Sair");
            //int opcao = Convert.ToInt32(Console.ReadLine());

            bool tryParse = int.TryParse(Console.ReadLine(), out int opcao);

            if (!tryParse)
            {
                Console.Clear();
                Console.WriteLine("Digite apenas números!");
                MenuPrincipal();
            }

            switch (opcao)
            {
                case 1:
                    AddPessoa();
                    break;
                case 2:
                    ListarPessoas();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Invalida!");
                    Thread.Sleep(500);
                    MenuPrincipal();
                    break;
            }


        }

    }
}
