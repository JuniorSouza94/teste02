using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste02.Domain;

namespace Teste02.Infra.Data.DAO
{
    public class EquipamentoDao
    {
        private readonly string _connectionString =
         @"server=.\SQLexpress;initial catalog=GESTAO_EQUIPAMENTOS;integrated security=true;";

        public EquipamentoDao()
        {
        }
        private void ConverterObjetoParaParametrosSQL(Equipamento equipamento, SqlCommand command)
        {
            command.Parameters.AddWithValue("@NOME",equipamento.Nome);
            command.Parameters.AddWithValue("@PRECO_AQUISICAO", equipamento.PrecoAquisicao);
            command.Parameters.AddWithValue("@NUMERO_SERIE", equipamento.NumeroSerie);
            command.Parameters.AddWithValue("@DATA_FABRICACAO", equipamento.DataFabricacao);
            command.Parameters.AddWithValue("@FABRICANTE", equipamento.Fabricante);
        }
        private Equipamento ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            string nome = leitor["NOME"].ToString();
            double precoAquisicao = double.Parse(leitor["PRECO_AQUISICAO"].ToString());
            int numeroSerie = int.Parse(leitor["NUMERO_SERIE"].ToString());
            DateTime dataFabricacao = Convert.ToDateTime(leitor["DATA_FABRICACAO"].ToString());
            string fabricante = leitor["FABRICANTE"].ToString();

            return new Equipamento(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);
        }
        public void AdicionarEquipamento(Equipamento novoEquipamento)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO EQUIPAMENTOS VALUES (@NOME,
                                                                       @PRECO_AQUISICAO,
                                                                       @NUMERO_SERIE,
                                                                       @DATA_FABRICACAO,
                                                                       @FABRICANTE)";

                    ConverterObjetoParaParametrosSQL(novoEquipamento, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }
       
        }
        public void AtualizarEquipamento(Equipamento equipamentoAtualizado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"UPDATE EQUIPAMENTOS SET NOME = @NOME,
                                                                  PRECO_AQUISICAO = @PRECO_AQUISICAO,
                                                                  DATA_FABRICACAO = @DATA_FABRICACAO,
                                                                  FABRICANTE = @FABRICANTE
                                                                  WHERE NUMERO_SERIE = @N_SERIE;";

                    command.Parameters.AddWithValue("@N_SERIE", equipamentoAtualizado.NumeroSerie);

                    ConverterObjetoParaParametrosSQL(equipamentoAtualizado, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }

        }
        public List<Equipamento> BuscarTodos()
        {
            var listaEquipamentos = new List<Equipamento>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM EQUIPAMENTOS;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Equipamento equipamentoBuscado = ConverterSqlParaObjeto(leitor);
                        listaEquipamentos.Add(equipamentoBuscado);
                    }
                }

                return listaEquipamentos;
            }
        }
        public void DeletarEquipamento(Equipamento equipamento)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM EQUIPAMENTOS WHERE NUMERO_SERIE = @NSERIE";

                    comando.Parameters.AddWithValue("@NSERIE", equipamento.NumeroSerie);

                    ConverterObjetoParaParametrosSQL(equipamento, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}
