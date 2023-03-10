using App.Domain.Core;
using App.Domain.Model;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public class SessionManager : ISessionManager
    {
        public IResult<User> Login(User user)
        {
            try
            {
                var gotUser = user.Select();
                if (gotUser.Entity.Count() > 1)
                {
                    return new Result<User>(ResultType.Failure, "multiple users found");
                }
                if (gotUser.Entity.Count() < 1)
                {
                    return new Result<User>(ResultType.Failure, "No users found");
                }
                User u = gotUser.Entity.FirstOrDefault();

                if (u == null) { }

                var pswManager = new PasswordManager();
                PlainPassword uPsw = new PlainPassword { Password = u.Password };
                HashedPassword? hashedPassword = pswManager.Derive(uPsw, u.Salt);

                if (!pswManager.Match(new PlainPassword { Password = user.Password }, hashedPassword))
                {
                    return new Result<User>(ResultType.Failure, "Password does not match");
                }




                return new Result<User>(ResultType.Success, "sium");
            }
            catch (Exception e)
            {

                return new Result<User>(ResultType.Failure, e);
            }
        }

        public IResult Logout(User user)
        {
            throw new NotImplementedException();
        }
    }
}
