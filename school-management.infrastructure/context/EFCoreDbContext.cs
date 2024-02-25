
using Microsoft.EntityFrameworkCore;
using school_management.shared.models;

namespace school_management.infrastructure.context
{
    public class EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : DbContext(options)
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<SchoolSubjectModel> SchoolSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModel>(e =>
            {
                e.HasKey(S => S.Id);
                e.Property(e => e.Id)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<SchoolSubjectModel>(e =>
            {
                e.HasKey(S => S.Id);
                e.Property(e => e.Id)
                    .ValueGeneratedNever();
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
