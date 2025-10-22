using CourtReservation_Core.Interfaces;
using CourtReservation_Core.Interfaces.Services_Interfaces;
using CourtReservation_Core.Services;
using CourtReservation_Infraestructure.Context;
using CourtReservation_Infraestructure.Repositories;
using CourtReservation_Infraestructure.Validators;
using Microsoft.EntityFrameworkCore;


namespace CourtReservation_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IReservaService, ReservaService>();
            builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
            builder.Services.AddScoped<ReservaDtoValidator>(); // O usa AddValidatorsFromAssembly si tienes varios
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}

