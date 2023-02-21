using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();
            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
            f.Controls.Add(gs);
            gs.Focus();
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
