using App.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MAUI.Model
{
    internal class Person : IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Cf { get; set; }
        public string Email { get; set; }
        public int Iduser { get; set; }

        public IUser user { get; set; }
    }
}
