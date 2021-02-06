using System.Collections.Generic;
using YellowNotes.Api.Dto;

namespace YellowNotes.Api.Repositories
{
    public interface INotesRepository
    {
        Dictionary<int, NoteDto> Notes { get; }
    }

    public class NotesRepository : INotesRepository
    {
        private static readonly Dictionary<int, NoteDto> _notes =
            new Dictionary<int, NoteDto>
            {
                [1] = new NoteDto { Id = 1, Title = "Title 1", Content = "Content 1", CreatedAt = "DB" },
                [2] = new NoteDto { Id = 2, Title = "Title 2", Content = "Content 2", CreatedAt = "DB" },
            };

        public Dictionary<int, NoteDto> Notes => _notes;
    }
}
