using LearningCore1.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.DataAccess;

public class TaskItemsContext(DbContextOptions<TaskItemsContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddTaskItemModel();
        base.OnModelCreating(modelBuilder);
    }
}