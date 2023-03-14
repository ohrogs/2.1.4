using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{

    public class SecurityEndpoint
    {


        public void Configure(WebApplication app)
        {
            app.MapPost("/security/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapGet("/security/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapPut("/security/update/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });
        }
    }
}
