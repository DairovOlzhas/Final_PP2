using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        public int k = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(80, 80);
                    double x = i / 3.0 * 240;
                    double y = j / 3.0 * 240;
                    btn.Location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    btn.Click += new EventHandler(Buttons_Click);
                    Controls.Add(btn);
                }
            }
        }

        private bool Check()
        {
            List<Button> btns = new List<Button>();
            foreach (Button btn in Controls)
                btns.Add(btn);

            for(int i = 0; i < 3; i++)
                if (btns[i].Text == btns[3 + i].Text && btns[3 + i].Text == btns[6 + i].Text && btns[i].Text != "")
                    return true;

            for (int i = 0; i < 9; i+=3)
                if (btns[i].Text == btns[1 + i].Text && btns[1 + i].Text == btns[2 + i].Text && btns[i].Text != "")
                    return true;

            if (btns[0].Text == btns[4].Text && btns[4].Text == btns[8].Text && btns[0].Text != "")
                return true;


            if (btns[2].Text == btns[4].Text && btns[4].Text == btns[6].Text && btns[2].Text != "")
                return true;

            return false;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("JR");
            Button btn = sender as Button;

            if(btn.Text == "")
            {
                if (k % 2 == 0)
                    btn.Text = "O";
                else
                    btn.Text = "X";

                btn.Font = new Font(FontFamily.GenericSerif, 30);
                k++;
            }

            if (Check())
            {
                if (k % 2 == 0)
                    MessageBox.Show("X Win");
                else
                    MessageBox.Show("O Win");

                foreach (Button b in Controls)
                    b.Text = "";
            }
            bool bo = true;
            foreach (Button bt in Controls)
                if (bt.Text == "")
                    bo = false;
            if (bo)
            {
                MessageBox.Show("Нечья");
                foreach (Button b in Controls)
                    b.Text = "";
            }

        }
    }
}
