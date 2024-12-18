using Microsoft.EntityFrameworkCore;

namespace Christmas_Holiday.Models
{
    public class ChristmasContext : DbContext
    {
        public DbSet<Activity> activities {  get; set; }
        public DbSet<Member> members { get; set; }

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
