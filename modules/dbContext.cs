using Microsoft.EntityFrameworkCore;
using WebApplication3.modules.EmployeeEntity;

namespace WebApplication3.modules
{

    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<MasterData> MasterData { get; set; }

        public virtual DbSet<UserMaster> UserMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=192.168.1.205,21443;Initial Catalog=RahulJogPractice;User ID=sa;Password=ibis@123;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.StatusID).HasDefaultValueSql("('A')");
            });

            modelBuilder.Entity<EmployeesSample>(entity =>
            {
                entity.Property(e => e.Grade).IsFixedLength();
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
