using DIO.Series.Classes;
using System;
using System.Linq;
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
		static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
		static string opcaoMenuPrincipal;
        static void Main(string[] args)
        {
			opcaoMenuPrincipal = Menu.MenuPrincipal();
			while (opcaoMenuPrincipal.ToUpper() != "X")
			{   
				if(opcaoMenuPrincipal != "1" && opcaoMenuPrincipal != "2" && opcaoMenuPrincipal.ToUpper() != "X")
                {
                    Console.Clear();
					InformarMsg();
					opcaoMenuPrincipal = Menu.MenuPrincipal();
					continue;
				}
                string opcaoUsuario = Menu.ObterOpcaoUsuario(opcaoMenuPrincipal);

                while (opcaoUsuario.ToUpper() != "X" && opcaoUsuario.ToUpper() != "V")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            if (opcaoMenuPrincipal == "1")
                            {
                                Menu.ListarSeries(serieRepositorio);
                            }
                            else
                            {
								Menu.ListarFilmes(filmeRepositorio);
                            }
                            break;
                        case "2":
                            Inserir();
                            break;
                        case "3":
                            Atualizar();
                            break;
                        case "4":
                            Excluir();
                            break;
                        case "5":
                            Visualizar();
                            break;						
                        case "C":
                            Console.Clear();
                            break;						
                        default:
                            Console.WriteLine("Escolha um opção válida!");
							break;
							//throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario = Menu.ObterOpcaoUsuario(opcaoMenuPrincipal);
                }

                if (opcaoUsuario == "X")
                {
                    DespedirMsg();
					break;
                    Console.ReadLine();
				}else if(opcaoUsuario == "V")
                {
					Console.Clear();
                }
				opcaoMenuPrincipal = Menu.MenuPrincipal();
			}
			DespedirMsg();
		}

        private static void Excluir()
		{
			Console.Write("Digite o id: ");
			int indice = int.Parse(Console.ReadLine());

            if (opcaoMenuPrincipal == "1")
            {
                serieRepositorio.Exclui(indice);
            }
            else
            {
				filmeRepositorio.Exclui(indice);
            }
		}

        private static void Visualizar()
		{
			Console.Write("Digite o id : ");
			int indice = int.Parse(Console.ReadLine());

            if (opcaoMenuPrincipal == "1")
            {
                var serie = serieRepositorio.RetornaPorId(indice);

                Console.WriteLine(serie);
            }
            else
            {
				var filme = filmeRepositorio.RetornaPorId(indice);
                Console.WriteLine(filme);
            }
		}
		private static void Inserir()
		{
			
			string tipo;
			if(opcaoMenuPrincipal == "1")
            {
				tipo = "Série";
            }
            else
            {
				tipo = "Filme";
            }
			Console.WriteLine($"Inserir nova {tipo}");
			Menu.ListaGenero();

			int entradaGenero = GetNumeroInteiro();

			Console.Write($"Digite o Título da {tipo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano de Início da {tipo}: ");
			int entradaAno = GetNumeroInteiro();

			Console.Write($"Digite a Descrição da {tipo}: ");
			string entradaDescricao = Console.ReadLine();

            if (opcaoMenuPrincipal == "1")
            {
                Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);

                serieRepositorio.Insere(novaSerie);
            }
            else
            {
				Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
											   genero: (Genero)entradaGenero,
											   titulo: entradaTitulo,
											   ano: entradaAno,
											   descricao: entradaDescricao);

				filmeRepositorio.Insere(novoFilme);
			}
		}
		private static void Atualizar()
		{		

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			string tipo;
			if (opcaoMenuPrincipal == "1")
			{
				tipo = "Série";
			}
			else
			{
				tipo = "Filme";
			}

			Console.Write($"Digite o id da {tipo}: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			Console.WriteLine($"Inserir nova {tipo}");
			Menu.ListaGenero();

			int entradaGenero = GetNumeroInteiro();

			Console.Write($"Digite o Título da {tipo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano de Início da {tipo}: ");
			int entradaAno = GetNumeroInteiro();

			Console.Write($"Digite a Descrição da {tipo}: ");
			string entradaDescricao = Console.ReadLine();
			if (tipo == "1")
			{
				Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				serieRepositorio.Atualiza(indiceSerie, atualizaSerie);
			}
			else
			{
				Filme atualizaFilme = new Filme(id: indiceSerie,
											   genero: (Genero)entradaGenero,
											   titulo: entradaTitulo,
											   ano: entradaAno,
											   descricao: entradaDescricao);

				filmeRepositorio.Insere(atualizaFilme);
			}
            
        }  		
		
		//Valida se a entrada de dados é um número	
		private static int GetNumeroInteiro()
		{   
			do
			{
				string entradaTeclado = Console.ReadLine();
				if (entradaTeclado.Any(c => char.IsDigit(c)))
				{
					int numero = int.Parse(entradaTeclado);
					return numero;
                }
                else
                {
					InformarMsg();
                    continue;
                }

            } while (true);
		}
		private static void DespedirMsg()
        {
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
		}
		private static void InformarMsg()
        {
			Console.WriteLine("Digite uma opção válida!");
		}
    }
}
