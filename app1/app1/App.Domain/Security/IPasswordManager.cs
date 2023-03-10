using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public interface IPasswordManager//<H> where H : HashedPassword
    {

        HashedPassword Convert(PlainPassword password);
        bool Match(PlainPassword password, HashedPassword Hashed);
    }
}
