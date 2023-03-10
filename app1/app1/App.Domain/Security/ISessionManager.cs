using App.Domain.Model;
using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public interface ISessionManager
    {
        IResult<User> Login(User user);
        IResult Logout(User user);
    }
}
