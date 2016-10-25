using AssignmentFive.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace AssignmentFive.DAL
{
    public class ActivityDBContext : DbContext
    {

        public DbSet<Activity> Activities { get; set; }//take activity just defined and put it in a set called activities and give it the ability to read and write
       public DbSet<TripLeader> TripLeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//when building school context
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//remove the "s" on the table name so it's not plural (like students becomes student)
                                                                              // modelBuilder.Entity<Course>().HasMany(c => c.Instructors).WithMany(i => i.Courses)//Entity called course has many instructors and instructor has many courses.  Letters don't matter.  mapping those tables. The right key is the parent maps to left 
                                                                              //.Map(t => t.MapLeftKey("CourseID")//left hand side of table
                                                                              //.MapRightKey("InstructorID")//right hand side of table
                                                                              //.ToTable("CourseInstructor"));//What the table is called
        }


    }
}