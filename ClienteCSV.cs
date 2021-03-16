using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class ClienteCSV
    {
        public string Path { get; set; }

        public static int ProcuraCPF(string cpf)
        {
            string[] lines = File.ReadAllLines("CLIENTE.csv");
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] clienteCSV = line.Split(',');
                    if (clienteCSV[1] == cpf)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static Cliente ProcuraClienteCPF(string cpf)
        {
            string[] lines = File.ReadAllLines("CLIENTE.csv");
            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] clienteCSV = line.Split(',');
                    if (clienteCSV[1] == cpf)
                    {
                        return new Cliente {
                            IdCliente = long.Parse(clienteCSV[0]),
                            CPF  = clienteCSV[1],
                            Nome = clienteCSV[2],
                            DataNascimento = DateTime.Parse(clienteCSV[3]),
                            Telefone = clienteCSV[4]

                        };
                    }
                }
            }
            return null;
        }
        public static Cliente LeituraCliente(string cpf)
        {
            string[] lines = File.ReadAllLines("CLIENTE.csv");

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] clienteCSV = line.Split(',');
                if (clienteCSV[0] == cpf)
                {
                    Cliente cliente = new Cliente
                    {
                        CPF = cpf,
                        Nome = clienteCSV[1],
                        DataNascimento = DateTime.ParseExact(clienteCSV[2], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Telefone = clienteCSV[3],
                        IdCliente = long.Parse(clienteCSV[4])
                    };
                    return cliente;
                }
            }
            return null;
        }

        public static void SalvarCliente(Cliente cliente)
        {
            string linecliente = $"{cliente.IdCliente}," +
                                  $"{cliente.CPF}," +
                                  $"{cliente.Nome}," +
                                  $"{cliente.DataNascimento.ToString("dd/MM/yyyy")}," +
                                  $"{cliente.Telefone},";
        
            StreamWriter sw = File.AppendText("CLIENTE.csv");
            sw.WriteLine(linecliente);
            sw.Close();
        }


        public static List<Cliente> RecuperaCliente()
        {
            List<Cliente> clientes = new List<Cliente>();

            string[] lines = File.ReadAllLines("CLIENTE.csv");
            if (lines.Length > 1)
            {

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] clienteCSV = line.Split(',');


                    Cliente cliente = new Cliente
                    {
                        IdCliente = long.Parse(clienteCSV[0]),
                        CPF = clienteCSV[1],
                        Nome = clienteCSV[2],
                        DataNascimento = DateTime.ParseExact(clienteCSV[3], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Telefone = clienteCSV[4]
                      

                    };


                    clientes.Add(cliente);
                }


            }
            return clientes;



        }
    }
}
