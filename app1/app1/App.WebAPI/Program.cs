using App.WebAPI.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<App.Data.Model.Context>(options =>
    options.UseSqlServer("ConnString")
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("home", () =>
{
    return "Santo Padre";

});

app.MapGet("/api/people", () =>
{


});

app.Services.GetRequiredService<SecurityEndpoint>().DefineEndpoint(app);
app.Services.GetRequiredService<ProfileEndpoint>().DefineEndpoint(app);

app.Run();