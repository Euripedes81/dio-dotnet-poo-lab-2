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
                    if (opcaoMenuPrincipal.ToUpper() == "C")
                    {
						Console.Clear();
						opcaoMenuPrincipal = Menu.MenuPrincipal();
                        continue;
                    }
                    else
                    {
						InformarMsg();						
						opcaoMenuPrincipal = Menu.MenuPrincipal();
						continue;
					}
				}
				Console.Clear();
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
						case "6":
							ListarPorGenero();
							break;
                        case "C":
                            Console.Clear();
                            break;						
                        default:
							InformarMsg();
							break;
							//throw new ArgumentOutOfRangeException();
                    }

                    opcaoUsuario = Menu.ObterOpcaoUsuario(opcaoMenuPrincipal);
                }

                if (opcaoUsuario == "X")
                {
                    DespedirMsg();
					Console.ReadLine();
					break;                   
				}else if(opcaoUsuario == "V")
                {
					Console.Clear();
                }
				opcaoMenuPrincipal = Menu.MenuPrincipal();
			}
			DespedirMsg();
		}

        private static void ListarPorGenero()
        {
			string tipo;
			if (opcaoMenuPrincipal == "1")
			{
				tipo = "Série";
			}
			else
			{
				tipo = "Filme";
			}
			Console.WriteLine("--------------------");
			Console.WriteLine($"Escolha o gênero - {tipo}");
			Menu.ListaGenero();

			int entradaGenero = GetNumeroInteiro();

            if (opcaoMenuPrincipal == "1")
            {
                Menu.ListarPorGenero(serieRepositorio, entradaGenero);
            }
			else
            {
				Menu.ListarPorGenero(filmeRepositorio, entradaGenero);
			}
		}

        private static void Excluir()
		{
			Console.WriteLine("--------------------");
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
			Console.WriteLine("--------------------");
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
			Console.WriteLine($"Inserir - {tipo}");
			Menu.ListaGenero();

			int entradaGenero = GetNumeroInteiro();

			Console.Write($"Digite o Título - {tipo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano - {tipo}: ");
			int entradaAno = GetNumeroInteiro();

			Console.Write($"Digite a Descrição - {tipo}: ");
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
			string tipo;
			if (opcaoMenuPrincipal == "1")
			{
				tipo = "Série";
			}
			else
			{
				tipo = "Filme";
			}

			Console.Write($"Digite o id - {tipo}: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			Console.WriteLine($"Inserir nova {tipo}");
			Menu.ListaGenero();

			int entradaGenero = GetNumeroInteiro();

			Console.Write($"Digite o Título - {tipo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano de Início - {tipo}: ");
			int entradaAno = GetNumeroInteiro();

			Console.Write($"Digite a Descrição - {tipo}: ");
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
		
		private static int GetNumeroInteiro()
		{   //Valida se a entrada de dados é um número	
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
			Console.WriteLine("Digite uma opção válida!" + Environment.NewLine);
		}
    }
}
