using BibCorpPrevenir2.api.Util.Extensions.Security;
using BibCorpPrevenir2.api.Util.Extentions.Exceptions;
using BibCorpPrevenir2.Application.Dtos.Comentarios;
using BibCorpPrevenir2.Application.Services.Contracts.Comentarios;
using BibCorpPrevenir2.Application.Services.Contracts.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibCorpPrevenir2.api.Controllers.Comentarios
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;
        private readonly IUsuarioService _usuarioService;
        public ComentariosController(IComentarioService comentarioservice, IUsuarioService usuarioService)
        {
            _comentarioService = comentarioservice;
            _usuarioService = usuarioService;
        }
        /// <summary>
        /// Obtém os dados de um comentario específico
        /// </summary>
        /// <param name="acervoId">Identificador do comentario</param>
        /// <response code="200">Dados do comentario consultado</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{acervoId}/todoscomentarios")]
        public async Task<IActionResult> GetComentariosByAcervoId(int acervoId)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByUserNameAsync(User.GetUserNameClaim());

                if (usuario == null)
                {
                    return Unauthorized();
                }

                var comentarios = await _comentarioService.GetComentarioByAcervoIdAsync(acervoId);

                if (comentarios == null) return NotFound("Não existe comentarios cadastrado para o Id informado");

                return Ok(comentarios);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar comentarios por Id. Erro: {e.Message}");
            }
        }
        /// <summary>
        /// Realiza a inclusão de um novo comentario
        /// </summary>
        /// <response code="200">comentario cadastrado com sucesso</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>

        [HttpPost]
        public async Task<IActionResult> CreateComentario(ComentarioDto comentarioDto)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByUserNameAsync(User.GetUserNameClaim());

                if (usuario == null)
                {
                    return Unauthorized();
                }
                var createdComentario = await _comentarioService.CreateComentario(comentarioDto);

                if (createdComentario != null) return Ok(createdComentario);

                return BadRequest("Ocorreu um erro ao tentar incluir o comentario");
            }
            catch (CoreException e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar comentario. Erro: {e.Message}");
            }
        }
        /// <summary>
        /// Obtém os dados de um comentario específico
        /// </summary>
        /// <param name="comentarioId">Identificador do comentario</param>
        /// <response code="200">Dados do comentario consultado</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{comentarioId}")]
        public async Task<IActionResult> GetComentario(int comentarioId)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByUserNameAsync(User.GetUserNameClaim());

                if (usuario == null)
                {
                    return Unauthorized();
                }

                var comentario = await _comentarioService.GetComentarioByIdAsync(comentarioId);

                if (comentario == null) return NotFound("Não existe comentario cadastrado para o Id informado");

                return Ok(comentario);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar comentario por Id. Erro: {e.Message}");
            }
        }
    }
}
