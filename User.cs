namespace WindowsFormsApp1
{
    public class User
    {
        private string login;
        private string password;
        private string symbol;
        private int points;
        private static bool turn;

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Points { get => points; set => points = value; }
        public static bool Turn { get => turn; set => turn = value; }

        public User(string login, string password, int points)
        {
            Login = login;
            Password = password;
            Points = points;
        }
    }
}