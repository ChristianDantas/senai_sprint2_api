using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using T_Peoples.Domains;
using T_Peoples.Interfaces;

namespace T_Peoples.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string StringConexao = "data source=LAB08DESK115869\\SQLEXPRESS2019; initial catalog=T_Peoples; user id=sa;pwd=sa@132";
        public void AtualizaIdUrl(int id, FuncionarioDomain Funcionario)
        {
            using (SqlConnection conUpdateIdUrl = new SqlConnection(StringConexao))
            {
                //declarar a query que será executada
                string queryUpdateIdUrl = "UPDATE Funcionarios SET nome=@Nome, sobrenome=@Sobrenome WHERE idFuncionarios=@ID";
                using (SqlCommand cmdUpdateIdUrl = new SqlCommand(queryUpdateIdUrl, conUpdateIdUrl))
                {
                    cmdUpdateIdUrl.Parameters.AddWithValue("@ID",id);
                    cmdUpdateIdUrl.Parameters.AddWithValue("@Nome", Funcionario.Nome);
                    cmdUpdateIdUrl.Parameters.AddWithValue("@Sobrenome", Funcionario.Nome);
                    conUpdateIdUrl.Open();

                    cmdUpdateIdUrl.ExecuteNonQuery();

                }
            }
        }



        public FuncionarioDomain BuscarPorId(int Id)
        {
            using (SqlConnection conSelectById = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT idFuncionarios,nome,sobrenome FROM funcionarios WHERE idFuncionarios= @ID";
                conSelectById.Open();
                SqlDataReader rdr;
                using (SqlCommand cmdSelectById = new SqlCommand(querySelectById, conSelectById))
                {
                    cmdSelectById.Parameters.AddWithValue("@ID", Id);
                    rdr = cmdSelectById.ExecuteReader();
                    if (rdr.Read())
                    {
                        FuncionarioDomain FuncionarioBuscado = new FuncionarioDomain()
                        {
                            IdFuncionario = Convert.ToInt32(rdr["idFuncionarios"]),
                            Nome = rdr["Nome"].ToString(),
                            SobreNome = rdr["Sobrenome"].ToString()
                        };
                        return FuncionarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain NovoGenero)
        {
            using (SqlConnection conInsert = new SqlConnection(StringConexao))
            {
                //declarar a query que será executada
                string queryInsert = "INSERT INTO funcionarios(nome, sobrenome) VALUES (@Nome, @SobreNome)";
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conInsert))
                {
                    cmdInsert.Parameters.AddWithValue("@Nome", NovoGenero.Nome);
                    cmdInsert.Parameters.AddWithValue("@SobreNome", NovoGenero.SobreNome);
                    conInsert.Open();

                    cmdInsert.ExecuteNonQuery();

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conDelete = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM funcionarios WHERE idFuncionarios = @ID";
                using (SqlCommand cmdDeleter = new SqlCommand(queryDelete, conDelete))
                {
                    cmdDeleter.Parameters.AddWithValue("@ID", id);
                    conDelete.Open();

                    cmdDeleter.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT idFuncionarios, nome, sobrenome FROM funcionarios";
                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionarioDomain Funcionario = new FuncionarioDomain()
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString(),
                             SobreNome = rdr[2].ToString()
                        };
                        listaFuncionarios.Add(Funcionario);
                    }
                }
            }
            return listaFuncionarios;
        }
    }
}
