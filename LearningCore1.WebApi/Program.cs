using LearningCore1.WebApi.DataAccess;
using LearningCore1.WebApi.Endpoints;
using LearningCore1.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.BearerScheme;
        options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
        options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
    })
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<TaskUser>()
    .AddEntityFrameworkStores<TaskItemsContext>()
    .AddApiEndpoints();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.AddSqlServerDbContext<TaskItemsContext>("TaskItemsDb");

var app = builder.Build();

app.MapDefaultEndpoints();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Services.CreateScope().ServiceProvider
        .GetRequiredService<TaskItemsContext>()
        .Database.Migrate();
    
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithDefaultHttpClient(ScalarTarget.Http, ScalarClient.Http);
    });
}

app.UseHttpsRedirection();
app.MapTaskEndpoints();
app.MapIdentityApi<TaskUser>();

app.Run();

