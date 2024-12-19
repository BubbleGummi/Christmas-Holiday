using System.ComponentModel.DataAnnotations;

namespace Christmas_Holiday.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        public required string Lastname { get; set; }
        //public int? ActivityId { get; set; }
        //public virtual required Activity Activity { get; set; }
        public virtual required ICollection<Activity> Activities { get; set; }
    }
}
