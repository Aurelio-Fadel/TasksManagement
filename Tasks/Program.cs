using Microsoft.EntityFrameworkCore;
using TaskManagement.Management.Applications;
using TaskManagement.Management.Applications.Src;
using TaskManagement.Management.DataContext;
using TaskManagement.Management.Repositories;
using TaskManagement.Management.Repositories.Src;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonApplication, PersonApplication>();
builder.Services.AddScoped<ITaskApplication, TaskApplication>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();


builder.Services.AddDbContext<TaskManagementContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
