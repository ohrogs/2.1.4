using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public class PasswordManager : IPasswordManager
    {
        const KeyDerivationPrf keyDerivationPrf = KeyDerivationPrf.HMACSHA1;
        const int iterationCount = 10000;
        const int nBytesRequested = 256 / 8;

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
            var LocalHashed = Derive(password, Hashed.Salt);

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

        public HashedPassword? Derive(PlainPassword password)
        {
            try
            {
                if (password.IsNull())
                {
                    throw new ArgumentNullException("password cant be null");
                }
                var salt = GenerateSalt();
                return Derive(password, salt);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public HashedPassword? Derive(PlainPassword password, string salt)
        {
            try
            {
                if (password.IsNull())
                {
                    throw new ArgumentNullException("password cant be null");
                }
                if (String.IsNullOrWhiteSpace(salt))
                {
                    throw new ArgumentNullException("salt cant be null");
                }
                return new HashedPassword()
                {
                    Hash = DeriveKey(password.Password, salt),
                    Salt = salt,
                };
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return System.Convert.ToBase64String(salt);
        }
        string DeriveKey(string password, string salt)
        {
            return System.Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: keyDerivationPrf,
                iterationCount: iterationCount,
                numBytesRequested: nBytesRequested
                )
            );
        }
    }
}
