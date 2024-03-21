using Microsoft.AspNetCore.Identity;

namespace BibCorpPrevenir.Domain.Models.Usuarios
{
  public class Usuario : IdentityUser<int>
  {
    public string Nome { get; set; }
    public string Localizacao { get; set; }
    public string FotoURL { get; set; }
//    public IEnumerable<Emprestimo> Emprestimos { get; set; }
    public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
  }
}
