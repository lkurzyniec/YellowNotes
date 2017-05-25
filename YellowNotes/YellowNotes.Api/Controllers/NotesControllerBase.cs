using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using YellowNotes.Api.Interfaces;
using YellowNotes.Api.Services;
using YellowNotes.Dto;

namespace YellowNotes.Api.Controllers
{
    public abstract class NotesControllerBase : ApiController
    {
        private readonly ClaimsIdentity _claimsIdentity;

        protected NotesControllerBase()
        {
            _claimsIdentity = RequestContext.Principal.Identity as ClaimsIdentity;
            Logger = new FakeLogger();
        }

        protected static readonly Dictionary<int, NoteDto> Notes =
            new Dictionary<int, NoteDto>
            {
                [1] = new NoteDto {Id = 1, Title = "Title 1", Content = "Content 1", CreatedAt = "DB"},
                [2] = new NoteDto {Id = 2, Title = "Title 2", Content = "Content 2", CreatedAt = "DB"},
            };

        internal ILogger Logger { get; }

        protected string Device => _claimsIdentity.IsAuthenticated
            ? _claimsIdentity.FindFirst(ApiConstants.ClaimDevice).Value
            : string.Empty;
    }
}