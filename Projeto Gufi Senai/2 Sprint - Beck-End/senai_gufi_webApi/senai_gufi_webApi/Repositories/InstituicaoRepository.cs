using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        GufiContext ctx = new GufiContext();

        public void Atualizar(int id, Instituico instituicaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Instituico novaInstituicao)
        {
            // Adiciona uma nova instituicao
            ctx.Instituicoes.Add(novaInstituicao);

            // salva todas as informações no banco
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Instituico> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
