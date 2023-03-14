using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{

    public class SecurityEndpoint
    {


        public void Configure(WebApplication app)
        {
            app.MapPost("/security/login/", () =>
            {
                return "Santo Padre";

            });

            app.MapGet("/security/logout/", () =>
            {
                return "Santo Padre";

            });

            app.MapPut("/security/update/user/", () =>
            {
                return "Santo Padre";

            });
        }
    }
}
