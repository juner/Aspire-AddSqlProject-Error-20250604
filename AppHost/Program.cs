using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

// var sqlserver =
//    builder.AddSqlServer("sql")
//    .WithDataVolume()
//    .AddDatabase("data");

var dbProjectEnable = builder.Configuration.GetValue("database_project_enable", true);
if (dbProjectEnable)
  builder.AddSqlProject<Projects.Database>("database");
//      .WithReference(sqlserver);

builder.AddProject<Projects.WebApp>("webapp");
  // .WithReference(sqlserver)
  // .WaitFor(sqlserver);

builder.Build().Run();
