using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public class PasswordManager : IPasswordManager
    {
        public PasswordManager() { }

        public HashedPassword Convert(PlainPassword password)
        {
            if (password.IsNull())
            {
                throw new ArgumentNullException("password is null");
            }
            var Hashed = Derive(password);
            return Hashed;
        }

        public bool Match(PlainPassword password, HashedPassword Hashed)
        {
            var LocalHashed = Derive(password);

            /*if(Hashed.Hash != LocalHashed.Hash) 
            {
                return false;
            }

            if(Hashed.Salt != Hashed.Salt)
            {
                return false;
            }

            return true;*/

            if (password.IsNull())
            {
                throw new ArgumentNullException("Password cant be null");
            }
            if (Hashed == null)
            {
                throw new ArgumentNullException("Hashed cant be null");
            }

            return Hashed.Hash == LocalHashed.Hash || Hashed.Salt == LocalHashed.Salt;
        }

        public HashedPassword Derive(PlainPassword password)
        {
            if (password.IsNull()) 
            {
                throw new ArgumentNullException("password cant be null");
            }
            return new HashedPassword()
            {
                Hash = password.Password.GetHashCode().ToString(),
                Salt = "",
            };
        }
    }
}
