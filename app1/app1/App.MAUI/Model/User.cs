using App.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MAUI.Model
{
    internal class User : IUser
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
