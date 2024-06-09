using BibCorpPrevenir2.Application.Dtos.Acervos;
using BibCorpPrevenir2.Application.Dtos.Usuarios;
using BibCorpPrevenir2.Domain.Models.Acervos;
using BibCorpPrevenir2.Domain.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCorpPrevenir2.Application.Dtos.Comentarios
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public int AcervoId { get; set; }
        public int UserId { get; set; }
        public string ComentarioTxt { get; set; }
        public int Avaliacao { get; set; }
        public AcervoDto AcervoDto { get; set; }
        public UsuarioDto UsuarioDto { get; set; }
    }
}
