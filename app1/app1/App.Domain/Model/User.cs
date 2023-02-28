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

        public User() { }

        public User(Data.Model.User user) 
        {
            ID = user.ID;
            Nickname = user.Nickname;
        }

        public List<User> Select() {
            using (var context = new Data.Model.Context())
            {
                var ExtentionMethod = context.Users.Select(u => new User(u));

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                return ExtentionMethod.ToList();
            }
        }
        public User Get() {
            using (var context = new Data.Model.Context())
            {
                var user = context.Users.SingleOrDefault(u => u.ID == ID);

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                return new User(user);
            }
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
