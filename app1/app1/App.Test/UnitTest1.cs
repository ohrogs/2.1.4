using App.Data.Model;

namespace App.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var a = new User();
            var b = new Person();
            b.User = a;
            Assert.NotNull(b);
        }
    }
}