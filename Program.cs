using System;



namespace Dio.Livros
{
    class Program
    {

        static LivrosRepository repositorio = new LivrosRepository();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {

                    case "1": 
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivros();
                        break;
                    case "3":
                        AtualizarLivros();
                        break;
					case "4":
						ExcluirLivros();
						break;
					case "5":
						VisualizarLivros();
						break;
					case "C":
						Console.Clear();
						break;

                    default:
						throw new ArgumentOutOfRangeException();
                }
                    opcaoUsuario = ObterOpcaoUsuario();   
            }
                
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

          
        public static void ExcluirLivros()
        {
            Console.Write("Digite o Id do Livro: ");
            int indeceLivros = int.Parse(Console.ReadLine());
            repositorio.Exclui(indeceLivros);

        }

        
         private static void VisualizarLivros()
		{
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			var livro = repositorio.RetornaPorId(indiceLivro);

			Console.WriteLine(livro);
		}

        private static void AtualizarLivros()
        {
            Console.Write("Digite o id do Livro: ");
			int indiceLivros = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Autor do Livro: ");
			string entradaAutor = Console.ReadLine();

			Livros atualizaLivros = new Livros(id: indiceLivros,
										genero: (Genero)entradaGenero,
    									titulo: entradaTitulo,
										ano: entradaAno,
										autor: entradaAutor);

			repositorio.Atualiza(indiceLivros, atualizaLivros);
        }
        
         private static void ListarLivros()
		{
			Console.WriteLine("Listar Livros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Livro cadastrado.");
				return;
			}

			foreach (var livros in lista)
			{
                var excluido = livros.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", livros.retornaId(), livros.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		//INSERIR 
        private static void InserirLivros()
		{
			Console.WriteLine("Inserir novo Livro");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano do Livro:  ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o Autor do LIvro: ");
			string entradaAutor = Console.ReadLine();

		Livros novoLivro = new Livros(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										autor: entradaAutor);

			repositorio.Insere(novoLivro);
		}
		//Opções para o Usuário
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Livros a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Livros");
			Console.WriteLine("2- Inserir novo Livro");
			Console.WriteLine("3- Atualizar Livro");
			Console.WriteLine("4- Excluir Livro");
			Console.WriteLine("5- Visualizar Livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

    }
}
