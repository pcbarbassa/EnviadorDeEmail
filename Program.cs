global using Flunt.Notifications;
global using Flunt.Validations;
global using PCB.EnviadorDeEmail.Configuration;
global using PCB.EnviadorDeEmail.Domain.Handlers;
global using PCB.EnviadorDeEmail.Service;
using Microsoft.AspNetCore.ResponseCompression;
using NLog;
using System.Text.Json.Serialization;


var logger = LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")).GetCurrentClassLogger();
try
{
    logger.Debug("Inicialização do aplicativo");
    var builder = WebApplication.CreateBuilder(args);

    builder.AdicionarNLogConfig();

    builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

    builder.Configuration.AddJsonFile("appsettings.json", true, true);

    builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

    builder.Configuration.AddEnvironmentVariables();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Total", builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

    builder.Services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
    });

    builder.Services.AddResponseCaching();

    builder.Services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();    

    builder.Services.AddScoped<ManipuladorDeEmail, ManipuladorDeEmail>();

    builder.Services.AddScoped<IServicoEmail, ServicoEmail>();

    var app = builder.Build();

    if (builder.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors("Total");

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/Swagger/v1/swagger.json", "v1");
    });

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Programa parado por causa de exceção");
    throw;
}
finally
{
    LogManager.Shutdown();
}
