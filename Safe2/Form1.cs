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

                    btn.Width = 40;
                    btn.Height = 40;
                    btn.Name = "Btn" + i.ToString() + j.ToString();
                    btn.Location = new Point(i * btn.Width, j * btn.Height);
                    this.Controls.Add(btn);
                    //Console.WriteLine("Button added" + btn.Name);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("4x4");
            CreateButtons(4);
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("5x5");
            CreateButtons(5);
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Сторона: " + (int)numericUpDown1.Value);
            CreateButtons((int)numericUpDown1.Value);
        }
    }
}
