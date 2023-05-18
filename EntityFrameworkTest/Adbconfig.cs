using System.Data.Entity;

namespace EntityFrameworkTest
{
    internal class Adbconfig : DbContext
    {
        public  DbSet<Student> students;
       public Adbconfig() :base("name=AyushLearnDbName")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

        }
    }
}