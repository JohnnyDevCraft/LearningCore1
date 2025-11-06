using Microsoft.AspNetCore.Identity;

namespace LearningCore1.WebApi.Entities;

public class TaskUser: IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}