using BusinessObjects;
using Chapter02_PRN232.Helpers;
using Microsoft.EntityFrameworkCore;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Implements;
using Services.Interfaces;

namespace Chapter02_PRN232
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers().AddXmlSerializerFormatters();

            builder.Services.AddControllers(options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter());
            });

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPlayerService, PlayerService>();

            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


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
