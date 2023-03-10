using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public struct PlainPassword
    {
        public string Password { get; set; }

        public bool IsNull()
        {
            return String.IsNullOrWhiteSpace(Password);
        }
    }
}
