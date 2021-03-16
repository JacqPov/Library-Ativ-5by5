using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class Emprestimo
    {
        public long IdCliente { get; set; }
        public long NumeroTombo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }

        public override string ToString()
        {
            return $"ID do Cliente: {IdCliente}\nNúmero do Tombo: {NumeroTombo}\nData do Empréstimo: {DataEmprestimo.ToString("dd/MM/yyyy")}\nData da Devolução: {DataDevolucao.ToString("dd/MM/yyyy")}\nStatus do Empréstimo: {StatusEmprestimo}";
        }
    }
}
