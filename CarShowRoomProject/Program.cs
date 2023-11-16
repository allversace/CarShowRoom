using CarShowRoomProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarShowRoomDbContext>(options =>
{
    options.UseSqlServer(connection);
});

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
