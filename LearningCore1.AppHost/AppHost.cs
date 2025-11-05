var builder = DistributedApplication.CreateBuilder(args);
var sql = builder.AddSqlServer("sqlServer");
var db = sql.AddDatabase("TaskItemsDb");

builder.AddProject<Projects.LearningCore1>("learningcore1")
    .WithReference(db)
    .WaitFor(db);

builder.Build().Run();
