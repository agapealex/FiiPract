using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
           : base("Server = DESKTOP-U2QU3PK\\SQLEXPRESS; Database = Agape--Alex; Trusted_Connection = true;")
        {
        }
        public DbSet<TablePerson> TablePersons { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TablePerson>()
             .HasMany(s => s.Questions)
             .WithMany(c => c.TablePersons)
             .Map(cs =>
             {
                 cs.MapLeftKey("TablePersonId");
                 cs.MapRightKey("QuestionId");
                 cs.ToTable("TablePersonsToQuestions");
             });
        }
    }
}
