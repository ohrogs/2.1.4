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

        public Person(Data.Model.Person person)
        {
            Name = person.Name;
            Birthdate = person.Birthdate;
            Cf = person.Cf;
            Email = person.Email;
            Iduser = person.Iduser;
            user = new User(person.User);

        }

        public List<Person> Select()
        {
            using (var context = new Data.Model.Context())
            {
                var ExtentionMethod = context.People.Select(p => new Person());

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                return ExtentionMethod.ToList();
            }
        }
        public Person Get()
        {
            using (var context = new Data.Model.Context())
            {
                var person = context.People.SingleOrDefault(p => p.ID == ID);

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                return new Person(person);
            }
        }
        public IResult Create()
        {
            using (var context = new Data.Model.Context())
            {

                Data.Model.Person DtoPerson = new Data.Model.Person()
                {
                    Name = this.Name,
                    Birthdate = this.Birthdate,
                    Cf = this.Cf,
                    Email = this.Email,
                };

                DtoPerson.User = new Data.Model.User()
                {
                    Nickname = this.user.Nickname,
                    Salt = "gang3",
                    Hash = "hash3",
                };

                context.People.Add(DtoPerson);

                context.SaveChanges();
            }

            throw new NotImplementedException();
        }
        public IResult Update()
        {
            using (var context = new Data.Model.Context())
            {
                Data.Model.Person DtoPerson = context.People.Where(p => p.ID == ID).SingleOrDefault();
                DtoPerson.Name = this.Name;
                DtoPerson.Birthdate = this.Birthdate;
                DtoPerson.Cf = this.Cf;
                DtoPerson.Email = this.Email;
                DtoPerson.Iduser = this.Iduser;
                //DtoPerson.User = context.Users.Where(u => u.ID == this.Iduser).SingleOrDefault();

                context.People.Update(DtoPerson);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }
        public IResult Delete()
        {
            using (var context = new Data.Model.Context())
            {
                Data.Model.Person DtoPerson = context.People.Where(p => p.ID == ID).SingleOrDefault();

                context.People.Remove(DtoPerson);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }
    }
}
