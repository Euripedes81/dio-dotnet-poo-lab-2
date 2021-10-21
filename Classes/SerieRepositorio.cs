using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
		public List<Serie> ListaSerieGenero(int idCategoria)
        {   
			//Lista série por categoria

			List<Serie> seriesPorCategoria = new List<Serie>();
			Genero genero = (Genero)idCategoria;
			foreach(var serie in listaSerie)
            {
				if(Enum.Equals(serie.RetornaGenero(), genero))
                {
					seriesPorCategoria.Add(serie);
                }
            }
			return seriesPorCategoria;
		}
	}
}