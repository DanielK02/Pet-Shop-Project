using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Services
{
    public class PetShopDbContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        private string DbPath { get; set; }
        public PetShopDbContext(IConfiguration config)
        {
            DbPath = config.GetConnectionString("PetShopDb");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(DbPath);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding DB with initial data when creating model
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId = 1, Age = 7, CategoryId = 1, Description = "Woof", Name = "Dog", ImagePath = "/dog.jpg" },
                new Animal { AnimalId = 2, Age = 3, CategoryId = 1, Description = "Meow", Name = "Cat", ImagePath = "/cat.jpg" },
                new Animal { AnimalId = 3, Age = 4, CategoryId = 1, Description = "LionDesc", Name = "Lion", ImagePath = "/lion.jpg" },
                new Animal { AnimalId = 4, Age = 5, CategoryId = 1, Description = "WolfDesc", Name = "Wolf", ImagePath = "/wolf.jpg" },
                new Animal { AnimalId = 5, Age = 29, CategoryId = 2, Description = "TurtleDesc", Name = "Turtle", ImagePath = "/turtle.jpg" },
                new Animal { AnimalId = 6, Age = 12, CategoryId = 2, Description = "IguanaDesc", Name = "Iguana", ImagePath = "/iguana.jpg" },
                new Animal { AnimalId = 7, Age = 2, CategoryId = 3, Description = "DolphinDesc", Name = "Dolphin", ImagePath = "/dolphin.jpg" });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Mammal"},
                new Category { CategoryId = 2, Name = "Reptile"},
                new Category { CategoryId = 3, Name = "Aquatic"});

            modelBuilder.Entity<Comments>().HasData(
                new Comments { CommentId = 1, AnimalId = 1, Comment = "Dogs are the best!" },
                new Comments { CommentId = 2, AnimalId = 1, Comment = "Awesome dog!"},
                new Comments { CommentId = 3, AnimalId = 5, Comment = "Turtles are cool!" });
        }
    }
}
