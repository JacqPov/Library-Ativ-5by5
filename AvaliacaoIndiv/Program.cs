using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class Program
    {
        static void Main(string[] args)
        {

            Cliente cliente = new Cliente();
            Livro livro = new Livro();
            Endereco endereco = new Endereco();
            Emprestimo emprestimo = new Emprestimo();
            string cpf;
            long numerotombo;


            do
            {
                Console.WriteLine(">>>>MENU<<<<");
                Console.WriteLine("Você deseja: ");
                Console.WriteLine("1- Cadastrar Cliente");
                Console.WriteLine("2- Cadastrar Livro");
                Console.WriteLine("3- Empréstimo de Livro");
                Console.WriteLine("4- Devolução de Livro");
                Console.WriteLine("5- Relatório de Empréstimos e Devoluções");
                Console.WriteLine("0- Sair");


                string comando = Console.ReadLine();

                Console.Clear();

                switch (comando)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Informe o CPF do cliente: ");
                        cpf = Console.ReadLine();

                        if (ClienteCSV. ProcuraCPF(cpf) != -1)
                        {
                            cliente = ClienteCSV.LeituraCliente(cpf);
                            ImprimirCliente(cliente);
                        }
                        else
                        {
                            cliente = LeituraCliente(cpf);
                            ClienteCSV.SalvarCliente(cliente);
                            
                            
                        }
                       

                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Informe o ISBN: ");
                        string isbn = Console.ReadLine();

                        if (LivroCSV.ProcuraISBN(isbn) != -1)
                        {
                            livro = LivroCSV.LeituraLivro(isbn);
                            ImprimirLivro(livro);
                        }
                        else
                        {
                            livro = LeituraLivro(isbn);
                            LivroCSV.SalvarLivro(livro);
                        }
                        

                        break;
                    case "3":
                        Console.Clear();
                        ValidacaoEmprestimo();

                        break;
                    case "4":
                        Console.Clear();
                        ValidacaoDevolucao();
                        
                        break;
                    case "5":
                        Console.Clear();
                        Relatorio();

                        break;
                    case "0":
                        Finalizar();

                        break;
                }

            } while (true);

            Console.ReadKey();
        }

        static void Finalizar()
        {
            Environment.Exit(0);
        }

        static Cliente LeituraCliente(string cpf)
        {
          
            Console.WriteLine("CPF não cadastrado, insira os dados: ");

            long idcliente = new Random().Next(10, 10000);
            Console.Write("Nome :");
            string nome = Console.ReadLine();

            DateTime dataNascimento = DateTime.Parse("01/01/0001");
            do
            {
                Console.Write("Data de nascimento(dd/mm/aaaa): ");
                string dn = Console.ReadLine();

                if (!DateTime.TryParseExact(dn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                {
                    Console.WriteLine("Digite no formato especificado: dd/mm/aaaa");
                }
            } while (dataNascimento == DateTime.Parse("01/01/0001"));


            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Cliente cliente = new Cliente
            {
                IdCliente = idcliente,
                Nome = nome,
                CPF = cpf,
                DataNascimento = dataNascimento,
                Telefone = telefone
            };
            Console.WriteLine("Informe os dados do endereço do cliente: ");
            Console.Write("Logradouro: ");
            string logradouro = Console.ReadLine();
            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();
            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Estado: ");
            string estado = Console.ReadLine();
            Console.Write("CEP: ");
            string cep = Console.ReadLine();

            Endereco endereco = new Endereco
            {
                Logradouro = logradouro,
                Bairro = bairro,
                Cidade = cidade,
                Estado = estado,
                CEP = cep
            };

            Console.WriteLine("ID do cliente: " +idcliente);
            Console.WriteLine();
            return cliente;
            
        }

        static void ImprimirCliente(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine(cliente);
            Console.WriteLine();
        }


        static Livro LeituraLivro(string isbn)
        {
            Console.WriteLine("ISBN não cadastrado, insira os dados: ");

            long numtombo = new Random().Next(10, 10000);
            Console.Write("Titulo do livro :");
            string titulo = Console.ReadLine();

            DateTime dataPub = DateTime.Parse("01/01/0001");
            do
            {
                Console.Write("Data de publicação(dd/mm/aaaa): ");
                string dp = Console.ReadLine();

                if (!DateTime.TryParseExact(dp, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataPub))
                {
                    Console.WriteLine("Digite no formato especificado: dd/mm/aaaa");
                }
            } while (dataPub == DateTime.Parse("01/01/0001"));


            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Livro livro = new Livro
            {
                NumeroTombo = numtombo,
                Titulo = titulo,
                ISBN = isbn,
                Genero = genero,
                DataPublicacao = dataPub,
                Autor = autor
            };
            Console.WriteLine("Número do Tombo: " +numtombo);
            Console.WriteLine();
            return livro;
        }

        static void ImprimirLivro(Livro livro)
        {
            Console.Clear();
            Console.WriteLine(livro);
            Console.WriteLine();
        }

        static Emprestimo LeituraEmprestimo(long idcliente, long numtombo)
        {

            DateTime dataemprest = DateTime.Now;

            DateTime datadevo = DateTime.Parse("01/01/0001");
            do
            {
                Console.Write("Data da devolução(dd/mm/aaaa): ");
                string dd = Console.ReadLine();

                if (!DateTime.TryParseExact(dd, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datadevo))
                {
                    Console.WriteLine("Digite no formato especificado: dd/mm/aaaa");
                }
            } while (datadevo == DateTime.Parse("01/01/0001"));
           
            

            Emprestimo emprestimo = new Emprestimo
            {
                IdCliente = idcliente,
                NumeroTombo = numtombo,
                DataEmprestimo = dataemprest,
                DataDevolucao = datadevo,
                StatusEmprestimo = 1
            };
           
            Console.WriteLine();
            EmprestimoCSV.SalvarEmprestimo(emprestimo);
            return emprestimo;
        }

       
        public static void LeituraDevolucao()
        {

            DateTime dataDevo = DateTime.Parse("01/01/0001");
            do
            {
                Console.Write("Data da devolução(dd/mm/aaaa): ");
                string dd = Console.ReadLine();

                if (!DateTime.TryParseExact(dd, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDevo))
                {
                    Console.WriteLine("Digite no formato especificado: dd/mm/aaaa");
                }
            } while (dataDevo == DateTime.Parse("01/01/0001"));

            int dias = 0;
            const double multa = 0.10;

            if (DateTime.Now > dataDevo)
            {
                dias = DateTime.Now.Day - dataDevo.Day;
            }

        

            double totalmulta = 0.0;

            if (dias > 0)
            {
                totalmulta = dias * multa;
            }

            Console.WriteLine("O total da multa a pagar é "+totalmulta);
        }
     
        
        public static bool ValidacaoEmprestimo()
        {
            long numerotombo;
            string cpf;
            Cliente cliente;

            Console.WriteLine("Informe o Número do Tombo do Livro: ");
            numerotombo = long.Parse(Console.ReadLine());

            if (EmprestimoCSV.ProcuraNumeroTombo(numerotombo) != null)
            {
                Console.WriteLine("Livro indisponível para empréstimo!!");
                return false;
            }

            Console.Write("Informe o CPF do cliente: ");
            cpf = Console.ReadLine();

            cliente = ClienteCSV.ProcuraClienteCPF(cpf);

            if (cliente != null)
            {
               
                LeituraEmprestimo(cliente.IdCliente, numerotombo);

            }
            else
            {
             
                Console.WriteLine("CPF não cadastrado!!");
                ValidacaoEmprestimo();
            }

            return true;
        }

        public static bool ValidacaoDevolucao()
        {
            long numerotombo;
            Emprestimo emprestimo;

            Console.WriteLine("Informe o Número do Tombo do Livro: ");
            numerotombo = long.Parse(Console.ReadLine());

            emprestimo = EmprestimoCSV.ProcuraNumeroTombo(numerotombo);
            if (emprestimo == null)
            {
                Console.WriteLine("Livro não encontrado para devolução!!");
                return false;
            }

          
            int dias = 0;
            const double multa = 0.10;

            if (DateTime.Now > emprestimo.DataDevolucao)
            {

                dias = (DateTime.Now - emprestimo.DataDevolucao).Days;
            }

            double totalmulta = 0.0;

            if (dias > 0)
            {
                totalmulta = dias * multa;
            }

            Console.WriteLine("O total da multa a pagar é " + totalmulta);


            EmprestimoCSV.AtualizarEmprestimo(emprestimo);

            return true;

        }

        public static void Relatorio()
        {

            List<Emprestimo> listaemprestimo = EmprestimoCSV.RecuperaEmprestimo();
            List<Livro> listalivro = LivroCSV.RecuperaLivro();
            List<Cliente> listacliente = ClienteCSV.RecuperaCliente();

            foreach (Emprestimo emprestimo in listaemprestimo)
            {
                Livro emprestimolivro = new Livro();
                Cliente emprestimocliente = new Cliente();
                foreach (Livro livro in listalivro)
                {
                    if (livro.NumeroTombo == emprestimo.NumeroTombo)
                    {
                        emprestimolivro = livro;
                        break;
                    }
                }

                foreach (Cliente cliente in listacliente)
                {
                    if (cliente.IdCliente == emprestimo.IdCliente)
                    {
                        emprestimocliente = cliente;
                        break;
                    }

                }

                Console.WriteLine($"CPF cliente {emprestimocliente.CPF} Título do livro {emprestimolivro.Titulo} Status do Empréstimo {emprestimo.StatusEmprestimo} Data do Emprestimo {emprestimo.DataEmprestimo:d} Data da Devolução {emprestimo.DataDevolucao:d}");

            }

        }
    }
}


