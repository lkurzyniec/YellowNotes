using System.Collections.Concurrent;
using System.Web.Http;
using YellowNotes.Dto;

namespace YellowNotes.Api.Controllers
{
    public abstract class NotesControllerBase : ApiController
    {
        protected static readonly ConcurrentDictionary<int, NoteDto> Notes =
            new ConcurrentDictionary<int, NoteDto>
            {
                [1] = new NoteDto {Id = 1, Title = "Title 1", Content = "Content 1"},
                [2] = new NoteDto {Id = 2, Title = "Title 2", Content = "Content 2"},
            };
    }
}