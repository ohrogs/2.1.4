using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Security
{
    public class HashedPassword
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
