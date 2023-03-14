using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{
    public class ProfileEndpoint
    {
        public void Configure(WebApplication app)
        {
            app.MapGet("/profile/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapPost("/profile/", ([FromBody] App.Domain.Model.Person person, [FromServices] App.Data.Model.Context context) =>
            {
                var result = person.Create(context);
                if (result.State == Domain.Core.ResultType.Success)
                {
                    context.SaveChanges();
                }
                return result.State;

            });

            app.MapPut("/profile/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapDelete("/profile/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

        }
    }
}
