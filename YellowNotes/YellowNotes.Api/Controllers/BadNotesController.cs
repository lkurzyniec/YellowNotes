using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YellowNotes.Dto;

namespace YellowNotes.Api.Controllers
{
    public class BadNotesController : NotesControllerBase
    {
        // GET: api/BadNotes
        [AllowAnonymous]
        public IEnumerable<NoteDto> Get()
        {
            return Notes.Values;
        }

        // GET: api/BadNotes/5
        [AllowAnonymous]
        public NoteDto Get(int id)
        {
            if (Notes.ContainsKey(id))
            {
                return Notes[id];
            }

            return null;
        }

        // POST: api/BadNotes
        public void Post([FromBody]NoteDto note)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            int maxId = Notes.Keys.Max();
            note.Id = ++maxId;
            Notes.Add(maxId, note);
        }

        // PUT: api/BadNotes/5
        public void Put(int id, [FromBody]NoteDto note)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            NoteDto dbNote;
            if (!Notes.TryGetValue(id, out dbNote))
            {
                return;
            }

            dbNote.Title = note.Title;
            dbNote.Content = note.Content;
            dbNote.Rank = note.Rank;
        }

        // DELETE: api/BadNotes/5
        public void Delete(int id)
        {
            if (Notes.ContainsKey(id))
            {
                Notes.Remove(id);
            }
        }
    }
}