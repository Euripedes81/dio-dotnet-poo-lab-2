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

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		public static void ListarFilmes(FilmeRepositorio repositorio)
		{
			Console.WriteLine("Listar Filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
				var excluido = filme.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		public static void ListaGenero()
        {
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
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
			Console.WriteLine($"DIO {tipo} a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine($"1- Listar {tipo}");
			Console.WriteLine($"2- Inserir {tipo}");
			Console.WriteLine($"3- Atualizar {tipo}");
			Console.WriteLine($"4- Excluir {tipo}");
			Console.WriteLine($"5- Visualizar {tipo}");			
			Console.WriteLine($"C- Limpar Tela");
			Console.WriteLine("V- Voltar ao menu anterior");
			Console.WriteLine("X- Sair");
			
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		public static string MenuPrincipal()
        {
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Menu séries");
			Console.WriteLine("2- Menu filmes");
			Console.WriteLine("X- Sair");
			string opcao = Console.ReadLine().ToUpper();
			return opcao;
		}

	}
}
