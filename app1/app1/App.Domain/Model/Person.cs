using App.Data.Model;
using App.Domain.Core;
using App.Domain.Interfaces;
using App.Domain.Security;
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
            Surname = person.Surname;
            Birthdate = person.Birthdate;
            Cf = person.Cf;
            Email = person.Email;
            Iduser = person.Iduser;
            user = new User(person.User);

        }

        public IResult<List<Person>> Select()
        {
            using (var context = new Data.Model.Context())
            {
                try
                {
                    /*if (ID == 0)
                    {
                        //return new Result(ResultType.Failure, "ID must be != 0");
                        throw new KeyNotFoundException("Id must not be 0");
                    }*/
                    var ExtentionMethod = context.People.Select(p => new Person());

                    /*var QueryLang = from p in context.People
                                    where p.Id > 6
                                    select p;*/
                    if (ExtentionMethod == null)
                    {
                        return new Result<List<Person>>(ResultType.Failure, "no person found with that id");
                    }

                    return new Result<List<Person>>(ResultType.Success, ExtentionMethod.ToList());

                }
                catch (Exception e)
                {

                    return new Result<List<Person>>(ResultType.Error, e);
                }
            }
        }
        public IResult<Person> Get(Data.Model.Context context)
        {
            
            try
            {
                if (ID == 0)
                {
                    return new Result<Person>(ResultType.Failure, "id cant be 0");
                }
                var person = context.People.SingleOrDefault(p => p.ID == ID);
                person.User = context.Users.SingleOrDefault(u => u.ID == person.Iduser);

                /*var QueryLang = from p in context.People
                                where p.Id > 6
                                select p;*/

                if (person == null)
                {
                    return new Result<Person>(ResultType.Failure, "no person found with that id");
                }

                return new Result<Person>(ResultType.Success, new Person(person));

            }
            catch (Exception e)
            {
                return new Result<Person>(ResultType.Error, e);
            }
            
        }

        private StringBuilder Check()
        {
            var messages = new StringBuilder();

            if (String.IsNullOrWhiteSpace(this.Name))
            {
                messages.AppendLine("Name cant be null");
            }
            if (String.IsNullOrWhiteSpace(this.Surname))
            {
                messages.AppendLine("Surname cant be null");
            }
            if (String.IsNullOrWhiteSpace(this.Email))
            {
                messages.AppendLine("Email cant be null");
            }
            if (user == null)
            {
                messages.AppendLine("User cant be null");
            }
            if (String.IsNullOrWhiteSpace(user.Nickname))
            {
                messages.AppendLine("user Nickname cant be null");
            }
            if (String.IsNullOrWhiteSpace(user.Password))
            {
                messages.AppendLine("user Password cant be null");
            }

            return messages;
        }
        public IResult Create(Data.Model.Context context)
        {
            try
            {

                var messages = Check();
                var pswManager = new PasswordManager();
                if (messages.Length > 0)
                {
                    return new Result(ResultType.Failure, messages.ToString());
                }

                var hash = pswManager.Convert(new PlainPassword() { Password = this.user.Password });

                Data.Model.Person DtoPerson = new()
                {
                    Name = this.Name,
                    Surname = this.Surname,
                    Birthdate = this.Birthdate,
                    Cf = this.Cf,
                    Email = this.Email,
                    User = new Data.Model.User()
                    {
                        Nickname = this.user.Nickname,
                        Salt = hash.Salt,
                        Hash = hash.Hash,
                    }
                };

                context.People.Add(DtoPerson);
                context.SaveChanges();


                return new Result(ResultType.Success);

            }
            catch (Exception e)
            {

                return new Result(ResultType.Error, e);
            }
        }
        public IResult Update()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    var messages = Check();


                    if (messages.Length > 0)
                    {
                        return new Result(ResultType.Failure, messages.ToString());
                    }
                    Data.Model.Person DtoPerson = context.People.Where(p => p.ID == ID).SingleOrDefault();

                    var pswManager = new PasswordManager();
                    if (pswManager.Match(new PlainPassword() { Password = this.user.Password }, new HashedPassword() { Hash = DtoPerson.User.Hash, Salt = DtoPerson.User.Salt }))
                    {
                        messages.AppendLine("Hash or Salt match");
                        return new Result(ResultType.Failure, messages.ToString());
                    }

                    DtoPerson.Name = this.Name;
                    DtoPerson.Birthdate = this.Birthdate;
                    DtoPerson.Cf = this.Cf;
                    DtoPerson.Email = this.Email;
                    DtoPerson.Iduser = this.Iduser;
                    //DtoPerson.User = context.Users.Where(u => u.ID == this.Iduser).SingleOrDefault();

                    context.People.Update(DtoPerson);
                    context.SaveChanges();
                }
                return new Result(ResultType.Success);

            }
            catch (Exception e)
            {

                return new Result(ResultType.Error, e);
            }
        }
        public IResult Delete()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    if (ID == 0)
                    {
                        return new Result(ResultType.Failure, "ID must be != 0");
                    }
                    Data.Model.Person DtoPerson = context.People.Where(p => p.ID == ID).SingleOrDefault();

                    if (DtoPerson == null)
                    {
                        return new Result(ResultType.Undefined, "no user found with that id");
                    }

                    context.People.Remove(DtoPerson);
                    context.SaveChanges();
                    return new Result(ResultType.Success);

                }
            }
            catch (Exception e)
            {

                return new Result(ResultType.Error, e);
            }

        }
    }
}
