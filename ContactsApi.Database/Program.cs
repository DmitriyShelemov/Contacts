
using ContactApi.Database;
using DbUp;
using Microsoft.Extensions.Configuration;
using System.Reflection;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var connectionString = config
    .GetRequiredSection("ConnectionStrings")
    .Get<ConnectionStrings>()?.DefaultConnection;

EnsureDatabase.For.SqlDatabase(connectionString);

var upgrader =
     DeployChanges.To
          .SqlDatabase(connectionString)
          .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
          .WithTransactionPerScript()
          .LogToConsole()
          .Build();


var result = upgrader.PerformUpgrade();
Console.WriteLine(result.Successful ? "Success" : result.Error);