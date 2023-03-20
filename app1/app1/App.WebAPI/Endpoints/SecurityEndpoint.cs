using App.Domain;
using App.Domain.Security;
using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{

    public class SecurityEndpoint
    {


        public void Configure(WebApplication app)
        {
            app.MapPost("/security/", ([FromBody] Domain.Model.User user, [FromServices] App.Data.Model.Context context) =>
            {
                SessionManager session = new Domain.Security.SessionManager();
                var res = session.Login(user, context);
                return res;

            });

            app.MapGet("/security/", ([FromQuery] int IdUser,[FromServices] App.Data.Model.Context context) =>
            {
                SessionManager session = new Domain.Security.SessionManager();
                var user = context.Users.SingleOrDefault(u => u.ID == IdUser);
                var res = session.Logout(new Domain.Model.User(user));
                return res;

            });

            app.MapPut("/security/update/", ([FromServices] App.Data.Model.Context context) =>
            {
                return "Santo Padre";

            });
        }
    }
}
