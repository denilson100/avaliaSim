using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AvaliaSim.Repository
{
    public class AvaliacaoRepository
    {
        SqlConnection connection;

        string strConString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-AvaliaSim-20180314110252.mdf;Initial Catalog=aspnet-AvaliaSim-20180314110252;Integrated Security=True";

        public IEnumerable<Avaliacao> GetAllAvaliacoes()
        {
            using (var connection = new SqlConnection(strConString))
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

        public IEnumerable<Avaliacao> GetLitsBuscaPorNome(String nome)
        {
            using (var connection = new SqlConnection(strConString))
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

        public void AddAvaliacao(string nome, string cidade, string estado, string tipo)
        {
            DateTime today = DateTime.Today;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "INSERT INTO avaliacoes (nome, cidade, estado, tipo, _data) VALUES (@nome, @cidade, @estado, @tipo, GetDate())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@tipo", tipo);
               // cmd.Parameters.AddWithValue("@totalAvaliacoes", totalAvaliacoes);
                cmd.Parameters.AddWithValue("@_data", today);
                cmd.ExecuteNonQuery();
            }
        }

        public Avaliacao GetAvaliacao(int avaliacaoId)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.avaliacoes WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", avaliacaoId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        return new Avaliacao()
                        {
                            Id = reader.GetInt32(0),
                            nome = reader.GetString(1),
                            cidade = reader.GetString(2),
                            estado = reader.GetString(3),
                            tipo = reader.GetString(4),
                            totalAvaliacoes = reader.GetInt32(5),
                            servAtendimento = reader.GetInt32(5),
                            servAgilidade = reader.GetInt32(5),
                            servsatisfacao = reader.GetInt32(5),
                            prodQualidade = reader.GetInt32(5),
                            prodCusto_beneficio = reader.GetInt32(5),
                            prodSatisfacao = reader.GetInt32(5)

                        };
                }
            }
            return null;
        }

        public void UpdateAmigo(Avaliacao avaliacao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.pessoa SET nome = @nome, sobreNome = @sobreNome, email = @email, nascimento = @nascimento WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", avaliacao.Id);
                cmd.Parameters.AddWithValue("@nome", avaliacao.Nome);
                cmd.Parameters.AddWithValue("@sobreNome", avaliacao.SobreNome);
                cmd.Parameters.AddWithValue("@email", avaliacao.Email);
                cmd.Parameters.AddWithValue("@nascimento", avaliacao.Nascimento);
                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateAvaliacao(Avaliacao avaliacao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.pessoa SET nome = @nome WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", avaliacao.Id);
                cmd.Parameters.AddWithValue("@nome", avaliacao.nome);

                cmd.ExecuteNonQuery();

            }
        }

        /*** Total Avaliações  ***/

        public void UpdateTotalAvaliacoes(int id)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET total_avaliacoes = total_avaliacoes + 1 WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        /*** Serviços  ***/

        public void UpdateServAgilidade(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET serv_agilidade = serv_agilidade WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_agilidade = serv_agilidade + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_agilidade = serv_agilidade - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateServAtendimento(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET serv_atendimento = serv_atendimento WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_atendimento = serv_atendimento + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_atendimento = serv_atendimento - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateServSatisfacao(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET serv_satisfacao = serv_satisfacao WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_satisfacao = serv_satisfacao + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET serv_satisfacao = serv_satisfacao - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        /*** Produtos  ***/

        public void UpdateProdQualidade(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET prod_qualidade = prod_qualidade WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_qualidade = prod_qualidade + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_qualidade = prod_qualidade - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProdCustoBeneficio(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET prod_custo_beneficio = prod_custo_beneficio WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_custo_beneficio = prod_custo_beneficio + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_custo_beneficio = prod_custo_beneficio - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProdSatisfacao(int id, int recebeOpcao)
        {
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE dbo.avaliacoes SET prod_satisfacao = prod_satisfacao WHERE id = @id";
                if (recebeOpcao == 1)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_satisfacao = prod_satisfacao + 1 WHERE id = @id";
                }
                if (recebeOpcao == 3)
                {
                    query = "UPDATE dbo.avaliacoes SET prod_satisfacao = prod_satisfacao - 1 WHERE id = @id";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        /*
                public void RemoveAmigo(int amigoId)
                {
                    using (SqlConnection con = new SqlConnection(strConString))
                    {
                        con.Open();
                        string query = "DELETE FROM dbo.pessoa WHERE id = @id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", amigoId);
                        cmd.ExecuteNonQuery();
                    }
                }
                */
    }

}