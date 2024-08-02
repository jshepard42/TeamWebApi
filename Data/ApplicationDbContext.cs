using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Models;

namespace TeamWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<FavoriteBook> FavoriteBook { get; set; }
        public DbSet<BreakfastFood> BreakfastFood { get; set; }
    }
}
