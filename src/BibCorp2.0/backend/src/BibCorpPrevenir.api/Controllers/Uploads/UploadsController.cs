using BibCorpPrevenir.API.Util.Security;
using BibCorpPrevenir.Application.Services.Contracts.Usuarios;
using BibCorpPrevenir.Application.Services.Packages.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibCorpPrevenir.API.Controllers.Uploads
{
    [Authorize]
    [Route("api/[controller]")]
    public class UploadsController : Controller
    {
        private readonly IUploadService _uploads;
        private readonly IUsuarioServices _usuarioService;
        private readonly string _destinoFoto = "Fotos";
        public UploadsController(
            IUploadService uploadService,
            UsuarioServices usuarioService)
        {
            _uploads = uploadService;
            _usuarioService = usuarioService;
        }


        [HttpPost("upload-user-photo")]
        public async Task<IActionResult> UploadFotoUser()
        {
            try
            {
                Console.WriteLine("---------------------- " + User.GetUserNameClaim());
                var user = await _usuarioService.GetUsuarioByUserNameAsync(User.GetUserNameClaim());

                if (user == null) return NoContent();

                var file = Request.Form.Files[0];

                if (file.Length > 0) {
                    _uploads.DeleteImageUpload(user.Id, user.FotoURL, _destinoFoto);
                    user.FotoURL = await _uploads.SaveImageUpload(user.Id, file, _destinoFoto);
                }

                return Ok(await _usuarioService.UpdateUsuario(user));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar upload de fotos. Erro: {e.Message}");
            }
        }
    }
}
