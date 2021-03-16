using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class EmprestimoCSV
    {
        public string Path { get; set; }



        public static Emprestimo ProcuraNumeroTombo(long numtombo)
        {
            string[] lines = File.ReadAllLines("EMPRESTIMO.csv");
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] emprestimoCSV = line.Split(',');

                    if (emprestimoCSV[1] == numtombo.ToString())
                    {
                        return new Emprestimo
                        {
                            IdCliente = long.Parse(emprestimoCSV[0]),
                            NumeroTombo = long.Parse(emprestimoCSV[1]),
                            DataEmprestimo = DateTime.Parse(emprestimoCSV[2]),
                            DataDevolucao = DateTime.Parse(emprestimoCSV[3]),
                            StatusEmprestimo = int.Parse(emprestimoCSV[4])


                        };
                    }
                }
            }

            return null;
        }

        public static void SalvarEmprestimo(Emprestimo emprestimo)
        {
            string lineemprestimo = $"{emprestimo.IdCliente}," +
                                  $"{emprestimo.NumeroTombo}," +
                                  $"{emprestimo.DataEmprestimo:d}," +
                                  $"{emprestimo.DataDevolucao:d}," +
                                  $"{emprestimo.StatusEmprestimo},";

            StreamWriter sw = File.AppendText("EMPRESTIMO.csv");
            sw.WriteLine(lineemprestimo);
            sw.Close();
        }

        public static void AtualizarEmprestimo(Emprestimo emprestimo)
        {
            bool encontrou = false;
            string[] lines = File.ReadAllLines("EMPRESTIMO.csv");
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    if (encontrou)
                    {
                        break;
                    }
                    string line = lines[i];
                    string[] emprestimoCSV = line.Split(',');
                    long idcliente = long.Parse(emprestimoCSV[0]);
                    long numerotombo = long.Parse(emprestimoCSV[1]);


                    if (idcliente == emprestimo.IdCliente && numerotombo == emprestimo.NumeroTombo)
                    {
                        string lineemprestimo = $"{emprestimo.IdCliente}," +
                                  $"{emprestimo.NumeroTombo}," +
                                  $"{emprestimo.DataEmprestimo:d}," +
                                  $"{emprestimo.DataDevolucao:d}," +
                                  "2,";

                        lines[i] = lineemprestimo;
                        encontrou = true;
                    }
                }

                File.WriteAllLines("EMPRESTIMO.csv", lines);
            }
        }

        public static List<Emprestimo> RecuperaEmprestimo()
        {
            List<Emprestimo> emprestimos = new List<Emprestimo>();

            string[] lines = File.ReadAllLines("EMPRESTIMO.csv");
            if (lines.Length > 1)
            {

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] emprestimoCSV = line.Split(',');


                    Emprestimo emprestimo = new Emprestimo
                    {
                        IdCliente = long.Parse(emprestimoCSV[0]),
                        NumeroTombo = long.Parse(emprestimoCSV[1]),
                        DataEmprestimo = DateTime.Parse(emprestimoCSV[2]),
                        DataDevolucao = DateTime.Parse(emprestimoCSV[3]),
                        StatusEmprestimo = int.Parse(emprestimoCSV[4])

                    };


                    emprestimos.Add(emprestimo);
                }

            
            }
            return emprestimos;

        }
    }
}
