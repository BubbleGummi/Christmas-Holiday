namespace Christmas_Holiday.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
