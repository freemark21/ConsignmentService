using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignmentService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                //.WriteTo.File(@"C:\test\log.txt", rollingInterval: RollingInterval.Month)
                .WriteTo.File(@"\\REP-APP\temp\conissu\log.txt", rollingInterval: RollingInterval.Month)
                .CreateLogger();

            try
            {
                Log.Information("Application Started.");
                CreateHostBuilder(args).Build().Run();

            }
            catch (Exception e)
            {

                Log.Fatal(e, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            CreateHostBuilder(args).Build().Run();

        }


        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).UseWindowsService().ConfigureServices((hostContext, services)
                => { services.AddHostedService<Worker>(); }).UseSerilog();
    }
}
