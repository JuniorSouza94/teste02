using System;

namespace Teste02.Domain
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }
        public int NumeroDiasAberto => (int)DateTime.Now.Subtract(DataAbertura).TotalDays;

        public Chamado(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }
        public Chamado()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Título: {Titulo}, Descrição: {Descricao}, Equipamento: {Equipamento}, Data de Abertura: {DataAbertura}, Número de Dias Aberto: {NumeroDiasAberto}";
        }

    }

}
