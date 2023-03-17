using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace App.WebAPI.Endpoints
{
    public class ProfileEndpoint
    {
        public void Configure(WebApplication app)
        {
            app.MapGet("/profile/", ([FromBody] App.Domain.Model.Person person, [FromServices] App.Data.Model.Context context) =>
            {
                var ret = person.Get(context);
                return ret.State == Domain.Core.ResultType.Success ? JsonSerializer.Serialize(ret.Entity) : ret.State.ToString();//always force string
                //return ret;
                /*if(ret.State == Domain.Core.ResultType.Success) 
                {
                    return ret.Entity.ToString();
                }
                else { return Domain.Core.ResultType.Failure.ToString(); }*/

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
