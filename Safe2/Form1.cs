using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safe2
{
    public partial class Form1 : Form
    {
        private Image[] levers = new Image[2];
        Random rnd = new Random();
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateButtons(int fieldSize)
        {
            //Creating field of game
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                    Button btn = new Button();

                    int ID = rnd.Next(0, 2);
                    btn.Width = 40;
                    btn.Height = 40;
                    btn.Name = "Btn" + i.ToString() + j.ToString();
                    btn.Location = new Point(i * btn.Width, j * btn.Height);
                    btn.BackgroundImage = levers[ID];
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    this.Controls.Add(btn);
                    Console.WriteLine("Image " + ID);
                }
        }

        private void flip (Button btn, int ID)
        {
            btn.BackgroundImage = levers[1 - ID];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            levers[0] = Image.FromFile("Resources/Vert.png");
            levers[1] = Image.FromFile("Resources/Hor.png");

        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                Console.WriteLine("Сторона: " + (int)numericUpDown1.Value);
                CreateButtons((int)numericUpDown1.Value);
                started = true;
                btnStart3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void flipper(int fieldSize)
        {
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                  //  flip();
                }
        }
    }
}
