using goal_tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goal_tracker.DBContexts
{
  public class MySqlDBContext : DbContext
  {
    public DbSet<Goal> Goals { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Progress> Progress { get; set; }

    public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Use Fluent API to configure  

      // Map entities to tables  
      modelBuilder.Entity<Goal>().ToTable("Goals");
      modelBuilder.Entity<TaskItem>().ToTable("Tasks");
      modelBuilder.Entity<Progress>().ToTable("Progress");

      // Configure Primary Keys  
      modelBuilder.Entity<Goal>().HasKey(g => g.Id).HasName("PK_Goals");
      modelBuilder.Entity<TaskItem>().HasKey(t => t.Id).HasName("PK_Tasks");
      modelBuilder.Entity<Progress>().HasKey(p => p.Id).HasName("PK_Progress");

      // Configure columns  
      modelBuilder.Entity<Goal>().Property(g => g.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
      modelBuilder.Entity<Goal>().Property(g => g.GoalName).HasColumnType("nvarchar(100)").IsRequired();
      modelBuilder.Entity<Goal>().Property(g => g.PercentComplete).HasColumnType("int").IsRequired();
      modelBuilder.Entity<Goal>().Property(g => g.CreationDateTime).HasColumnType("datetime").IsRequired();
      modelBuilder.Entity<Goal>().Property(g => g.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);


      modelBuilder.Entity<TaskItem>().Property(t => t.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
      modelBuilder.Entity<TaskItem>().Property(t => t.TaskName).HasColumnType("nvarchar(100)").IsRequired();
      modelBuilder.Entity<TaskItem>().Property(t => t.Requirements).HasColumnType("nvarchar(250)").IsRequired();
      modelBuilder.Entity<TaskItem>().Property("IsComplete").HasDefaultValue(false);
      modelBuilder.Entity<TaskItem>().Property(t => t.GoalId).HasColumnType("int").IsRequired();
      modelBuilder.Entity<TaskItem>().Property(t => t.CreationDateTime).HasColumnType("datetime").IsRequired();
      modelBuilder.Entity<TaskItem>().Property(t => t.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

      modelBuilder.Entity<Progress>().Property(p => p.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
      modelBuilder.Entity<Progress>().Property(p => p.TimeSpent).HasColumnType("int").IsRequired();
      modelBuilder.Entity<Progress>().Property(p => p.DescribeProgress).HasColumnType("nvarchar(250)").IsRequired();
      // modelBuilder.Entity<Progress>().Property(p => p.GoalId).HasColumnType("int").IsRequired();
      modelBuilder.Entity<Progress>().Property(p => p.TaskId).HasColumnType("int").IsRequired();
      modelBuilder.Entity<Progress>().Property(p => p.CreationDateTime).HasColumnType("datetime").IsRequired();
      modelBuilder.Entity<Progress>().Property(p => p.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

      // Configure relationships  
      modelBuilder.Entity<TaskItem>().HasOne<Goal>().WithMany().HasPrincipalKey(g => g.Id).HasForeignKey(t => t.GoalId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Tasks_Goals");
      modelBuilder.Entity<Progress>().HasOne<TaskItem>().WithMany().HasPrincipalKey(t => t.Id).HasForeignKey(p => p.TaskId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Progress_Tasks");
    }
  }
}