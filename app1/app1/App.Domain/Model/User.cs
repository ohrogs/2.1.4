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
    public class User : ICommand<User>, IEntity
    {
        public int ID { get; set; }
        public string Nickname { get; set; }

        public string Password { get; set; }

        internal string Salt { get; set; }

        public User() { }

        public User(Data.Model.User user)
        {
            ID = user.ID;
            Nickname = user.Nickname;
            Salt = user.Salt;
        }

        public IResult<List<User>> Select()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    var ExtentionMethod = String.IsNullOrWhiteSpace(Nickname) ? context.Users.Select(u => new User(u)) : context.Users.Select(u => new User(u)).Where(usr => usr.Nickname == Nickname);//needed for type conversion
                    /*var QueryLang = from p in context.People
                                    where p.Id > 6
                                    select p;*/

                    if (ExtentionMethod == null)
                    {
                        return new Result<List<User>>(ResultType.Failure, "no bitches?");
                    }

                    return new Result<List<User>>(ResultType.Success, ExtentionMethod.ToList());
                }
            }
            catch (Exception e)
            {

                return new Result<List<User>>(ResultType.Error, e);
            }
        }
        public IResult<User> Get()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    var user = context.Users.SingleOrDefault(u => u.ID == ID);

                    /*var QueryLang = from p in context.People
                                    where p.Id > 6
                                    select p;*/

                    return new Result<User>(ResultType.Success, user == null ? null : new User(user));
                }
            }
            catch (Exception e)
            {

                return new Result<User>(ResultType.Error, e);
            }
        }
        public IResult Create()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    var pswManager = new PasswordManager();
                    var hash = pswManager.Derive(new PlainPassword() { Password = this.Password });
                    Data.Model.User DtoUser = new Data.Model.User()
                    {
                        Nickname = this.Nickname,
                        Hash = hash.Hash,
                        Salt = hash.Salt,
                    };
                    context.Users.Add(DtoUser);
                    context.SaveChanges();
                }
                return new Result(ResultType.Success);
            }
            catch (Exception e)
            {

                return new Result(ResultType.Failure, e);
            }
        }
        public IResult Update()
        {
            try
            {
                using (var context = new Data.Model.Context())
                {
                    Data.Model.User DtoUser = context.Users.Where(u => u.ID == ID).SingleOrDefault();

                    DtoUser.Nickname = this.Nickname;
                    DtoUser.Salt = "gang2";
                    DtoUser.Hash = "hash2";

                    context.Users.Update(DtoUser);
                    context.SaveChanges();
                }
                throw new NotImplementedException();

            }
            catch (Exception e)
            {

                return new Result(ResultType.Failure, e);
            }
        }
        public IResult Delete()
        {
            using (var context = new Data.Model.Context())
            {
                Data.Model.User DtoUser = context.Users.Where(u => u.ID == ID).SingleOrDefault();

                context.Users.Remove(DtoUser);
                context.SaveChanges();
            }
            throw new NotImplementedException();
        }

        private StringBuilder Check()
        {
            var messages = new StringBuilder();

            if (String.IsNullOrWhiteSpace(Nickname))
            {
                messages.AppendLine("user Nickname cant be null");
            }
            if (String.IsNullOrWhiteSpace(Password))
            {
                messages.AppendLine("user Password cant be null");
            }

            return messages;
        }
    }
}
