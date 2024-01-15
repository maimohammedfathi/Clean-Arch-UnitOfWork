using Clean_Arch___UnitOFWork.Core.Interface;
using Clean_Arch___UnitOFWork.Core.Repositories;
using Clean_Arch___UnitOFWork.Core;
using Clean_Arch___UnitOFWork.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clean_Arch___UnitOFWork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configuer Service
            // Add services to the container.
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

            // Configure repositories
            builder.Services.AddTransient<IBookRepository, BookRepository>();
            builder.Services.AddTransient<IMagazineRepository, MagazineRepository>();

            // Configure Unit of Work
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
            #endregion

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}