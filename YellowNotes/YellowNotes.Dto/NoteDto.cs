using System.ComponentModel.DataAnnotations;

namespace YellowNotes.Dto
{
    public class NoteDto : DtoBase
    {
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(0, 5)]
        public int Rank { get; set; }
    }
}