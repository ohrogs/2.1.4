namespace App.WebAPI.Endpoints
{
    public class ProfileEndpoint
    {
        public void DefineEndpoint(WebApplication app)
        {
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

            app.MapDelete("/profile/delete/person/", () =>
            {
                return "Santo Padre";

            });

        }
    }
}
