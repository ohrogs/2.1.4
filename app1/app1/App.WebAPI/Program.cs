using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<App.Data.Model.Context>(options =>
    options.UseSqlServer("ConnString")
);

var app = builder.Build();

// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapPost("/security/login/", () =>
{
    return "Santo Padre";

});

app.MapGet("/security/logout/", () =>
{
    return "Santo Padre";

});

app.MapGet("/profile/get/person/", () =>
{
    return "Santo Padre";

});

app.MapPost("/profile/create/person/", () =>
{
    return "Santo Padre";

});

app.MapPut("/profile/update/person/", () =>
{
    return "Santo Padre";

});

app.MapPut("/security/update/user/", () =>
{
    return "Santo Padre";

});

app.MapDelete ("/profile/delete/person/", () =>
{
    return "Santo Padre";

});

app.MapGet("/api/people", () =>
{


});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
