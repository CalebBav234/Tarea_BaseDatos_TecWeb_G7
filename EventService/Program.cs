using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<EventService.Data.AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

//scoped solo para db externo y singleton para db en memoria

builder.Services.AddScoped<EventService.Repositories.IEventRepository, EventService.Repositories.EventRepository>();
builder.Services.AddScoped<EventService.Services.IEventService, EventService.Services.EventService>();
builder.Services.AddScoped<EventService.Repositories.IGuestRepository, EventService.Repositories.GuestRepository>();
builder.Services.AddScoped<EventService.Services.IGuestService, EventService.Services.GuestService>();
var app = builder.Build();
// Dependency Injection


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();