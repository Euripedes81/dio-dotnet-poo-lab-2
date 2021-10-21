using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Classes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        List<Filme> listaFilme = new List<Filme>();
        public void Atualiza(int id, Filme filme)
        {
            listaFilme[id] = filme;
        }

        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filme filme)
        {
            listaFilme.Add(filme);
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
        }
        public List<Filme> ListaFilmeGenero(int idCategoria)
        {
            //Lista filme por categoria

            List<Filme> filmePorCategoria = new List<Filme>();
            Genero genero = (Genero)idCategoria;
            foreach (var filme in listaFilme)
            {
                if (Enum.Equals(filme.RetornaGenero(), genero))
                {
                    filmePorCategoria.Add(filme);
                }
            }
            return filmePorCategoria;
        }
    }
}
