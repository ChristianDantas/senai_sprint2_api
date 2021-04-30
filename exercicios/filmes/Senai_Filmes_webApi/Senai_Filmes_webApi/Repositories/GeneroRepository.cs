using Senai_Filmes_webApi.Domains;
using Senai_Filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio dos generos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexão com o banco de dados que recebe os parametros
        /// </summary>
        private string StringConexao = "data source=LAB08DESK115869\\SQLEXPRESS2019; initial catalog=Filmes; user id=sa;pwd=sa@132";

        public void AtualizaIdUrl(int id, GeneroDomain Genero)
        {
            using (SqlConnection conUpdateIdUrl = new SqlConnection(StringConexao))
            {
                //declarar a query que será executada
                string queryUpdateIdUrl = "UPDATE Generos SET Nome=@Nome WHERE idGenero=@ID";
                using (SqlCommand cmdUpdateIdUrl = new SqlCommand(queryUpdateIdUrl, conUpdateIdUrl))
                {
                    cmdUpdateIdUrl.Parameters.AddWithValue("@ID",id);
                    cmdUpdateIdUrl.Parameters.AddWithValue("@Nome", Genero.Nome);
                    conUpdateIdUrl.Open();

                    cmdUpdateIdUrl.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarIdCorpo(GeneroDomain Genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection conSelectById = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT idGenero,Nome FROM Generos WHERE idGenero= @ID";
                conSelectById.Open();
                SqlDataReader rdr;
                using (SqlCommand cmdSelectById = new SqlCommand(querySelectById, conSelectById))
                {
                    cmdSelectById.Parameters.AddWithValue("@ID", id);
                    rdr = cmdSelectById.ExecuteReader();
                    if (rdr.Read())
                    {
                         GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["idGenero"]),
                            Nome=rdr["Nome"].ToString()
                        };
                        return generoBuscado;
                    }
                    return null;
                }
            }
        }
        /// <summary>
        /// Cadastrar um Novo genero
        /// </summary>
        /// <param name="NovoGenero"> Objeto novoGenero com as informaçoes que serão cadastradas</param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            //declara a conexão "con" passando a string de conexão como parametro
            using (SqlConnection conInsert = new SqlConnection(StringConexao))
            {
                //declarar a query que será executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conInsert))
                {
                    cmdInsert.Parameters.AddWithValue("@Nome",NovoGenero.Nome);
                    conInsert.Open();

                    cmdInsert.ExecuteNonQuery();
                   
                }
            }
        }

        public void Deletar(int id)
        {
           using(SqlConnection conDelete = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM generos WHERE idGenero = @ID";
                using (SqlCommand cmdDeleter = new SqlCommand(queryDelete, conDelete))
                {
                    cmdDeleter.Parameters.AddWithValue("@ID", id);
                    conDelete.Open();

                    cmdDeleter.ExecuteNonQuery();
                }
            }
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT idGenero,Nome FROM Generos";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                   rdr= cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome=rdr[1].ToString()
                        };
                        listaGeneros.Add(genero);
                    }
                }
            }
            return listaGeneros;
        }
    }
}
