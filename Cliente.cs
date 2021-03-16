using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class Cliente
    {
        public long IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        
        public override string ToString()
        {
            return $"CPF do Cliente: {CPF}\nID do Cliente: {IdCliente}\nNome do Cliente: {Nome}\nData de Nascimento: {DataNascimento.ToString("dd/MM/yyyy")}\nTelefone: {Telefone}";
        }
    }
}
