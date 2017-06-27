using Microsoft.EntityFrameworkCore;

namespace ConferenceBarrel.Models
{
    public class ApplicationDbContext : DbContext
    {
        // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //     : base(options)
        // {
        // }
        public DbSet<InterviewData> InterviewDatas { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=./confbarrel.db");
        } 
    }
}