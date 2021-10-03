using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using senai_gufi_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos tipos de eventos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tiposEventos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class TiposEventosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tiposEventoRepository que irá receber todos os métodos definidos na interface ITiposEventoRepository
        /// </summary>
        private ITiposEventosRepository _tiposEventosRepository{get; set;}


        /// <summary>
        /// Instancia o objeto _tiposEventoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposEventosController()
        {
            _tiposEventosRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // tratamento de excessoes 
            // tratativa para listar 
            try
            {
                return Ok(_tiposEventosRepository.Listar());
            }
            catch (Exception error)
            {
                // caso não passe, retorna um BadRequest
                return BadRequest(error);
              
            }
        }


        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // tratamento de excessao
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventosRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                // caso não passe, retorna um BadRequest
                return BadRequest(error);
            }
        }


        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposEvento novoTipoEvento)
        {
            // tratamento excessao
            try
            {
                //faz a chamada para o metodo
                _tiposEventosRepository.Cadastrar(novoTipoEvento);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEvento tiposEventoAtualizado)
        {
            // tratamento de excessao
            try
            {
                // Faz a chamada para o método
                _tiposEventosRepository.Atualizar(id, tiposEventoAtualizado);

                // retorna um status Code
                return StatusCode(200);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventosRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception error)
            {
                return BadRequest(error);
               
            }
        }
    }
}
