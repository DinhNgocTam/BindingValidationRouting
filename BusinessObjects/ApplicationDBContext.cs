using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelSeeder.Seed(modelBuilder);
            modelBuilder
                .Entity<Player>()
                .HasMany(p => p.PlayerInstruments)
                .WithOne(pi => pi.Player)
                .HasForeignKey(pi => pi.PlayerId);

            modelBuilder
                .Entity<InstrumentType>()
                .HasMany(it => it.PlayerInstruments)
                .WithOne(pi => pi.InstrumentType)
                .HasForeignKey(pi => pi.InstrumentTypeId);
        }
    }
}
