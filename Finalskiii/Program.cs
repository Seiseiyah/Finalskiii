using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.Interface;
using Finalskiii.Finalskiii.Interfaces;
using Finalskiii.Finalskiii.Repositories;
using Finalskiii.Finalskiii.Repository;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Smart_Library.SmartLibraryManagement.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<IFineRepository, FineRepository>();
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();

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
