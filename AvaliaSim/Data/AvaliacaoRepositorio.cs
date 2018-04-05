using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AvaliacaoRepositorio
    {
        private String _connectionString;
        private SqlConnection _sqlConnection;

        public AvaliacaoRepositorio()
        {
           // _connectionString = Data.Properties.Settings.Default.DbConnectionString;
            _connectionString = @"Server=tcp:teste-servidor.database.windows.net,1433;Initial Catalog=testeDB;Persist Security Info=False;User ID=teste;Password=infnet021@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public IEnumerable<Avaliacao> GetAllAvaliacoes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandText = "SELECT * FROM avaliacoes ORDER BY total_avaliacoes DESC";
                var selectCommand = new SqlCommand(commandText, connection);

                Avaliacao avaliacao = null;
                var avaliacoes = new List<Avaliacao>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            avaliacao = new Avaliacao();
                            avaliacao.Id = (int)reader["id"];
                            avaliacao.nome = reader["nome"].ToString();
                            avaliacao.cidade = reader["cidade"].ToString();
                            avaliacao.estado = reader["Estado"].ToString();
                            avaliacao.tipo = reader["tipo"].ToString();
                            avaliacao.totalAvaliacoes = (int)reader["total_avaliacoes"];
                            avaliacao.servAgilidade = (int)reader["serv_agilidade"];
                            avaliacao.servAtendimento = (int)reader["serv_atendimento"];
                            avaliacao.servsatisfacao = (int)reader["serv_satisfacao"];
                            avaliacao.prodQualidade = (int)reader["prod_qualidade"];
                            avaliacao.prodCusto_beneficio = (int)reader["prod_custo_beneficio"];
                            avaliacao.prodSatisfacao = (int)reader["prod_satisfacao"];

                            avaliacao._data = DateTime.Parse(reader["_data"].ToString());

                            avaliacoes.Add(avaliacao);
                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return avaliacoes;
            }

        }

        public void AddAvaliacao(Avaliacao avaliacao)
        {
            DateTime today = DateTime.Today;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "INSERT INTO avaliacoes (nome, cidade, estado, tipo, _data) VALUES (@nome, @cidade, @estado, @tipo, GetDate())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", avaliacao.nome);
                cmd.Parameters.AddWithValue("@cidade", avaliacao.cidade);
                cmd.Parameters.AddWithValue("@estado", avaliacao.estado);
                cmd.Parameters.AddWithValue("@tipo", avaliacao.tipo);
                cmd.Parameters.AddWithValue("@_data", today);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteAvaliacao(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "DELETE FROM avaliacoes WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "UPDATE avaliacoes SET nome = @nome, cidade = @cidade, estado = @estado WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", avaliacao.Id);
                cmd.Parameters.AddWithValue("@nome", avaliacao.nome);
                cmd.Parameters.AddWithValue("@cidade", avaliacao.cidade);
                cmd.Parameters.AddWithValue("@estado", avaliacao.estado);

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<Avaliacao> GetLitsBuscaPorNome(String nome)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var commandText = "SELECT * FROM avaliacoes WHERE nome LIKE '" + nome + "%'";
                var selectCommand = new SqlCommand(commandText, connection);

                Avaliacao avaliacao = null;
                var avaliacoes = new List<Avaliacao>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            avaliacao = new Avaliacao();
                            avaliacao.Id = (int)reader["id"];
                            avaliacao.nome = reader["nome"].ToString();
                            avaliacao.cidade = reader["cidade"].ToString();
                            avaliacao.estado = reader["Estado"].ToString();
                            avaliacao.tipo = reader["tipo"].ToString();
                            avaliacao.totalAvaliacoes = (int)reader["total_avaliacoes"];
                            avaliacao.servAgilidade = (int)reader["serv_agilidade"];
                            avaliacao.servAtendimento = (int)reader["serv_atendimento"];
                            avaliacao.servsatisfacao = (int)reader["serv_satisfacao"];
                            avaliacao.prodQualidade = (int)reader["prod_qualidade"];
                            avaliacao.prodCusto_beneficio = (int)reader["prod_custo_beneficio"];
                            avaliacao.prodSatisfacao = (int)reader["prod_satisfacao"];

                            avaliacao._data = DateTime.Parse(reader["_data"].ToString());

                            avaliacoes.Add(avaliacao);
                        }
                    }
                }
                finally
                {

                    connection.Close();
                }

                return avaliacoes;
            }
        }
    }
}
