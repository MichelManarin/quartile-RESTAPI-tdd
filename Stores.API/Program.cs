using Microsoft.EntityFrameworkCore;
using Stores.API.Infrastructure;
using Stores.API.Infrastructure.Repositories;
using Stores.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICompanyRepository, CompanyRepository>();
    services.AddTransient<IStoreRepository, StoreRepository>();
    services.AddTransient<ICompanyService, CompanyService>();
    services.AddTransient<IStoreService, StoreService>();
}
