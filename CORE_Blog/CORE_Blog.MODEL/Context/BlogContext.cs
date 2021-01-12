using CORE_Blog.CORE.Entity;
using CORE_Blog.MODEL.Entities;
using CORE_Blog.MODEL.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE_Blog.MODEL.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        { }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            //Silmiyoruz!
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ozkaynak\\MSSQLDILARA; database= BuBiBlogDB; uid=sa; pwd=123;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Environment.MachineName;
            string ipAddress = "127.0.0.1";
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item !=null)
                {
                    switch (item.State)
                    {                       
                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIP = ipAddress;
                            entity.ModifiedDate = date;
                            break;
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = ipAddress;
                            entity.CreatedDate = date;
                            break;                       
                    }
                }
            }
            // Silmiyoruz.
            return base.SaveChanges();
        }
    }
}
