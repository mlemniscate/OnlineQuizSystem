using Framework.Core.Identity;
using Framework.Identity;
using Framework.Identity.Configurations;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.API.Seed;
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

// Identity
builder.Services.AddApplicationIdentity(new IdentityConfiguration
{
    ValidAudience = builder.Configuration["JWT:ValidAudience"]!,
    ValidIssuer = builder.Configuration["JWT:ValidAudience"]!,
    Secret = builder.Configuration["JWT:Secret"]!,
    IdentityConnectionString = builder.Configuration.GetConnectionString("Identity")!
});

var app = builder.Build();

// Seed Data
using var scope = app.Services.CreateScope();
var identityDbContext = scope.ServiceProvider.GetService<IIdentityService>();
var seedData = new SeedData(identityDbContext);
await seedData.Seed();

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
