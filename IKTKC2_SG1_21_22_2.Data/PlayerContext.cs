using IKTKC2_SG1_21_22_2.Models;
using Microsoft.EntityFrameworkCore;

namespace IKTKC2_SG1_21_22_2.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }

        public PlayerContext()
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
