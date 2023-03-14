using App.WebAPI.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<App.Data.Model.Context>(options =>
    options.UseSqlServer("ConnString")
);
builder.Services.AddSingleton<SecurityEndpoint>();
builder.Services.AddSingleton<ProfileEndpoint>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("home", ([FromServices] App.Data.Model.Context context) =>
{
    return "Santo Padre";

});

app.MapGet("/api/people", () =>
{


});

app.Services.GetRequiredService<SecurityEndpoint>().Configure(app);
app.Services.GetRequiredService<ProfileEndpoint>().Configure(app);

app.Run();