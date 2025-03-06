using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagens.Shared.Rotas
{
    public class MelhorRota
    {
        public List<string> Caminho { get; }
        public int Custo { get; }

        public MelhorRota(List<string> caminho, int custo)
        {
            Caminho = caminho;
            Custo = custo;
        }
    }
}
