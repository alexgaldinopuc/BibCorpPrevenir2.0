using BibCorpPrevenir2.Domain.Models.Comentarios;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Shared;

namespace BibCorpPrevenir2.Persistence.Interfaces.Contracts.Comentarios
{
    public interface IComentarioPersistence : ISharedPersistence
    {
        Task<IEnumerable<Comentario>> GetComentarioByAcervoIdAsync(int acervoId);
    }
}
