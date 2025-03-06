using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagens.Shared.Rotas
{
    public class Rota
    {
        public string Origem { get; }
        public string Destino { get; }
        public int Custo { get; }

        public Rota(string origem, string destino, int custo)
        {
            Origem = origem;
            Destino = destino;
            Custo = custo;
        }
    }

}
