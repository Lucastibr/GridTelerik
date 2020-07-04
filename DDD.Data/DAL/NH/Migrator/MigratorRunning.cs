using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Data.DAL.NH.Migrator
{
    public class MigratorRunning
    {
        public static void Initialize()
        {
            var provider = CreateServices();

            using var run = provider.CreateScope();
            UpdateDatabase(run.ServiceProvider);
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(p => p
                    .AddSqlServer()
                    .WithGlobalConnectionString("Server=.\\BDLUCAS; Database=GamesCodout; User=sa; Password=123456; MultipleActiveResultSets=true")
                    .ScanIn(typeof(MigratorRunning).Assembly).For.Migrations())
                .AddLogging(p => p.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
