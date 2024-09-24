
using Blog.Infrastructure.DBContext;
using Blog.WebAPI.ExceptionHandler;
using Blog.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Blog.Application.Features.BlogPost.Command;
using Blog.Application.AutoMapper;
using Asp.Versioning;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Blog.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDb")));

            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.RegisterServices();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBlogPostCommandHandler).Assembly));

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API v1",
                    Description = "API version 1.0"
                });

                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "My API v2",
                    Description = "API version 2.0"
                });
            });

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });



            builder.Services.AddHealthChecks()
                .AddDbContextCheck<BlogDbContext>()
                .AddSqlServer(builder.Configuration.GetConnectionString("BlogDb")!, name: "SqlServer",
                    failureStatus: HealthStatus.Unhealthy);
               

            builder.Services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
                opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
                opt.SetApiMaxActiveRequests(1); //api requests concurrency    
               
            }).AddInMemoryStorage();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "My API v2");
                });
            }
            
            app.MapHealthChecks("/health", new()
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });

            app.MapHealthChecksUI(o =>
            {
                o.UIPath = "/healthDashboard";
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
