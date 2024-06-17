using BibCorpPrevenir2.Domain.Models.Acervos;
using BibCorpPrevenir2.Domain.Models.Comentarios;
using BibCorpPrevenir2.Domain.Models.Emprestimos;
using BibCorpPrevenir2.Persistence.Configuration.Classes;
using BibCorpPrevenir2.Persistence.Contexts;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Comentarios;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorpPrevenir2.Persistence.Interfaces.Implementations.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BibCorpPrevenir2.Persistence.Interfaces.Implementations.Comentarios
{
    public class ComentarioPersistence : SharedPersistence, IComentarioPersistence
    {
        private readonly BibCorpPrevenir2Context _context;

        public ComentarioPersistence(BibCorpPrevenir2Context context) : base(context)
        { 
            _context = context;
                   }
        public async Task<IEnumerable<Comentario>> GetComentarioByAcervoIdAsync(int acervoId)
       {
            IQueryable<Comentario> query = _context.Comentarios
              .Include(c => c.Usuario)
              .Include(c => c.Acervo)
              .AsNoTracking()
              .Where(a => a.AcervoId == acervoId)
              .OrderByDescending(c => c.Id);

#pragma warning disable CS8603 // Possible null reference return.
            return await query.ToListAsync(); ;
#pragma warning restore CS8603 // Possible null reference return.
    }
        public async Task<Comentario> GetComentarioByIdAsync(int comentarioId)
        {
            IQueryable<Comentario> query = _context.Comentarios
              .Include(c => c.Acervo)
              .Include(c => c.Usuario)
              .AsNoTracking()
              .Where(c => c.Id == comentarioId);

#pragma warning disable CS8603 // Possible null reference return.
            return await query.FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

    }
}
