using LearningCore1.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.WebApi.DataAccess;

public class TaskItemsContext(DbContextOptions<TaskItemsContext> options) : IdentityDbContext<TaskUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<TaskItem> TaskItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddTaskItemModel();
        base.OnModelCreating(modelBuilder);
    }
}