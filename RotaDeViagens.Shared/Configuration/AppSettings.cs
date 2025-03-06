using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagens.Shared.Configuration
{
    public static class AppSettings
    {
        public static class Mensagens
        {
            public const string SolicitarRota = "Digite a rota (Origem-Destino) ou 'sair': ";
            public const string EntradaInvalida = "Entrada inválida. Use o formato ORIGEM-DESTINO.";
            public const string MelhorRota = "Melhor Rota: {0} ao custo de ${1}";
            public const string RotaNaoEncontrada = "Nenhuma rota encontrada.";
            public const string MenuPrincipal = "Selecione uma opção:\n1 - Consultar melhor rota\n2 - Adicionar nova rota\nDigite 'sair' para encerrar.";
            public const string SolicitarNovaRota = "Digite a nova rota no formato Origem,Destino,Valor: ";
            public const string EntradaInvalidaNovaRota = "Entrada inválida. Use o formato ORIGEM,DESTINO,VALOR.";
            public const string RotaAdicionada = "Nova rota adicionada com sucesso!";
            public const string OpcaoInvalida = "Opção inválida. Tente novamente.";
        }

        public static class ArquivoRotas
        {
            public const string File = "Resources/rotas.txt";
        }
    }
}
