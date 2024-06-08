using BibCorpPrevenir2.Domain.Models.Usuarios;
using BibCorpPrevenir2.Domain.Models.Acervos;
namespace BibCorpPrevenir2.Domain.Models.Comentarios
{
    public class Comentario
    {
        public int Id { get; set; }
        public int AcervoId { get; set; }
        public int UserId { get; set; }
        public string ComentarioTxt { get; set; }
        public int Avaliacao { get; set; }
        public Acervo Acervo { get; set; }
        public Usuario Usuario { get; set; }
        
    }
}