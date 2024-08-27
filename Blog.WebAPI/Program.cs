
using Blog.Infrastructure.DBContext;
using Blog.WebAPI.ExceptionHandler;
using Blog.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Blog.Application.Features.BlogPost.Command;
using Blog.Application.AutoMapper;

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
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
