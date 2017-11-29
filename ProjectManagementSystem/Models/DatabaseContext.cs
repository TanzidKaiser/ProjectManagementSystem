using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<AssignProjectToUser> AssignProject { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}