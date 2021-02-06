using System.ComponentModel.DataAnnotations;

namespace YellowNotes.Dto
{
    /// <summary>
    /// Base Dto object
    /// </summary>
    public abstract class DtoBase
    {
        /// <summary>
        /// Object ID
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
