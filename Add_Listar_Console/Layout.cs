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

            Console.WriteLine();
            Console.WriteLine("-- FIM DA LISTA --");
            Console.WriteLine();
            Thread.Sleep(1000);
            MenuPrincipal();
        }

        private static void AtualizarPessoa()
        {
            Console.Clear();
            Console.Write("Digite o ID da pessoa: ");
            bool tryParse = int.TryParse(Console.ReadLine(), out int idPessoa);

            if (!tryParse)
            {
                Console.Clear();
                Console.WriteLine("Digite apenas números!");
                Console.WriteLine();
                MenuPrincipal();
            }


            Pessoa pessoaEncontrada = pessoas.Find(x => x.Id == idPessoa);

            if (pessoaEncontrada != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome encontrado: {pessoaEncontrada.Nome}");
                Console.Write("Digite o novo nome: ");
                string novoNome = Console.ReadLine();

                pessoaEncontrada.SetNome(novoNome);

                Console.WriteLine();
                Console.WriteLine("Nome alterado com sucesso!");
                Thread.Sleep(1000);
                ListarPessoas();
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Pessoa não encontrada!");
                Console.WriteLine();
                MenuPrincipal();
            }
        }

        private static void DeletarPessoa()
        {
            Console.Clear();
            Console.Write("Digite o ID da pessoa: ");
            bool tryParse = int.TryParse(Console.ReadLine(), out int idPessoa);

            if (!tryParse)
            {
                Console.Clear();
                Console.WriteLine("Digite apenas números!");
                Console.WriteLine();
                MenuPrincipal();
            }

            Pessoa pessoaEncontrada = pessoas.Find(x => x.Id == idPessoa);

            if (pessoaEncontrada != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome encontrado: {pessoaEncontrada.Nome}");
                Console.WriteLine("Deseja realmente deletar?");
                Console.WriteLine();
                Console.WriteLine("1 - SIM");
                Console.WriteLine("2 - NÃO / VOLTAR");
                Console.WriteLine();
                bool tryParseDeletar = int.TryParse(Console.ReadLine(), out int opcaoDeletar);

                if (!tryParse)
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma das opções!");
                    Console.WriteLine();
                    MenuPrincipal();
                }

                switch (opcaoDeletar)
                {
                    case 1:
                        pessoas.Remove(pessoaEncontrada);
                        Console.WriteLine();
                        Console.WriteLine("Nome deletado com sucesso!");
                        Thread.Sleep(1000);
                        ListarPessoas();
                        break;

                    default:
                        Console.Clear();
                        MenuPrincipal();
                        break;
                }
                
                

                
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Pessoa não encontrada!");
                Console.WriteLine();
                MenuPrincipal();
            }
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("1 - Adicionar Pessoa");
            Console.WriteLine("2 - Listar Pessoas");
            Console.WriteLine("3 - Alterar Pessoa");
            Console.WriteLine("4 - Deletar Pessoa");
            Console.WriteLine("5 - Sair");
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
                    AtualizarPessoa();
                    break;
                case 4:
                    DeletarPessoa();
                    break;
                case 5:
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
