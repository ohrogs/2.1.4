using Microsoft.AspNetCore.Mvc;

namespace App.WebAPI.Endpoints
{

    public class SecurityEndpoint
    {


        public void Configure(WebApplication app)
        {
            app.MapPost("/security/", ([FromQuery] int IdUser, [FromServices] App.Data.Model.Context context) =>
            {
                Domain.Security.SessionManager session = new Domain.Security.SessionManager();
                var user = context.Users.SingleOrDefault(u => u.ID == IdUser);
                var res = session.Login(new Domain.Model.User(user), context);
                return res;

            });

            app.MapGet("/security/", ([FromQuery] int IdUser,[FromServices] App.Data.Model.Context context) =>
            {
                Domain.Security.SessionManager session = new Domain.Security.SessionManager();
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
