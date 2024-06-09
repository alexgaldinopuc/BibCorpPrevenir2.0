using AutoMapper;
using BibCorpPrevenir2.Application.Dtos.Acervos;
using BibCorpPrevenir2.Application.Dtos.Comentarios;
using BibCorpPrevenir2.Application.Services.Contracts.Comentarios;
using BibCorpPrevenir2.Domain.Models.Acervos;
using BibCorpPrevenir2.Domain.Models.Comentarios;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Acervos;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Comentarios;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorpPrevenir2.Persistence.Interfaces.Contracts.Patrimonios;
using BibCorpPrevenir2.Persistence.Interfaces.Implementations.Acervos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCorpPrevenir2.Application.Services.Implements.Comentarios
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioPersistence _comentarioPersistence;
        private readonly IMapper _mapper;

        public ComentarioService(IComentarioPersistence comentarioPersistence,
            IMapper mapper)
        {
            _comentarioPersistence = comentarioPersistence;
            _mapper = mapper;
        }

        public async Task<ComentarioDto> CreateComentario(ComentarioDto comentarioDto)
        {
            try
            {
                var comentario = _mapper.Map<Comentario>(comentarioDto);

                _comentarioPersistence.Create<Comentario>(comentario);

                if (await _comentarioPersistence.SaveChangesAsync())
                {
                    var comentarioRetorno = await _comentarioPersistence.GetComentarioByIdAsync(comentario.Id);

                    return _mapper.Map<ComentarioDto>(comentarioRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ComentarioDto> GetComentarioByAcervoIdAsync(int acervoId)
        {
            try
            {
                var comentario = await _comentarioPersistence.GetComentarioByAcervoIdAsync(acervoId);

                if (comentario == null) return null;

                var comentarioMapper = _mapper.Map<ComentarioDto>(comentario);

                return comentarioMapper;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<ComentarioDto> GetComentarioByIdAsync(int comentarioId)
        {
            try
            {
                var comentario = await _comentarioPersistence.GetComentarioByIdAsync(comentarioId);

                if (comentario == null) return null;

                var comentarioMapper = _mapper.Map<ComentarioDto>(comentario);

                return comentarioMapper;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
