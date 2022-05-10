using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CustomButton : Button
    {
        private int x;
        private int y;
        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
        public CustomButton() : base()
        {
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.UserPaint, true);
            Height = 20;
            Width = 20;
            Size = new Size(20, 20);
            Font = new Font("Arial", 10);
            Text = string.Empty;
            Enabled = false;
        }
        //public static List<CustomButton> customButtons = new List<CustomButton>();
        public static CustomButton[,] customButtons = new CustomButton[20,20];


    }
}
