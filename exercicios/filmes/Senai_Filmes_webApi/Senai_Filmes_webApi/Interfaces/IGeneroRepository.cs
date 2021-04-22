using Senai_Filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// </summary>
   public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo()
        /// <summary>
        /// Listar todos Generos
        /// </summary>
        /// <returns>Uma Lista De Generos</returns>
        List<GeneroDomain> ListarTodos();
        /// <summary>
        /// /Buscar um Genero Atraves do Id
        /// </summary>
        /// <param name="Id">Id do genero buscado</param>
        /// <returns>Um objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int Id);
        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="NovoGenero">Objeto NovoGenero com as informaçoes que serão cadastradas</param>
        void Cadastrar(GeneroDomain NovoGenero);
        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisiçao
        /// </summary>
        /// <param name="Genero">Objeto genero com as novas informaçoes</param>
        void AtualizarIdCorpo(GeneroDomain Genero);
        /// <summary>
        /// Atualiza um genero existente passando a url pelo corpo da requisiçao
        /// </summary>
        /// <param name="id">Id do genero que vai será atualizado</param>
        /// <param name="Genero">Objeto genero com as novas informaçoes</param>
        void AtualizaIdUrl(int id, GeneroDomain Genero);
        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id"> id do genero cadastrado</param>
        void Deletar(int id);
    }
}
