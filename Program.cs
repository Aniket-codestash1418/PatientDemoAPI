
using Microsoft.EntityFrameworkCore;
using PatientDemoAPI.DatabaseContext;
using PatientDemoAPI.Services;

namespace PatientDemoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Registering DbContext to use Database operations
            builder.Services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("Dbcon")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            //Registering Services to be used as Dependency Injection in Controllers
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IPractitionerService, PractitionerService>();
            builder.Services.AddScoped<IEncounterService, EncounterService>();
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
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
