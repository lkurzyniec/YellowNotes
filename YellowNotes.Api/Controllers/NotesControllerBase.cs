using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using YellowNotes.Api.Repositories;
using YellowNotes.Api.Services;
using YellowNotes.Api.Dto;

namespace YellowNotes.Api.Controllers
{
    public abstract class NotesControllerBase : ApiController
    {
        private readonly ClaimsIdentity _claimsIdentity;
        private readonly INotesRepository _notesRepository;

        protected NotesControllerBase(INotesRepository notesRepository, ILogger logger)
        {
            _claimsIdentity = RequestContext.Principal.Identity as ClaimsIdentity;
            Logger = logger;
            _notesRepository = notesRepository;
        }

        internal ILogger Logger { get; }

        protected Dictionary<int, NoteDto> Notes => _notesRepository.Notes;

        protected string Device => _claimsIdentity.IsAuthenticated
            ? _claimsIdentity.FindFirst(ApiConstants.ClaimDevice).Value
            : string.Empty;
    }
}
