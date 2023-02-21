using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public static List<int> patterns = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            MenuScreen ms = new MenuScreen();

            //center screen
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);

            this.Controls.Add(ms);
            ms.Focus();
        }
    }
}
