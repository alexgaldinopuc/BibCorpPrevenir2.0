using BibCorpPrevenir2.Application.Dtos.Comentarios;
using BibCorpPrevenir2.Application.Dtos.Emprestimos;
using BibCorpPrevenir2.Domain.Enums.Emprestimo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCorpPrevenir2.Application.Services.Contracts.Comentarios
{
    public interface IComentarioService
    {
       
        Task<IEnumerable<ComentarioDto>> GetComentarioByAcervoIdAsync(int acervoId);
        Task<ComentarioDto> CreateComentario(ComentarioDto comentarioDto);
        Task<ComentarioDto> GetComentarioByIdAsync(int comentarioId);

    }
}
