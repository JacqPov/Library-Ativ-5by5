using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class LivroCSV
    {
        public string Path { get; set; }

        public static int ProcuraISBN(string isbn)
        {
            string[] lines = File.ReadAllLines("LIVRO.csv");
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] livroCSV = line.Split(',');
                    if (livroCSV[0] == isbn)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static Livro LeituraLivro(string isbn)
        {
            string[] lines = File.ReadAllLines("LIVRO.csv");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] livroCSV = line.Split(',');
                if (livroCSV[0] == isbn)
                {
                    Livro livro = new Livro
                    {
                       
                        ISBN = isbn,
                        NumeroTombo = long.Parse(livroCSV[1]),
                        Titulo = livroCSV[2],
                        Genero = livroCSV[3],
                        DataPublicacao = DateTime.ParseExact(livroCSV[4], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Autor = livroCSV[5]
                       
                    };
                    return livro;
                }
            }
            return null;
        }

        public static void SalvarLivro(Livro livro)
        {
            string linelivro = $"{livro.NumeroTombo}," +
                                  $"{livro.ISBN}," +
                                  $"{livro.Titulo}," +
                                  $"{livro.Genero}," +
                                  $"{livro.DataPublicacao.ToString("dd/MM/yyyy")}," +
                                  $"{livro.Autor},";

            StreamWriter sw = File.AppendText("LIVRO.csv");
            sw.WriteLine(linelivro);
            sw.Close();
        }
        public static List<Livro> RecuperaLivro()
        {
            List<Livro> livros = new List<Livro>();

            string[] lines = File.ReadAllLines("LIVRO.csv");
            if (lines.Length > 1)
            {

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] livroCSV = line.Split(',');


                    Livro livro = new Livro
                    {

                        NumeroTombo = long.Parse(livroCSV[0]),
                        ISBN = livroCSV[1],
                        Titulo = livroCSV[2],
                        Genero = livroCSV[3],
                        DataPublicacao = DateTime.ParseExact(livroCSV[4], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Autor = livroCSV[5]

                    };


                    livros.Add(livro);
                }


            }

            return livros;

        }

    }

}
