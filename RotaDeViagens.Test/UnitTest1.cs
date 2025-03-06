using RotaDeViagens.Core;

namespace RotaDeViagens.Test
{
    public class UnitTest1
    {
        private readonly string _testFilePath = "test_rotas.txt";

        public UnitTest1()
        {
            if (File.Exists(_testFilePath))
                File.Delete(_testFilePath);

            File.WriteAllLines(_testFilePath, new[]
            {
                "GRU,BRC,10",
                "BRC,SCL,5",
                "GRU,CDG,75",
                "GRU,SCL,20",
                "GRU,ORL,56",
                "ORL,CDG,5",
                "SCL,ORL,20",
                "CTBA,GRU,20"
            });
        }

        [Fact]
        public void EncontrarMelhorRota_DeveRetornarRotaMaisBarata()
        {
            var gerenciadorRotas = new GerenciadorRotas(_testFilePath);
            var melhorRota = gerenciadorRotas.EncontrarMelhorRota("GRU", "CDG");

            Assert.NotNull(melhorRota);
            Assert.Equal(40, melhorRota.Custo);
            Assert.Equal(new List<string> { "GRU", "BRC", "SCL", "ORL", "CDG" }, melhorRota.Caminho);
        }

        [Fact]
        public void EncontrarMelhorRota_DeveRetornarNullParaRotaInexistente()
        {
            var gerenciadorRotas = new GerenciadorRotas(_testFilePath);
            var melhorRota = gerenciadorRotas.EncontrarMelhorRota("GRU", "XYZ");
            Assert.Null(melhorRota);
        }

        [Fact]
        public void AdicionarRota_DevePersistirNovaRota()
        {
            var gerenciadorRotas = new GerenciadorRotas(_testFilePath);
            gerenciadorRotas.AdicionarRota("GRU", "MIA", 50);

            var melhorRota = gerenciadorRotas.EncontrarMelhorRota("GRU", "MIA");
            Assert.NotNull(melhorRota);
            Assert.Equal(50, melhorRota.Custo);
            Assert.Equal(new List<string> { "GRU", "MIA" }, melhorRota.Caminho);
        }
    }
}