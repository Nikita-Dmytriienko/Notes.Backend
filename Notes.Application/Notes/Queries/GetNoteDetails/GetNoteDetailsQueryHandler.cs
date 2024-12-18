using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            /*var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId!=request.UserId)
            {
                throw new NotFoundException(nameof(Note),request.Id);
            }
            return _mapper.Map<NoteDetailsVm>(entity);*/
            {

                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                try
                {
                    var entity = await _dbContext.Notes
                        .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

                    if (entity == null)
                    {
                       
                        throw new NotFoundException(nameof(Note), request.Id);
                    }

                    if (entity.UserId != request.UserId)
                    {
                        throw new UnauthorizedAccessException("User is not authorized to access this note.");
                    }

                    
                    return _mapper.Map<NoteDetailsVm>(entity);
                }
                catch (Exception ex)
                {
                    
                    throw new ApplicationException("Error occurred while retrieving note details.", ex);
                }
            }
        }
    }
}
