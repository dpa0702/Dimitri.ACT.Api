
using Dimitri.ACT.EntryMS.Data;
using Dimitri.ACT.EntryMS.Repositories;
using Dimitri.ACT.EntryMS.Repositories.Interfaces;
using Dimitri.ACT.EntryMS.Services;
using Dimitri.ACT.EntryMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dimitri.ACT.EntryMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IEntryRepository, EntryRepository>();
            builder.Services.AddScoped<IEntryService, EntryService>();

            builder.Services.AddDbContext<EntryMSContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("EntryContext")
                ?? throw new InvalidOperationException("Connection string not found")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
