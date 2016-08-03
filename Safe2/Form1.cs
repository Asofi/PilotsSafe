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
        private Button[,] buttons;
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
            buttons = new Button[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                    buttons[i,j] = new Button();

                    buttons[i, j].Tag = rnd.Next(0, 2);
                    int ID = (int)buttons[i, j].Tag;
                    buttons[i, j].Location = new Point(i * 50, j * 50);
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].BackgroundImage = levers[ID];
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i, j].MouseClick += new MouseEventHandler(btn_MouseClick);
                    this.Controls.Add(buttons[i, j]);
                    /*buttons[i, j].Width = 60;
                    buttons[i, j].Height = 60;
                    buttons[i, j].Name = "Btn " + (i+1) + " " + (j+1);
                    buttons[i, j].Location = new Point(i * buttons[i, j].Width, j * buttons[i,j].Height);
                    buttons[i, j].BackgroundImage = levers[ID];
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i, j].Click += new EventHandler(btn_Click);
                    this.Controls.Add(buttons[i, j]);*/
                    Console.WriteLine("Image " + ID);
                }
        }

        void btn_MouseClick(object sender, MouseEventArgs e)
        {
            int j = this.PointToClient(Cursor.Position).Y / 50;
            int i = this.PointToClient(Cursor.Position).X / 50;
            int countI;
            int countJ;
            for (countI = 0; countI < (int)numericUpDown1.Value; countI++)
            {
                flip(buttons[countI, j]);
                Console.WriteLine("Flipped");
            }
            for (countJ =0; countJ < (int)numericUpDown1.Value; countJ++)
            {
                if(countJ!=j)
                flip(buttons[i, countJ]);
                Console.WriteLine("Flipped");
            }

        }

        private void flip (Button btn)
        {   
            int newID = 1 - (int)btn.Tag;
            btn.BackgroundImage = levers[newID];
            btn.Tag = newID;
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
