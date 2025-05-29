
using LibraryManagement.Data;
using LibraryManagement.Data.IRepository;
using LibraryManagement.Data.Repository;
using LibraryManagement.Services.IServices;
using LibraryManagement.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Repository 
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            //Service
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IClientService, ClientService>();


            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"))
            );

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
