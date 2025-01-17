using ESSmAPI.Data;
using ESSmAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddDbContext<EmployeeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddDbContext<LeaveRequestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddDbContext<OvertimeRequestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.WebHost.UseUrls("https://*:5122");

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
