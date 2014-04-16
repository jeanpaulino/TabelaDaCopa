using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaDaCopa.Models
{
    public class Groups
    {
        public class Selecao
        {
            public string Nome { get; set; }
        }

        public class Classificacao
        {
            public int Posicao { get; set; }
            public Selecao Selecao { get; set; }
            public int PontosGanhos { get; set; }
            public int Jogos { get; set; }
            public int Vitorias { get; set; }
            public int Empates { get; set; }
            public int Derrotas { get; set; }
            public int GolsPro { get; set; }
            public int GolsContra { get; set; }
            public int SaldoGols { get; set; }
        }

        public class RootObject
        {
            public string Grupo { get; set; }
            public List<Classificacao> Classificacao { get; set; }
        }
    }
}
