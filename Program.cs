using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto
{
    public class Author
    {
        public int AuthorID { get; set; }
        public String Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public Author Author { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public float Price { get; set; }
        public Tag Tag { get; set; }
    }

    public class Tag
    {
        public int TagID { get; set; }
        public String Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Inetermidiate = 2,
        Advance = 3
    }

    //For database//
    public class PlutoContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoContext() : base("name=DefaultConnection")
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
