using DBFirst.Data;
using DBFirst.Services;
using Microsoft.EntityFrameworkCore;

namespace DBFirst;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();
        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<Apbd10Context>(
            opt => opt.UseSqlServer(
                builder.Configuration.GetConnectionString("Default")
            ));
        builder.Services.AddScoped<ITripsService, TripsService>();
        builder.Services.AddScoped<IClientsService, ClientsService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}