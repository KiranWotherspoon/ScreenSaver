using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        List<Ball> balls = new List<Ball>();

        SolidBrush drawBrush = new SolidBrush(Color.Red);

        Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            StartUp();
        }

        public void StartUp()
        {
            Ball ballOne = new Ball(rng.Next(0, this.Width - 50), rng.Next(0, this.Height - 50), rng.Next(5, 50), rng.Next(-6, 5), rng.Next(-11, 10));
            Ball ballTwo = new Ball(rng.Next(0, this.Width - 50), rng.Next(0, this.Height - 50), rng.Next(5, 50), rng.Next(-6, 5), rng.Next(-11, 10));
            Ball ballThree = new Ball(rng.Next(0, this.Width - 50), rng.Next(0, this.Height - 50), rng.Next(5, 50), rng.Next(-6, 5), rng.Next(-11, 10));

            balls.Add(ballOne);
            balls.Add(ballTwo);
            balls.Add(ballThree);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move each ball
            foreach (Ball b in balls)
            {
                b.Move(b.xSpeed, b.ySpeed);
            }

            foreach (Ball b in balls)
            {
                if (b.x > this.Width - b.size || b.x < 0) { b.xSpeed = -b.xSpeed; }
                if (b.y > this.Height - b.size || b.y < 0) { b.ySpeed = -b.ySpeed; }
            }

            if (balls[0].Collision(balls[1]))
            {
                balls[0].xSpeed = -balls[0].xSpeed;
                balls[1].xSpeed = -balls[1].xSpeed;
                balls[0].ySpeed = -balls[0].ySpeed;
                balls[1].ySpeed = -balls[1].ySpeed;
            }
            if (balls[0].Collision(balls[2]))
            {
                balls[0].xSpeed = -balls[0].xSpeed;
                balls[2].xSpeed = -balls[2].xSpeed;
                balls[0].ySpeed = -balls[0].ySpeed;
                balls[2].ySpeed = -balls[2].ySpeed;
            }
            if (balls[1].Collision(balls[2]))
            { 
                balls[1].xSpeed = -balls[1].xSpeed;
                balls[2].xSpeed = -balls[2].xSpeed;
                balls[1].ySpeed = -balls[1].ySpeed;
                balls[2].ySpeed = -balls[2].ySpeed;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Ball b in balls)
            {
                e.Graphics.FillEllipse(drawBrush, b.x, b.y, b.size, b.size);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
