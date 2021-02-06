using System.ComponentModel.DataAnnotations;

namespace YellowNotes.Api.Dto
{
    /// <summary>
    /// Note object
    /// </summary>
    public class NoteDto : DtoBase
    {
        /// <summary>
        /// Title of Note
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content of Note
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Rank of Note
        /// </summary>
        [Range(0, 5)]
        public int Rank { get; set; }

        /// <summary>
        /// Device type where Note were created
        /// </summary>
        public string CreatedAt { get; set; }
    }
}
