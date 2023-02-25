using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste02.Domain;

namespace Teste02.Infra.Data.DAO
{
    public class ChamadoDao
    {
        private readonly string _connectionString =
         @"server=.\SQLexpress;initial catalog=GESTAO_EQUIPAMENTOS;integrated security=true;";

        public ChamadoDao()
        {

        }
        private void ConverterObjetoParaParametrosSQL(Chamado chamado, SqlCommand command)
        {
            command.Parameters.AddWithValue("@ID", chamado.Id);
            command.Parameters.AddWithValue("@TITULO", chamado.Titulo);
            command.Parameters.AddWithValue("@DESCRICAO", chamado.Descricao);
            command.Parameters.AddWithValue("@EQUIPAMENTO_ID", chamado.Equipamento.NumeroSerie);
            command.Parameters.AddWithValue("@DATA_ABERTURA", chamado.DataAbertura);
        }
        private Chamado ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            int id = int.Parse(leitor["ID"].ToString());
            string titulo = leitor["TITULO"].ToString();
            string descricao = leitor["DESCRICAO"].ToString();
            Equipamento equipamento = new Equipamento();
            equipamento.NumeroSerie = int.Parse(leitor["EQUIPAMENTO_ID"].ToString());
            DateTime dataAbertura = Convert.ToDateTime(leitor["DATA_ABERTURA"].ToString());

            return new Chamado(id, titulo, descricao, equipamento, dataAbertura);
        }
        public void AdicionarChamado(Chamado chamado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                
                using (var command = new SqlCommand())
                {
                    command.Connection = conexao;

                    var insertCommand = @"INSERT INTO CHAMADOS VALUES (@TITULO,
                                                                       @DESCRICAO,
                                                                       @EQUIPAMENTO_ID,
                                                                       @DATA_ABERTURA)";

                    ConverterObjetoParaParametrosSQL(chamado, command);

                    command.CommandText = insertCommand;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Chamado> BuscarTodos()
        {
            var listaChamado = new List<Chamado>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT C.*, E.*
                                    FROM CHAMADOS C
                                    INNER JOIN EQUIPAMENTOS E ON C.EQUIPAMENTO_ID = E.NUMERO_SERIE;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Chamado chamadoBuscado = ConverterSqlParaObjeto(leitor);
                        listaChamado.Add(chamadoBuscado);
                    }
                }

                return listaChamado;
            }
        }
        public void DeletarChamado(Chamado chamado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM CHAMADOS WHERE ID = @ID;";

                    comando.Parameters.AddWithValue("@CHAMADO_DELETADO", chamado.Id);

                    ConverterObjetoParaParametrosSQL(chamado, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
    
    }
}
