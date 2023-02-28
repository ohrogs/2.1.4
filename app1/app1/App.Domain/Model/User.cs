using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Model
{
    public class User : ICommand<User>, IEntity
    {
        public int ID { get; set; }
        public string Nickname { get; set; }

        public List<User> Select() {
            throw new NotImplementedException();
        }
        public User Get() {
            throw new NotImplementedException();
        }
        public IResult Create() {
            throw new NotImplementedException();
        }
        public IResult Update() {
            throw new NotImplementedException();
        }
        public IResult Delete() {
            throw new NotImplementedException();
        }
    }
}
