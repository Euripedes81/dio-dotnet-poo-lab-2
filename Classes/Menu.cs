using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Classes
{
    public class Menu
    {
		public static void ListarSeries(SerieRepositorio repositorio)
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}
			Console.WriteLine("----------------------------------");
			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();				
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));				
			}
			Console.WriteLine("----------------------------------");
		}
		public static void ListarPorGenero(SerieRepositorio repositorio, int idGenero)
		{
			Genero genero = (Genero)idGenero;
			Console.WriteLine();
			Console.WriteLine($"Listar séries pelo gênero - {genero}");

			var lista = repositorio.ListaSerieGenero(idGenero);

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série com este gênero cadastrada.");
				return;
			}
			Console.WriteLine("----------------------------------");
			foreach (var serie in lista)
			{				
				var excluido = serie.retornaExcluido();				
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));				
			}
			Console.WriteLine("----------------------------------");
		}
		public static void ListarPorGenero(FilmeRepositorio repositorio, int idGenero)
		{
			Genero genero = (Genero)idGenero;
			Console.WriteLine();
			Console.WriteLine($"Listar filmes pelo gênero - {genero}");

			var lista = repositorio.ListaFilmeGenero(idGenero);

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma filme com este gênero cadastrado.");
				return;
			}
			Console.WriteLine("----------------------------------");
			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();				
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));				
			}
			Console.WriteLine("----------------------------------");
		}
		public static void ListarFilmes(FilmeRepositorio repositorio)
		{
			Console.WriteLine();
			Console.WriteLine("Listar Filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}
			Console.WriteLine("--------------------");
			foreach (var filme in lista)
			{
				var excluido = filme.retornaExcluido();				
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));				
			}
			Console.WriteLine("--------------------");
		}
		public static void ListaGenero()
        {
			Console.WriteLine("--------------------");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{				
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));				
			}
			Console.WriteLine("--------------------");
			Console.Write("Digite o gênero entre as opções acima: ");			
		}
		public static string ObterOpcaoUsuario(string escolhaTipo)
		{
			string tipo = "";
            switch (escolhaTipo)
            {
                case "1":
                    tipo = "Series";
                    break;
                case "2":
                    tipo = "Filmes";
                    break;
                default:
					//Console.WriteLine("Escolha uma opção válida");
					break;
            }
			Console.WriteLine();
			Console.WriteLine("-------------------------------------");
			Console.WriteLine($"DIO Menu - {tipo}");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine($"1- Listar {tipo}");
			Console.WriteLine($"2- Inserir {tipo}");
			Console.WriteLine($"3- Atualizar {tipo}");
			Console.WriteLine($"4- Excluir {tipo}");
			Console.WriteLine($"5- Visualizar {tipo}");
			Console.WriteLine($"6- Listar por gênero {tipo}");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("V- Voltar ao menu anterior");
			Console.WriteLine("X- Sair");
			Console.WriteLine("-------------------------------------");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		public static string MenuPrincipal()
        {
            Console.WriteLine("-------------------------------------");
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            Console.WriteLine("Menu Principal");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Menu séries");
			Console.WriteLine("2- Menu filmes");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine("-------------------------------------");
			string opcao = Console.ReadLine().ToUpper();
			return opcao;
		}

	}
}
