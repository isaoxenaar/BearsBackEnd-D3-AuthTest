#nullable disable

using Microsoft.EntityFrameworkCore;
using SignalRWebpack;

    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {

        }
        public DbSet<Bear> Bears { get; set; }
        public DbSet<User> Users {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(o => o.Bears).WithOne().HasForeignKey(b => b.ObserverId);
            modelBuilder.Entity<User>(entity => {entity.HasIndex(e => e.Name).IsUnique();});
            modelBuilder.Entity<User>(entity => {entity.HasIndex(e => e.Email).IsUnique();});

        }
    }