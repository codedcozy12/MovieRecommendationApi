using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovieRecommendationApi.Domain;

namespace MovieRecommendationApi
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Rating> Rating {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
