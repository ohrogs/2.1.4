namespace App.Context
{
    public interface IUser
    {
        public int ID { get; set; }
        public string Nickname { get; set; }

        public string Password { get; set; }
    }
}