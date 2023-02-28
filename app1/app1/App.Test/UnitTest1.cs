using App.Data.Model;
//lorenzomari
namespace App.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateContext()
        {
            var ctx = new Context();
            User user = new User()
            {
                Nickname = "Test",
                //ID = 1,
                Salt = "Test",
                Hash = "Test",
            };
            Person person = new Person()
            {
                User = user,
                Name = "Test",
                Surname = "Test",
                Iduser = user.ID,
                Email = "Test",
                //ID = 1,
            };
            ctx.Users.Add(user);
            ctx.People.Add(person);
            ctx.SaveChanges();
            var plist = ctx.People.ToList();
            //c.People.Add(b);
            Assert.NotNull(plist);
        }
    }
}
//lorenzomari