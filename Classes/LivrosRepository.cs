
using System;
using System.Collections.Generic;
using Dio.Livros.Interfaces;



namespace Dio.Livros
{
    public class LivrosRepository : IRepository<Livros>
    {
                private List<Livros> listaLivros = new List<Livros>();
		public void Atualiza(int id, Livros objeto)
		{
			listaLivros[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaLivros[id].Excluir();
		}

		public void Insere(Livros objeto)
		{
			listaLivros.Add(objeto);
		}

		public List<Livros> Lista()
		{
			return listaLivros;
		}

		public int ProximoId()
		{
			return listaLivros.Count;
		}

		public Livros RetornaPorId(int id)
		{
			return listaLivros[id];
		}
	}
    
}