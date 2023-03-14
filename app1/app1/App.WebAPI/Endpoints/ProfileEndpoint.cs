using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{
    public class ProfileEndpoint
    {
        public void Configure(WebApplication app)
        {
            app.MapGet("/profile/get/person/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapPost("/profile/create/person/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapPut("/profile/update/person/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapDelete("/profile/delete/person/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

        }
    }
}
