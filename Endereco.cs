using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Endereco Proximo { get; set; }

        public override string ToString()
        {
            return $"Logradouro: {Logradouro}\nBairro: {Bairro}\nCidade: {Cidade}\nEstado: {Estado}\nCEP: {CEP}";
        }
    }
}
