using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{

    public class SecurityEndpoint
    {


        public void Configure(WebApplication app)
        {
            app.MapPost("/security/login/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapGet("/security/logout/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });

            app.MapPut("/security/update/user/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });
        }
    }
}
