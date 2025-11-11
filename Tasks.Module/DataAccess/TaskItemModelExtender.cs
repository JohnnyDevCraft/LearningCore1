using LearningCore1.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.WebApi.DataAccess;

public static class ModelExtensions
{
    public static ModelBuilder AddTaskItemModel(this ModelBuilder mb)
    {
        mb.HasDefaultSchema("TaskItems");

        mb.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.AssignedToId);
        });

        return mb;
    }
}