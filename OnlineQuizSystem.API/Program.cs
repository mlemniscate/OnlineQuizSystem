using Microsoft.EntityFrameworkCore;
using Quiz.Application;
using Quiz.Application.Contracts;
using Quiz.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Quiz Services
// MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly,
        typeof(CreateUserCommandHandler).Assembly);
});

// DbContext
var connectionString = builder.Configuration.GetConnectionString("QuizDatabase");
builder.Services.AddDbContext<QuizDbContext>(
    options => options.UseSqlServer(connectionString));

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
