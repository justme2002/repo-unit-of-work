using App.Infrastructure;
using App.Infrastructure.Data;
using App.Infrastructure.Interface;
using App.Infrastructure.Repositories;
using App.Services;
using App.Services.Interface;
using App.Services.Mapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(ProfileMapper));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//DI

builder.Services
        .AddScoped<DBFactory>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>))
        .AddScoped<IMapper, Mapper>()
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUserService, UserService>();

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
