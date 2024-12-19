using Microsoft.EntityFrameworkCore;

namespace Christmas_Holiday.Models
{
    public class ChristmasContext : DbContext
    {
        public DbSet<Activity> Activities {  get; set; }
        public DbSet<Member> Members { get; set; }

        public ChristmasContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ChristmasData.db");
        }
        public ChristmasContext(DbContextOptions<ChristmasContext> options) : base(options)
        {
        }
    }
}
