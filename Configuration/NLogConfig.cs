using NLog.Web;

namespace PCB.EnviadorDeEmail.Configuration
{
    public static class NLogConfig
    {
        public static void AdicionarNLogConfig(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();

            builder.Logging.AddConsole();

            if (builder.Environment.IsDevelopment()) builder.Logging.AddDebug();

            builder.Logging.AddEventSourceLogger();

            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

            builder.Host.UseNLog();
        }

        public static void UsarNLogConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }
    }
}
