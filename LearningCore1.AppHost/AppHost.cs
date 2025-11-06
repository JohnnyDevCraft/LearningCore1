var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sqlServer");
var db = sql.AddDatabase("TaskItemsDb");

builder.AddProject<Projects.LearningCore1_WebApi>("learningcore1-webapi")
    .WithReference(db)
    .WaitFor(db)
    .WithUrl("/scalar");

builder.Build().Run();
