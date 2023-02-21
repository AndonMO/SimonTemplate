using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guesses = 0;

        SoundPlayer green = new SoundPlayer(Properties.Resources.green);
        SoundPlayer red = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellow = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blue = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer gameOver = new SoundPlayer(Properties.Resources.mistake);


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GraphicsPath circlePath = new GraphicsPath(); 
            circlePath.AddEllipse(5, 5, 215, 215); 
            Region buttonRegion = new Region(circlePath); 

            
            greenButton.Region = buttonRegion; 
            //rotate the orientation of the screen by 90 degrees 

            Matrix transformMatrix = new Matrix(); 
            transformMatrix.RotateAt(90, new PointF(50, 50)); 

            //apply rotation to button region and apply region to red button     

            buttonRegion.Transform(transformMatrix); 
            redButton.Region = buttonRegion; 

            transformMatrix.RotateAt(90, new PointF(50, 50)); 
            buttonRegion.Transform(transformMatrix); 
            yellowButton.Region = buttonRegion;

     
            transformMatrix.RotateAt(90, new PointF(50, 50)); 
            buttonRegion.Transform(transformMatrix); 
            blueButton.Region = buttonRegion;



           
            
            
            
            //clear the pattern list from form1
            Form1.patterns.Clear();
            //refresh
            this.Refresh();
            //pause for a bit
            Thread.Sleep(500);
            //run ComputerTurn()
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Thread.Sleep(250);
            //get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list. Each number represents a button. For example, 0 may be green, 1 may be blue, etc.
            Random randGen = new Random();
            Form1.patterns.Add(randGen.Next(0, 4));
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.patterns.Count; i++)
            {
                if (Form1.patterns[i] == 0)
                {
                    greenButton.BackColor = Color.Lime;
                    green.Play();
                    this.Refresh();
                    Thread.Sleep(700);
                    greenButton.BackColor = Color.ForestGreen;
                    this.Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.patterns[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    red.Play();
                    this.Refresh();
                    Thread.Sleep(700);
                    redButton.BackColor = Color.DarkRed;
                    this.Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.patterns[i] == 2)
                {
                    yellowButton.BackColor = Color.Gold;
                    yellow.Play();
                    this.Refresh();
                    Thread.Sleep(700);
                    yellowButton.BackColor = Color.Goldenrod;
                    this.Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.patterns[i] == 3)
                {
                    blueButton.BackColor = Color.MediumSlateBlue;
                    blue.Play();
                    this.Refresh();
                    Thread.Sleep(700);
                    blueButton.BackColor = Color.DarkBlue;
                    this.Refresh();
                    Thread.Sleep(500);
                }
            }
            //set guess value back to 0
            guesses = 0;
        }
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value in the pattern list at index [guess] equal to a green?
            if (Form1.patterns[guesses] == 0)
            {
                greenButton.BackColor= Color.Lime;
                green.Play();
                this.Refresh();
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                this.Refresh();
                guesses++;
            }
            else
            {
                GameOver();
            }

            if (guesses == Form1.patterns.Count)
            {
                ComputerTurn();
            }
            
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guesses] == 1)
            {
                redButton.BackColor = Color.Red;
                red.Play();
                this.Refresh();
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                this.Refresh();
                guesses++;
            }
            else
            {
                GameOver();
            }

            if (guesses == Form1.patterns.Count)
            {
                ComputerTurn();
            }
            
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guesses] == 2)
            {
                yellowButton.BackColor = Color.Gold;
                yellow.Play();
                this.Refresh();
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                this.Refresh();
                guesses++;
            }
            else
            {
                GameOver();
            }

            if (guesses == Form1.patterns.Count)
            {
                ComputerTurn();
            }
            
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guesses] == 3)
            {
                blueButton.BackColor = Color.MediumSlateBlue;
                blue.Play();
                this.Refresh();
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                this.Refresh();
                guesses++;
            }
            else
            {
                GameOver();
            }

            if (guesses == Form1.patterns.Count)
            {
                ComputerTurn();
            }
            
        }
        public void GameOver()
        {
            gameOver.Play();
            Thread.Sleep(200);
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen gos = new GameOverScreen();
            gos.Location = new Point((this.Width - gos.Width) / 2, (this.Height - gos.Height) / 2);
            f.Controls.Add(gos);
            gos.Focus();
        }
    }
}
