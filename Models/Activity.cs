namespace Christmas_Holiday.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int MemberId { get; set; }

        public Member Members { get; set; }
    }
}
