using IKTKC2_SG1_21_22_2.Models;
using Microsoft.EntityFrameworkCore;

namespace IKTKC2_SG1_21_22_2.Data
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerContext()
        {
            Database.EnsureCreated();
        }

        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var p1 = new Player() { PlayerId = 1, Name = "Apró Elek", Email = "aproelek@gmail.com", PhoneNumber = "06-1-234-5678", 
                DateOfBirth = new System.DateTime(1992, 3, 4), Active = true };
            var p2 = new Player() { PlayerId = 2, Name = "Kicsi Elek", Email = "kicsielek@gmail.com", PhoneNumber = "06-1-345-6789", 
                DateOfBirth = new System.DateTime(1993, 4, 5), Active = true };
            var p3 = new Player() { PlayerId = 3, Name = "Közepes Elek", Email = "kozepeselek@gmail.com", PhoneNumber = "06-1-456-7899", 
                DateOfBirth = new System.DateTime(1994, 5, 6), Active = false };
            var p4 = new Player() { PlayerId = 4, Name = "Nagy Elek", Email = "nagyelek@gmail.com", PhoneNumber = "06-1-567-8999", 
                DateOfBirth = new System.DateTime(1995, 6, 7), Active = false };
            var p5 = new Player() { PlayerId = 5, Name = "Óriás Elek", Email = "oriaselek@gmail.com", PhoneNumber = "06-1-678-9999", 
                DateOfBirth = new System.DateTime(1996, 7, 8), Active = true };
            var p6 = new Player() { PlayerId = 6, Name = "Gigantikus Elek", Email = "gigantikuselek@gmail.com", PhoneNumber = "06-1-789-9999", 
                DateOfBirth = new System.DateTime(1997, 8, 9), Active = true };


            modelBuilder.Entity<Player>().HasData(p1, p2, p3, p4, p5, p6);
        }
    }
}
