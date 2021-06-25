using System;
using System.Collections.Generic;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                 {
                    case "1":
                    ListaSeries();
                    break;
                   
                    case "2":
                    InserirSerie();
                    break;
                
                     case "3":
                    AtualizarSerie();
                    break;
                   
                    case "4":
                    ExcluirUmaSerie();
                    break;
                   
                    case "5":
                    VisuarSerie();
                    break;
                   
                    case "C":
                    
                    Console.Clear();
                    break;

                    default:
                     throw new ArgumentOutOfRangeException();           

                 }
                  
                 opcaoUsuario =  ObterOpcaoUsuario();

            }
            
            Console.WriteLine("Obrigado por utilizar a DIO-Séries");
            Console.ReadLine();

        }

        private static void VisuarSerie()
        {
            Console.WriteLine("Digite o Id/Indice da Série que deseja visualizar");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirUmaSerie()
        {
            Console.WriteLine("Digite o Id/Indice da série que deseja Excluir:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

            

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série que deseja atualizar:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                 Console.WriteLine("Digite o Gênero do filme de acordo com as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digte uma descrição/Sinopse da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
									    genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            
            repositorio.Atualizacao(indiceSerie, atualizaSerie);


            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Insira uma nova Série:");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetNames(typeof(Genero)));
            }
            Console.WriteLine("Digite o Gênero do filme de acordo com as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digte uma descrição/Sinopse da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
									    genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void ListaSeries()
        {
           Console.WriteLine("Listar Séries");

            var Lista = repositorio.Lista();

            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série Cadastrada! Por favor cadastre");
                return;
            }
            foreach(var serie in Lista)
            {
                Console.WriteLine("#Id {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }   

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a DIO-Séries!!");
            Console.WriteLine("Por favor selecione sua opção:");

            Console.WriteLine("1 - Listar todas as séries");
            Console.WriteLine("2 - Inserir uma nova Série");
            Console.WriteLine("3 - Atualizar uma série do nosso catálogo");
            Console.WriteLine("4 - Excluir uma série");
            Console.WriteLine("5 - Visualizar a série escolhida");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Finalizar e Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
