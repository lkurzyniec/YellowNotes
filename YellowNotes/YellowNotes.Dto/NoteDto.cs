using System.ComponentModel.DataAnnotations;

namespace YellowNotes.Dto
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

        [Range(0, 5)]
        public int Rank { get; set; }

        public string CreatedAt { get; set; }
    }
}