using System;

namespace ProjetoSeriesDotNet
{
    class Program
    {
        static SerieRepositorio serieRepo = new SerieRepositorio();
        static FilmeRepositorio filmeRepo = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario;
            string menu = Menu();
            while(menu.ToUpper() != "X")
            {
                switch(menu){
                    case "1"://Filmes
                        Console.Clear();
                        opcaoUsuario = ObterOpcaoUsuario(2);
                        while(opcaoUsuario.ToUpper() != "V")
                        {
                            var lista = serieRepo.Lista();
                            switch(opcaoUsuario)
                            {
                                case "1"://Listar filmes
                                    Console.Clear();
                                    Listar(2);
                                    Console.ReadLine();
                                    break;
                                case "2"://Inserir filme
                                    Console.Clear();
                                    Inserir(2);
                                    break;
                                case "3"://Atualizar filme
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhum filme cadastrado.");
                                        Console.ReadLine();
                                        break;
                                    }else {
                                        Console.Clear();
                                    Listar(2);
                                    Atualizar(2);
                                    break;
                                    }
                                case "4"://Excluir filme
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhum filme cadastrado.");
                                        Console.ReadLine();
                                        break;
                                    }else{
                                        Console.Clear();
                                        Listar(2);
                                        Excluir(2);
                                        break;
                                    }
                                case "5"://Vizualizar filme
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhum filme cadastrado.");
                                        Console.ReadLine();
                                        break;
                                    }else{
                                        Console.Clear();
                                        Listar(2);
                                        Visualizar(2);
                                        Console.ReadLine();
                                        break;
                                    }
                                case "V"://Voltar
                                    Console.Clear();
                                    Menu();
                                    break;
                                default:
                                    Console.WriteLine("Digite uma opção válida");
                                    break;
                            }
                            Console.Clear();
                            opcaoUsuario = ObterOpcaoUsuario(2);
                        }
                        break;
                    case "2"://Séries
                        Console.Clear();
                        opcaoUsuario = ObterOpcaoUsuario(1);
                        while(opcaoUsuario.ToUpper() != "V")
                        {
                            var lista = serieRepo.Lista();
                            switch(opcaoUsuario)
                            {
                                case "1"://Listar séries
                                    Console.Clear();
                                    Listar(1);
                                    Console.ReadLine();
                                    break;
                                case "2"://Inserir série
                                    Console.Clear();
                                    Inserir(1);
                                    break;
                                case "3"://Atualizar série
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhuma série cadastrada.");
                                        Console.ReadLine();
                                        break;
                                    }else {
                                        Console.Clear();
                                    Listar(1);
                                    Atualizar(1);
                                    break;
                                    }
                                case "4"://Excluir série
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhuma série cadastrada.");
                                        Console.ReadLine();
                                        break;
                                    }else{
                                        Console.Clear();
                                        Listar(1);
                                        Excluir(1);
                                        break;
                                    }
                                case "5"://Vizualizar série
                                    if(lista.Count == 0)
                                    {
                                        Console.WriteLine("Nenhuma série cadastrada.");
                                        Console.ReadLine();
                                        break;
                                    }else{
                                        Console.Clear();
                                        Listar(1);
                                        Visualizar(1);
                                        Console.ReadLine();
                                        break;
                                    }
                                case "V"://Voltar
                                    Console.Clear();
                                    Menu();
                                    break;
                                default:
                                    Console.WriteLine("Digite uma opção válida");
                                    break;
                            }
                            Console.Clear();
                            opcaoUsuario = ObterOpcaoUsuario(1);
                        }
                            break;
                    case "3"://Listar tudo
                        Console.Clear();
                        Listar(1);
                        Listar(2);
                        Console.ReadLine();
                        break;
                    case "X"://Sair
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Digite uma opçao válida");
                        break;
                }
                Console.Clear();
                menu = Menu(); 
            }
            Console.WriteLine("Obrigada por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Filmes");
            Console.WriteLine("2 - Séries");
            Console.WriteLine("3 - Listar tudo");
            Console.WriteLine("X - Sair");

            string menu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return menu;
        }

        private static void Listar(int flag)
        {
            if(flag == 1){
                Console.WriteLine("Lista de séries: ");
                var lista = serieRepo.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach(var serie in lista)
                {
                    if(serie.retornaExcluido())
                        Console.WriteLine("#ID {0}: - {1} - Título excluido", serie.retornaId(), serie.retornaTitulo());
                    else
                        Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());

                }
            }else {
                Console.WriteLine("Lista de filmes: ");
                var lista = filmeRepo.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhum filme cadastrado.");
                    return;
                }

                foreach(var filme in lista)
                {
                    if(filme.retornaExcluido())
                        Console.WriteLine("#ID {0}: - {1} - Título excluido", filme.retornaId(), filme.retornaTitulo());
                    else
                        Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());

                }
            }
        }

        private static void Inserir(int flag)
        {
            if (flag == 1){//Série
                Console.WriteLine("Inserir nova série");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Título da série: ");
                string entradaTitulo = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento da série: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o ano de finalização da série: ");
                int entradaAnoFinal = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie novaSerie = new Serie(id: serieRepo.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            anoF: entradaAnoFinal,
                                            descricao: entradaDescricao);
                serieRepo.Insere(novaSerie);
            } else {//Filme
                Console.WriteLine("Inserir novo filme");

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Título do filme: ");
                string entradaTitulo = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme novoFilme = new Filme(id: filmeRepo.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                filmeRepo.Insere(novoFilme);
            }
        }

        private static void Atualizar(int flag)
        {
            if (flag == 1){//Série
                Console.WriteLine("Digite o Id da série a ser atualizada: ");
                int indice = int.Parse(Console.ReadLine());

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Título da série: ");
                string entradaTitulo = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento da série: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o ano de finalização da série: ");
                int entradaAnoFinal = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie serieAtualizada = new Serie(id: indice,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            anoF: entradaAnoFinal,
                                            descricao: entradaDescricao);
                serieRepo.Atualiza(indice, serieAtualizada);
            } else {//Filme
                Console.WriteLine("Digite o Id do filme a ser atualizado: ");
                int indice = int.Parse(Console.ReadLine());

                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.WriteLine("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Título do filme: ");
                string entradaTitulo = Console.ReadLine();
                Console.WriteLine("Digite o ano de lançamento do filme: ");
                int entradaAno = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme filmeAtualizado = new Filme(id: indice,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                filmeRepo.Atualiza(indice, filmeAtualizado);
            }
        }

        private static void Excluir(int flag)
        {
            if(flag == 1){
                Console.WriteLine("Digite o Id da série a ser excluída: ");
                int indice = int.Parse(Console.ReadLine());

                serieRepo.Exclui(indice);
            } else {
                Console.WriteLine("Digite o Id do filme a ser excluído: ");
                int indice = int.Parse(Console.ReadLine());

                filmeRepo.Exclui(indice);
            }
        }

        private static void Visualizar(int flag)
        {
            if(flag == 1){
                Console.WriteLine("Digite o Id da série a ser visualizada: ");
                int indice = int.Parse(Console.ReadLine());

                var serie = serieRepo.RetornaPorId(indice);
                Console.WriteLine(serie);
            }else {
                Console.WriteLine("Digite o Id do filme a ser visualizado: ");
                int indice = int.Parse(Console.ReadLine());

                var filme = filmeRepo.RetornaPorId(indice);
                Console.WriteLine(filme);
            }
        }

        private static string ObterOpcaoUsuario(int flag)
        {
            if(flag == 1){
                Console.WriteLine();
                Console.WriteLine("DIO Séries a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1 - Listar séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série");
                Console.WriteLine("V - Voltar");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            } else {
                Console.WriteLine();
                Console.WriteLine("DIO Filmes a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada: ");

                Console.WriteLine("1 - Listar filmes");
                Console.WriteLine("2 - Inserir novo filme");
                Console.WriteLine("3 - Atualizar filme");
                Console.WriteLine("4 - Excluir filme");
                Console.WriteLine("5 - Visualizar filme");
                Console.WriteLine("V - Voltar");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }
    }
}
