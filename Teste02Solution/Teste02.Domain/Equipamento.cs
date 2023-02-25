using System;

namespace Teste02.Domain
{
    public class Equipamento
    {
        public string Nome { get; set; }
        public double PrecoAquisicao { get; set; }
        public int NumeroSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }

        public Equipamento(string nome, double precoAquisicao, int numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Nome = nome;
            PrecoAquisicao = precoAquisicao;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }
        public Equipamento()
        {
        }
        public override string ToString()
        {
            return $"Nome: {Nome}, Preço de Aquisição: {PrecoAquisicao:C2}, Número de Série: {NumeroSerie}, Data de Fabricação: {DataFabricacao.ToShortDateString()}, Fabricante: {Fabricante}";
        }
    }

}
