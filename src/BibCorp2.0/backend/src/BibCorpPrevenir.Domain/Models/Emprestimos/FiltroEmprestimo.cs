namespace BibCorpPrevenir.Domain.Models.Emprestimos
{
  public class FiltroEmprestimo
  {
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public List<string> Usuarios { get; set; }
    public List<TipoStatusEmprestimo> Status { get; set; }
  }
}
