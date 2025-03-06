using RotaDeViagens.Shared.Rotas;
using static System.Net.Mime.MediaTypeNames;

namespace RotaDeViagens.Core
{
    public class GerenciadorRotas
    {
        private readonly string _caminhoArquivo;
        private List<Rota> _rotas;

        public GerenciadorRotas(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
            _rotas = CarregarRotas();
        }

        /// <summary>
        /// Le as rotas do arquivo txt
        /// </summary>
        /// <returns></returns>
        private List<Rota> CarregarRotas()
        {
            var rotas = new List<Rota>();
            string current_path = Path.GetFullPath(_caminhoArquivo);

            if (File.Exists(current_path))
            {
                foreach (var linha in File.ReadAllLines(current_path))
                {
                    var partes = linha.Split(',');
                    if (partes.Length == 3 && int.TryParse(partes[2], out int custo))
                    {
                        rotas.Add(new Rota(partes[0].Trim(), partes[1].Trim(), custo));
                    }
                }
            }
            return rotas;
        }

        /// <summary>
        /// Busca a rota mais barata entre os pontos especificados.
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public MelhorRota EncontrarMelhorRota(string origem, string destino)
        {
            var caminhos = new List<MelhorRota>();
            BuscarCaminhos(origem, destino, new List<string>(), 0, caminhos);
            return caminhos.OrderBy(r => r.Custo).FirstOrDefault();
        }

        /// <summary>
        /// Urilizado pelo metodo EncontrarMelhorRota
        /// </summary>
        /// <param name="atual"></param>
        /// <param name="destino"></param>
        /// <param name="caminho"></param>
        /// <param name="custoTotal"></param>
        /// <param name="caminhos"></param>
        private void BuscarCaminhos(string atual, string destino, List<string> caminho, int custoTotal, List<MelhorRota> caminhos)
        {
            if (caminho.Contains(atual)) return;

            caminho.Add(atual);
            if (atual == destino)
            {
                caminhos.Add(new MelhorRota(new List<string>(caminho), custoTotal));
                return;
            }

            foreach (var rota in _rotas.Where(r => r.Origem == atual))
            {
                BuscarCaminhos(rota.Destino, destino, new List<string>(caminho), custoTotal + rota.Custo, caminhos);
            }
        }

        /// <summary>
        /// Adiciona uma nova rota ao sistema e a salva no arquivo rotas.txt.
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <param name="custo"></param>
        public void AdicionarRota(string origem, string destino, int custo)
        {
            string current_path = Path.GetFullPath(_caminhoArquivo);
            var novaRota = new Rota(origem, destino, custo);
            _rotas.Add(novaRota);
            if (File.Exists(current_path))
            {
                File.AppendAllText(current_path, $"{origem},{destino},{custo}{Environment.NewLine}");
            }
        }
    }
}
