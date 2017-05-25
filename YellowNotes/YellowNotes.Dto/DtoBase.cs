using System.ComponentModel.DataAnnotations;

namespace YellowNotes.Dto
{
    public abstract class DtoBase
    {
        /// <summary>
        /// Object ID
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
