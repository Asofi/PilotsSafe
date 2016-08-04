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
        private int[,] current;
        private Image[] levers = new Image[2];

        private int fieldSize;
        Random rnd = new Random();
        private bool started = false;
        private bool won = false;
        private bool swt = false;

        public Form1()
        {
            InitializeComponent();
            levers[1] = Image.FromFile("Resources/Vert.png");
            levers[0] = Image.FromFile("Resources/Hor.png");
        }

        private void CreateButtons()
        {
            fieldSize = (int)numericUpDown1.Value;
            buttons = new Button[fieldSize, fieldSize];
            //Win conditions
            current = new int[fieldSize, fieldSize];
            //Creating field of game
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
                    buttons[i, j].Text = i + " " + j;
                    this.Controls.Add(buttons[i, j]);
                }
        }


        void btn_MouseClick(object sender, MouseEventArgs e)
        {
            int j = this.PointToClient(Cursor.Position).Y / 50;
            int i = this.PointToClient(Cursor.Position).X / 50;
            int countI;
            int countJ;
            if (swt)
            {
                flip(buttons[i, j]);
            }
            else if (!swt)
            {
                for (countI = 0; countI < fieldSize; countI++)
                {
                    flip(buttons[countI, j]);
                }
                for (countJ = 0; countJ < fieldSize; countJ++)
                {
                    if (countJ != j)
                        flip(buttons[i, countJ]);
                }
            }

          /* for (i = 0; i < fieldSize; i++)
            {
                for (j = 0; j < fieldSize; j++)
                {

                    Console.Write("{0,3}", buttons[j, i].Tag);           
                }
                Console.WriteLine();
            }
            Console.WriteLine();*/

            checkWin();

        }

        private void flip (Button btn)
        {   
            int newID = 1 - (int)btn.Tag;
            btn.BackgroundImage = levers[newID];
            btn.Tag = newID;
        }

        private bool checkWin()
        {
            bool check = false;
            int prevI = 0;
            int prevJ = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 1; j < fieldSize; j++)
                {
                    Console.WriteLine("CHe za huina {0} {1} {2}", i, j, check);
                    if ((int)buttons[i, j].Tag != (int)buttons[prevI, prevJ].Tag)
                        return false;
                    prevI = i;
                    prevJ = j;
                }
            }              

                MessageBox.Show("WON!");
                return true;
   
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            swt = !swt;
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                Console.WriteLine("Сторона: " + fieldSize);
                CreateButtons();
                started = true;
                btnStart3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                    this.Controls.Remove(buttons[i, j]);
                }
            started = false;
            btnStart3.Enabled = true;
            //Application.Restart();
        }

       // private bool isCorrect()
        //{
            
       // }
    }
}
