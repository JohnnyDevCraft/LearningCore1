using LearningCore1.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.DataAccess;

public static class ModelExtensions
{
    public static ModelBuilder AddTaskItemModel(this ModelBuilder mb)
    {

        mb.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        return mb;
    }
}
