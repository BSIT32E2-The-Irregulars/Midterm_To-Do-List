 using Microsoft.EntityFrameworkCore;
 using TodoList.Domain;

 namespace Todolist.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDoS { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } // Add this property
        public DbSet<Status> Statuses { get; set; } // Add this property
        public class Category
        {
            public string CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
               
               
        }
        public class Status
        {
            public string StatusId { get; set; }
            public string StatusName { get; set; }
            public string StatusDescription { get; set; }
            public string StatusType { get; set; }

        }

        //seed datasdfns

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = "work", Name = "Work" },
                    new Category { CategoryId = "home", Name = "Home" },
                    new Category { CategoryId = "ex", Name = "Exercise" },
                    new Category { CategoryId = "shop", Name = "Shopping" },
                    new Category { CategoryId = "school", Name = "School" },
                    new Category { CategoryId = "anime", Name = "Anime" },
                    new Category { CategoryId = "movie", Name = "Movie" }


                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", StatusName = "Open" },
                new Status { StatusId = "closed", StatusName = "Completed" }
                );
        }
    }
}