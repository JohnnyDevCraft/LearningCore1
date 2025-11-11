using LearningCore1.WebApi.DataAccess;
using LearningCore1.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Tasks.Module.EndPoints;
using Tasks.Module.Sevices;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.Services.AddMediator(options =>
{
    options.Assemblies = [typeof(CreateNewTaskRequestHandler).Assembly];
    options.Namespace = "LearningCore1.WebApi.Mediator";
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.BearerScheme;
        options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
        options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
    })
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<TaskUser>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddApiEndpoints();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.AddSqlServerDbContext<AuthDbContext>("TaskItemsDb");

var app = builder.Build();

app.MapDefaultEndpoints();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Services.CreateScope().ServiceProvider
        .GetRequiredService<AuthDbContext>()
        .Database.Migrate();
    
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithDefaultHttpClient(ScalarTarget.Http, ScalarClient.Http);
    });
}

app.UseHttpsRedirection();
app.UseTaskItemModule();
app.MapIdentityApi<TaskUser>();

app.Run();