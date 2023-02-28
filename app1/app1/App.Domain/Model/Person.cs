using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Model
{
    public class Person : ICommand<Person>, IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Cf { get; set; }
        public string Email { get; set; }
        public int Iduser { get; set; }

        public User user { get; set; }

        public Person() { }

        public Person(Data.Model.Person person) {
            Name = person.Name;
            Birthdate = person.Birthdate;
            Cf = person.Cf;
            Email = person.Email;
            Iduser = person.Iduser;
            user = new User(person.User);

        }

        public List<Person> Select() {
            using(var context = new Data.Model.Context())
            {
                var ExtentionMethod = context.People.Select(p => new Person());

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                return ExtentionMethod.ToList();
            }
        }
        public Person Get(){
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
