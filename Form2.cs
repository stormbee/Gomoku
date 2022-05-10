using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public User user = new User("1", "123", 0);

        public User user2 = new User("2", "234", 0);

        //public Form2(string login,string password,int points)
        public Form2()
        {
            InitializeComponent();
            //User user = new User(login, password, points);
            nickNameLabel.Text = user.Login;
            nickNameLabel2.Text = user2.Login;
            pointsLabel.Text = "Points: " + user.Points.ToString();
            pointsLabel2.Text = "Points: " + user2.Points.ToString();
            LoadDesk();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CheckPlayerStep(CustomButton button)
        {
            if(CheckRow(button) || CheckColumn(button) || CheckMainDiagonal(button) || CheckSideDiagonal(button))
            {
                (User winner, User loser) = user.Symbol == button.Text ? (user, user2) : (user2, user);
                turnLabel.Text = $"{winner.Login} win";
                (user.Points, user2.Points) = button.Text == user.Symbol ? (user.Points += 10, user2.Points -= 10) : (user.Points -= 10, user2.Points += 10);
                foreach(var item in CustomButton.customButtons)
                {
                    item.Click -= CustomButton_Click;
                }
                pointsLabel.Text = "Points: " + user.Points.ToString();
                pointsLabel2.Text = "Points: " + user2.Points.ToString();
                StartGameButton.Enabled = true;

                UpdateDataFile(winner);
                UpdateDataFile(loser);
            }
        }
        // TODO: изменить перезапись данных в файле. Перезаписывать файл то закрытию программы
        
        private static void UpdateDataFile(User player)
        {
            string temp = string.Empty;
            if(Form1.logins.Contains(player.Login))
            {
                for(int i = 0; i < Form1.logins.Length; i += 3)
                {
                    if(Form1.logins[i] == player.Login)
                    {
                        Form1.logins[i + 2] = player.Points.ToString();
                    }
                }
                for(int i = 1; i <= Form1.logins.Length; i++)
                {
                    temp += Form1.logins[i - 1] + " ";
                    if(i % 3 == 0)
                    {
                        temp += "\n";
                    }
                }
                using(StreamWriter file = new StreamWriter("login.txt"))
                {
                    file.Write(temp.Trim());
                }
            }
            else
            {
                using(StreamWriter file = new StreamWriter("login.txt", true))
                {
                    file.WriteLine($"{player.Login} {player.Password} {player.Points}");
                }
            }
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            CustomButton button = sender as CustomButton;
            turnLabel.Text = $"{(turnLabel.Text == $"{user.Login}'s turn" ? user2.Login : user.Login)}'s turn";
            button.Click -= CustomButton_Click;
            button.Font = new Font("Arial", 8, FontStyle.Bold);
            (button.Text, button.ForeColor) = User.Turn ? ("X", Color.Red) : ("O", Color.Blue);
            User.Turn = !User.Turn;                         //переход хода
            CheckPlayerStep(button);
        }

        private void LoadDesk()
        {
            int top;
            int left;
            for(int i = 0; i < 20; i++)
            {
                top = i * 20 + 80;
                for(int j = 0; j < 20; j++)
                {
                    left = j * 20 + 50;

                    CustomButton button = new CustomButton
                    {
                        Left = left,
                        Top = top,
                        X = i,
                        Y = j
                    };
                    this.Controls.Add(button);
                    CustomButton.customButtons[i, j] = button;
                }
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Random random = new Random(); // сделать рандом по игрокам
            (user.Symbol, user2.Symbol) = random.Next(0, 2) == 0 ? ("X", "O") : ("O", "X");
            turnLabel.Text = $"{(user.Symbol == "X" ? user.Login : user2.Login)}'s turn";
            User.Turn = true;
            foreach(var item in CustomButton.customButtons)
            {
                item.Text = ""; // для проверки
                item.Enabled = true;
                item.Click += CustomButton_Click;
                item.FlatStyle = FlatStyle.Standard;
            }
            StartGameButton.Enabled = false;
        }

        private static bool CheckRow(CustomButton button)
        {
            var a = CustomButton.customButtons;
            int length = CustomButton.customButtons.GetLength(0);

            List<CustomButton> listOfRowsButtons = new List<CustomButton>();
            for(int i = 0; i < length; i++)
                listOfRowsButtons.Add(a[button.X, i]);
            bool check = FindFiveSymbols(button, listOfRowsButtons);
            return check;
        }

        private static bool CheckColumn(CustomButton button)
        {
            var a = CustomButton.customButtons;
            int length = CustomButton.customButtons.GetLength(0);

            List<CustomButton> listOfColumnButtons = new List<CustomButton>();
            for(int i = 0; i < length; i++)
                listOfColumnButtons.Add(a[i, button.Y]);
            bool check = FindFiveSymbols(button, listOfColumnButtons);
            return check;
        }

        private static bool CheckMainDiagonal(CustomButton button)
        {
            var a = CustomButton.customButtons;
            int length = CustomButton.customButtons.GetLength(0);
            List<CustomButton> listOfMainDiagonalButtons = new List<CustomButton>();

            if(button.X > button.Y)
            {
                for(int i = button.X - button.Y, j = 0; i < length; i++, j++)
                    listOfMainDiagonalButtons.Add(a[i, j]);
            }
            else
            {
                for(int i = 0, j = button.Y - button.X; j < length; i++, j++)
                    listOfMainDiagonalButtons.Add(a[i, j]);
            }
            bool check = FindFiveSymbols(button, listOfMainDiagonalButtons);
            return check;
        }

        private static bool CheckSideDiagonal(CustomButton button)
        {
            var a = CustomButton.customButtons;
            int length = CustomButton.customButtons.GetLength(0);
            List<CustomButton> listOfSideDiagonalButtons = new List<CustomButton>();

            if(button.X + button.Y < length)
            {
                for(int i = button.X + button.Y, j = 0; i > 0; i--, j++)
                    listOfSideDiagonalButtons.Add(a[i, j]);
            }
            else
            {
                for(int i = length - 1, j = button.Y + button.X - length + 1; j < length; i--, j++)
                    listOfSideDiagonalButtons.Add(a[i, j]);
            }
            bool check = FindFiveSymbols(button, listOfSideDiagonalButtons);
            return check;
        }

        private static bool FindFiveSymbols(CustomButton button, List<CustomButton> listOfRowsButtons)
        {
            int count = 0;
            bool check = false;
            for(int i = 0; i < listOfRowsButtons.Count; i++)
            {
                if(listOfRowsButtons[i].Text == button.Text)
                {
                    count++;
                    if(count == 5)
                    {
                        for(int j = i; j > i - count; j--)
                        {
                            listOfRowsButtons[j].Font = new Font("Arial", 8, FontStyle.Bold);
                            listOfRowsButtons[j].ForeColor = Color.IndianRed;
                            listOfRowsButtons[j].FlatStyle = FlatStyle.Popup;
                        }
                        return true;
                    }
                }
                else
                    count = 0;
            }
            return check;
        }

        private static string ReadLoginFileToEnd(out string result)
        {
            using(StreamReader reader = File.OpenText("login.txt"))
                result = reader.ReadToEnd();
            return result;
        }
    }
}