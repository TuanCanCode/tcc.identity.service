using AutoWrapper;
using Serilog;
using Tcc.Identity.Api.Middleware;
using Tcc.Identity.Application;
using Tcc.Identity.DataAccess;

namespace Tcc.Identity.Api
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Config SeriLog
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .CreateLogger());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddDataAccess(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseApiResponseAndExceptionWrapper();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            
            app.Run();
        }
    }
}
