using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {
        int score = 0;
        int oute = 0;
        Graphics g;
        bool bole = true;
        Selected s = new Selected();
        int k = 0;

        List<Circle> circles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            label2.Text = "Score: " + score;
            label1.Text = "Out: " + oute;
            timer2.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            timer1.Start();
            bole = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k % 10 == 0)
            {
                int x = new Random().Next(10, Width - 10);
                circles.Add(new Circle(x, 0, false));
            }

            foreach (Circle c in circles)
                c.location = new Point(c.location.x, c.location.y + 5);
            k++;

            for(int i = oute; i < circles.Count; i++)
            {
                if(circles[i].location.y > Height)
                {
                    oute++;
                    label1.Text = "Out: " + oute;
                }

            }

           

            Refresh();
        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            foreach(Circle c in circles)
            {
                Size size = new Size(20, 20);
                int x = c.location.x - size.Width;
                int y = c.location.y - size.Height;

                g.FillEllipse(new SolidBrush(Color.FromName(c.color)), x, y, size.Width, size.Height);
                if(c.selected)
                g.DrawEllipse(new Pen(Color.Black, 3), x, y, size.Width + 3, size.Height + 3);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < circles.Count; i++)
            {
                Circle c = circles[i];
                if (Math.Sqrt(Math.Pow(Math.Abs(c.location.x - e.X), 2) + Math.Pow(Math.Abs(c.location.y - e.Y), 2)) <= 20)
                {
                    if(s.color == "White")
                    {
                        circles[i].selected = true;
                        s = new Selected(c.location, c.color, i);
                    }
                    else if(c.color == s.color)
                    {
                        circles.Remove(circles[i]);
                        circles.Remove(circles[s.index]);
                        s = new Selected();
                        score++;
                        label2.Text = "Score: " + score;
                    }
                    else
                    {
                        s.color = "White";
                        circles[s.index].selected = false;
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (oute == 20 && bole)
            {
                MessageBox.Show("GameOver");
                circles.Clear();
                timer1.Stop();
                score = 0;
                oute = 0;
                label2.Text = "Score: " + score;
                label1.Text = "Out: " + oute;
                k = 0;
                button1.Visible = true;
                s = new Selected();
                bole = false;
            }

            Refresh();
        }
    }
}
