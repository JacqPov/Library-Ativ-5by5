using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoIndiv
{
    class Livro
    {
        public long NumeroTombo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get; set; }
 

        public override string ToString()
        {
            return $"Numero do Tombo: {NumeroTombo}\nISBN: {ISBN}\nTítulo do Livro: {Titulo}\nGênero: {Genero}\nData de Publicação: {DataPublicacao.ToString("dd/MM/yyyy")}\nAutor: {Autor}";
        }
    }
}
