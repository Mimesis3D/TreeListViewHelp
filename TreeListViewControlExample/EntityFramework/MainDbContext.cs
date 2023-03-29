using EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ObjectCollectionDTO> ObjectCollections { get; set; }

        public DbSet<SessionDTO> Sessions { get; set; }

        public DbSet<ProjectDTO> Projects { get; set; }

        public DbSet<TaskDTO> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectCollectionDTO>()
                .HasMany(oc => oc.ProjectList)
                .WithOne(oc => oc.ParentObjectCollection)
                .HasForeignKey(p => p.ParentObjectCollectionId);
            modelBuilder.Entity<ObjectCollectionDTO>()
                .HasMany(oc => oc.SessionList)
                .WithOne(oc => oc.ParentObjectCollection)
                .HasForeignKey(p => p.ParentObjectCollectionId);
            modelBuilder.Entity<ObjectCollectionDTO>()
                .HasMany(oc => oc.TaskList)
                .WithOne(oc => oc.ParentObjectCollection)
                .HasForeignKey(oc => oc.ParentObjectCollectionId);

            modelBuilder.Entity<ProjectDTO>()
                .HasMany(p => p.ProjectList)
                .WithOne(p => p.ParentProject)
                .HasForeignKey(p => p.ParentProjectId);
            modelBuilder.Entity<ProjectDTO>()
                .HasMany(p => p.SessionList)
                .WithOne(p => p.ParentProject)
                .HasForeignKey(p => p.ParentProjectId);
            modelBuilder.Entity<ProjectDTO>()
                .HasMany(p => p.TaskList)
                .WithOne(p => p.ParentProject)
                .HasForeignKey(p => p.ParentProjectId);

            modelBuilder.Entity<SessionDTO>()
                .HasMany(s => s.ProjectList)
                .WithOne(s => s.ParentSession)
                .HasForeignKey(s => s.ParentSessionId);
            modelBuilder.Entity<SessionDTO>()
                .HasMany(s => s.SessionList)
                .WithOne(s => s.ParentSession)
                .HasForeignKey(p => p.ParentSessionId);
            modelBuilder.Entity<SessionDTO>()
                .HasMany(s => s.TaskList)
                .WithOne(t => t.ParentSession)
                .HasForeignKey(t => t.ParentSessionId);

            modelBuilder.Entity<TaskDTO>()
                .HasMany(t => t.ProjectList)
                .WithOne(t => t.ParentTask)
                .HasForeignKey(p => p.ParentTaskId);
            modelBuilder.Entity<TaskDTO>()
                .HasMany(t => t.SessionList)
                .WithOne(t => t.ParentTask)
                .HasForeignKey(p => p.ParentTaskId);
            modelBuilder.Entity<TaskDTO>()
                .HasMany(t => t.TaskList)
                .WithOne(t => t.ParentTask)
                .HasForeignKey(t => t.ParentTaskId);
        }
    }
}
