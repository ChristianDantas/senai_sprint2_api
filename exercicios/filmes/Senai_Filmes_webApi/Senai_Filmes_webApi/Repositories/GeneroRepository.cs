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
        private string StringConexao = "data source=LAPTOP-SNC6JC26; initial catalog=Filmes; user id=sa;pwd=chris1234" ;

        public void AtualizaIdUrl(int id, GeneroDomain Genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdCorpo(GeneroDomain Genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain NovoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
