using RotaDeViagens.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RotaDeViagens.Shared.Configuration.AppSettings;

namespace RotaDeViagens.App.RotaAppService
{
    public class RotaAppService
    {
        public GerenciadorRotas _gerenciadorRotas;
        /// <summary>
        /// Construtor da classe 
        /// Inicializa GerenciadorRotas
        /// </summary>
        public RotaAppService()
        {
            _gerenciadorRotas = new GerenciadorRotas(ArquivoRotas.File);
        }

        /// <summary>
        /// Executa o codigo e mostra para o usuario as opcoes do menu e resultados
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                Console.WriteLine(Mensagens.MenuPrincipal);
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    Console.Write(Mensagens.SolicitarRota);
                    string entrada = Console.ReadLine();
                    if (entrada.ToLower() == "sair") break;

                    string[] pontos = entrada.Split('-');
                    if (pontos.Length != 2)
                    {
                        Console.WriteLine(Mensagens.EntradaInvalida);
                        continue;
                    }

                    string origem = pontos[0].Trim().ToUpper();
                    string destino = pontos[1].Trim().ToUpper();

                    var melhorRota = _gerenciadorRotas.EncontrarMelhorRota(origem, destino);
                    if (melhorRota != null)
                        Console.WriteLine(string.Format(Mensagens.MelhorRota, string.Join(" - ", melhorRota.Caminho), melhorRota.Custo));
                    else
                        Console.WriteLine(Mensagens.RotaNaoEncontrada);
                }
                else if (opcao == "2")
                {
                    Console.Write(Mensagens.SolicitarNovaRota);
                    string entrada = Console.ReadLine();

                    string[] partes = entrada.Split(',');
                    if (partes.Length != 3 || !int.TryParse(partes[2], out int custo))
                    {
                        Console.WriteLine(Mensagens.EntradaInvalidaNovaRota);
                        continue;
                    }

                    string origem = partes[0].Trim().ToUpper();
                    string destino = partes[1].Trim().ToUpper();
                    _gerenciadorRotas.AdicionarRota(origem, destino, custo);
                    Console.WriteLine(Mensagens.RotaAdicionada);
                }
                else if (opcao.ToLower() == "sair")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Mensagens.OpcaoInvalida);
                }
            }
        }
    }
}
