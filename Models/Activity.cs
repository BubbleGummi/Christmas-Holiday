using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Christmas_Holiday.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }

        public required string Description { get; set; }

        public int? MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual required Member Member { get; set; }

    }
}
