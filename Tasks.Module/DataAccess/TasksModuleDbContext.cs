using LearningCore1.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.WebApi.DataAccess;

public class TasksModuleDbContext(DbContextOptions<TasksModuleDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddTaskItemModel();
        base.OnModelCreating(modelBuilder);
    }
}