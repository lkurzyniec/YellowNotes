using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using YellowNotes.Api.Attributes;
using YellowNotes.Api.Repositories;
using YellowNotes.Api.Services;
using YellowNotes.Api.Dto;

namespace YellowNotes.Api.Controllers
{
    /// <summary>
    /// The Notes instance resource
    /// </summary>
    [ValidateModelState]
    [SimpleAuthorize(Devices = "iOS")]
    [RoutePrefix("api/good-notes")]
    public class GoodNotesController : NotesControllerBase
    {
        public GoodNotesController(INotesRepository notesRepository, ILogger logger)
            : base(notesRepository, logger)
        {

        }

        /// <summary>
        /// Returns a list of the Note objects
        /// </summary>
        /// <returns>List of Note objects</returns>
        [AllowAnonymous]
        [HttpGet, Route("")]
        [ResponseHttpStatusCode(HttpStatusCode.OK)]
        [ResponseType(typeof(IEnumerable<NoteDto>))]
        public IHttpActionResult Get()
        {
            return Ok(Notes.Values);
        }

        /// <summary>
        /// Returns a representation of the Note object
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <returns>Note object</returns>
        [AllowAnonymous]
        [HttpGet, Route("{id}", Name = "GetNote")]
        [ResponseHttpStatusCode(HttpStatusCode.OK, HttpStatusCode.NotFound)]
        [ResponseType(typeof(NoteDto))]
        public IHttpActionResult GetNote(int id)
        {
            if (!Notes.ContainsKey(id))
            {
                return NotFound();
            }

            return Ok(Notes[id]);
        }

        /// <summary>
        /// Create new Note
        /// </summary>
        /// <param name="note">Note object</param>
        /// <returns>Newly created Note</returns>
        [HttpPost, Route("")]
        [ResponseHttpStatusCode(HttpStatusCode.Created)]
        [ResponseType(typeof(NoteDto))]
        public IHttpActionResult Post([FromBody]NoteDto note)
        {
            int maxId = Notes.Keys.Count > 0 ? Notes.Keys.Max() : 0;
            note.Id = ++maxId;
            note.CreatedAt = Device;
            Notes.Add(maxId, note);

            return CreatedAtRoute("GetNote", new {id = note.Id}, note);
        }

        /// <summary>
        /// Update existing Note
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <param name="note">Note object</param>
        /// <returns></returns>
        [HttpPut, Route("{id}")]
        [ResponseHttpStatusCode(HttpStatusCode.NoContent, HttpStatusCode.NotFound)]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]NoteDto note)
        {
            NoteDto dbNote;
            if (!Notes.TryGetValue(id, out dbNote))
            {
                return NotFound();
            }
            
            dbNote.Title = note.Title;
            dbNote.Content = note.Content;
            dbNote.Rank = note.Rank;
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Delete existing Note
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        [ResponseHttpStatusCode(HttpStatusCode.NoContent, HttpStatusCode.NotFound)]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            if (!Notes.ContainsKey(id))
            {
                return NotFound();
            }
            
            Notes.Remove(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Search through Content of Notes
        /// </summary>
        /// <param name="text">Text to search</param>
        /// <returns>List of Note objects</returns>
        [HttpGet, Route("search/{text}")]
        [ResponseHttpStatusCode(HttpStatusCode.OK)]
        [ResponseType(typeof(IEnumerable<NoteDto>))]
        [ActionParametersValidation]
        public IHttpActionResult Search([RegularExpression(@"^.{3,}$")] string text)
        {
            return Ok(Notes.Values.Where(x => x.Content.Contains(text)));
        }
    }
}
