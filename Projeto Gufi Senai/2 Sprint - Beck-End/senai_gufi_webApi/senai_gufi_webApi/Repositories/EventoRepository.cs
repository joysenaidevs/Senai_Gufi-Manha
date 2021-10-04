using Microsoft.EntityFrameworkCore;
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
    /// Repositorio responsavel pelos eventos
    /// </summary>
    /// 

 
    public class EventoRepository : IEventoRepository
    {
        /// <summary>
        /// Objeto (CTX) contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext(); 

        public void Atualizar(int id, Evento eventoAtualizado)
        {
            // Busca um evento atraves do seu id
            Evento eventoBuscado = ctx.Eventos.Find(id);

            // Verifica se o nome do evento foi informado
            if (eventoAtualizado.NomeEvento != null)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            }

            //verifica se o id do tipo de evento foi informado
            if (eventoAtualizado.IdTipoEvento != null)
            {
                // atribui novos valores
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }

            // Verifica se o tipo do evento foi informado
            if (eventoAtualizado.IdTipoEvento > 0)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }

            if (eventoAtualizado.IdTipoEvento > 0)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento
            }
        }

        public Evento BuscarPorId(int id)
        {
            //retorna todos os eventos buscados pelo seu ID
            return ctx.Eventos.FirstOrDefault(e => e.IdEvento == id);
        }

        public void Cadastrar(Evento novoEvento)
        {
            // adiciona um novo evento
            ctx.Eventos.Add(novoEvento);

            // salva as informações no banco
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // remove um evento existente que foi buscado
            ctx.Eventos.Remove(BuscarPorId(id));

            //salva as alterações no banco
            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            // Retorna uma lista com todas as informações dos eventos
            return ctx.Eventos
                 // Adiciona na busca as informações do tipo de evento
                 .Include(e => e.IdTipoEventoNavigation)
                 //Adiciona na busca as informações da instituicao
                 .Include(e => e.IdInstituicaoNavigation)
                 // Lista os eventos com as entidades adicionadas
                 .ToList();
        }
    }
}
