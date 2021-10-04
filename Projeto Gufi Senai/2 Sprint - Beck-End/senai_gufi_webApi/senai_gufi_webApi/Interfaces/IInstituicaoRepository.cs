using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{
    /// <summary>
    /// Interface resposavel pelo InstituicaoRepository
    /// </summary>
     

    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>retorna uma lista de instituições</returns>
        List<Instituico> Listar();

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">objeto que será cadastrado</param>
        /// VOID(RETORNA ALGUMA INFORMACAO)
        void Cadastrar(Instituico novaInstituicao);

        /// <summary>
        /// Deleta uma instituicao existente
        /// </summary>
        /// <param name="id">id da instituicao que sera deletada</param>
        /// <returns>retorna um status code 204</returns>
        void Deletar(int id);

        /// <summary>
        /// Busca uma instituicao através do seu id
        /// </summary>
        /// <param name="id">id do evento que sera buscado</param>
        /// <returns>retorna todos as instituicoes  buscadas </returns>
        Evento BuscarPorId(int id);

        /// <summary>
        /// Atualizar instituicao através do seu id
        /// </summary>
        /// <param name="id">id da instituicao que sera buscado</param>
        /// <param name="instituicaoAtualizada">objeto que vai ser atualizado</param>
        void Atualizar(int id, Instituico instituicaoAtualizada);
    }
}
