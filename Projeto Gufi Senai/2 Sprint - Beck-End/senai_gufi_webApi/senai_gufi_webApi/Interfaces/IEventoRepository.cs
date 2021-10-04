using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{

    /// <summary>
    /// Interface responsavel pelo EventoRepository
    /// </summary>
    public interface IEventoRepository
    {
        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>retorna todos os eventos existentes</returns>
        List<Evento> Listar();

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">objeto que será cadastrado</param>
        void Cadastrar(Evento novoEvento);

        /// <summary>
        /// Deleta todos os eventos
        /// </summary>
        /// <param name="id">id do evento que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">id do evento que será atualizado</param>
        /// <param name="eventoAtualizado">objeto com as novas informações</param>
        void Atualizar(int id, Evento eventoAtualizado);

        /// <summary>
        /// Busca um evento através do seu id
        /// </summary>
        /// <param name="id">id do evento buscado</param>
        /// <returns>retorna o evento que for buscado</returns>
        Evento BuscarPorId(int id);
    }
}
