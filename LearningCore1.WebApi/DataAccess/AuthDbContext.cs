using LearningCore1.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningCore1.WebApi.DataAccess;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext<TaskUser, IdentityRole<Guid>, Guid>(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}