using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio de tipos de eventos
    /// </summary>
    public class TiposEventoRepository : ITiposEventosRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento através do seu id
        /// </summary>
        /// <param name="id">id do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">objeto com as novas informações</param>
        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            // Busca um tipo de evento através do id
            TiposEvento tipoEventoBuscado = ctx.TiposEventos.Find(id);

            // Verifica se o título do tipo de evento foi informado
            if (tipoEventoAtualizado.TituloTipoEvento != null)
            {
                // Atribui novos valores aos campos existentes
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            // atualiza um tipo de evento que foi buscado
            ctx.TiposEventos.Update(tipoEventoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de evento através do seu id
        /// </summary>
        /// <param name="id">id que sera buscado</param>
        /// <returns>retorna todos os tipos de eventos</returns>
        public TiposEvento BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de evento encontrado para o ID informado
            return ctx.TiposEventos.FirstOrDefault(te => te.IdTipoEvento == id);
        }


        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">novo objeto que será cadastrado</param>
        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            //adiciona um novo tipo de evento
            ctx.TiposEventos.Add(novoTipoEvento);

            // salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento através do seu id
        /// </summary>
        /// <param name="id">id do tipo de evento que sera deletado</param>
        public void Deletar(int id)
        {
            // Busca o Tipo De evento através do id
            TiposEvento tiposEventoBuscado = ctx.TiposEventos.Find(id);

            // remove um tipo de evento
            ctx.TiposEventos.Remove(tiposEventoBuscado);

            // salva as informações no banco de dados
            ctx.SaveChanges();


        }

        public List<TiposEvento> Listar()
        {
            // lista todos os tipos de eventos
            return ctx.TiposEventos.ToList();
        }
    }
}
