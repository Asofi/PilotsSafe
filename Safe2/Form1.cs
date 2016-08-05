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

        private int fieldSize;
        Random rnd = new Random();
        private bool swt = false;

        int countI;
        int countJ;
        int[,] ID;

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
            ID = new int[fieldSize, fieldSize];
            int columnCount = 0;
            bool isEven = false;

            //Creating field of game
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(i * 50, j * 50);
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i, j].MouseClick += new MouseEventHandler(btn_MouseClick);
                    this.Controls.Add(buttons[i, j]);
                }
            if (fieldSize % 2 != 0)
            {
                for (int i = 0; i < fieldSize - 1; i++)
                    for (int j = 0; j < fieldSize - 1; j++)
                    {
                        buttons[i, j].Tag = rnd.Next(0, 2);
                        ID[i, j] = (int)buttons[i, j].Tag;
                        buttons[i, j].BackgroundImage = levers[ID[i, j]];

                        if (i == 0 && ID[i, j] == 1)
                            columnCount += 1;

                        if (columnCount % 2 == 0)
                            isEven = true;
                        else
                            isEven = false;
                    }

                    //Создается последняя строка на основании четности каждого столба
                    for (int i = 0; i < fieldSize; i++)
                    {
                        columnCount = 0;
                        for (int j = 0; j < fieldSize - 1; j++)
                        {
                            if (ID[i, j] == 1)
                                columnCount += 1;
                        }
                        if (columnCount % 2 == 0)
                        {
                            if (isEven)
                                ID[i, fieldSize - 1] = 0;
                            else
                                ID[i, fieldSize - 1] = 1;
                            buttons[i, fieldSize - 1].Tag = ID[i, fieldSize - 1];
                            buttons[i, fieldSize - 1].BackgroundImage = levers[ID[i, fieldSize - 1]];
                        }
                        else
                        {
                            if (isEven)
                                ID[i, fieldSize - 1] = 1;
                            else
                                ID[i, fieldSize - 1] = 0;
                            buttons[i, fieldSize - 1].Tag = ID[i, fieldSize - 1];
                            buttons[i, fieldSize - 1].BackgroundImage = levers[ID[i, fieldSize - 1]];
                        }
                    }

                    ////Создается последний столбец на основании четности каждой строки
                    for (int j = 0; j < fieldSize; j++)
                    {
                        columnCount = 0;
                        for (int i = 0; i < fieldSize - 1; i++)
                        {
                            if (ID[i, j] == 1)
                                columnCount += 1;
                        }
                        if (columnCount % 2 == 0)
                        {
                            if (isEven)
                                ID[fieldSize - 1, j] = 0;
                            else
                                ID[fieldSize - 1, j] = 1;
                            buttons[fieldSize - 1, j].Tag = ID[fieldSize - 1, j];
                            buttons[fieldSize - 1, j].BackgroundImage = levers[ID[fieldSize - 1, j]];
                        }
                        else
                        {
                            if (isEven)
                                ID[fieldSize - 1, j] = 1;
                            else
                                ID[fieldSize - 1, j] = 0;
                            buttons[fieldSize - 1, j].Tag = ID[fieldSize - 1, j];
                            buttons[fieldSize - 1, j].BackgroundImage = levers[ID[fieldSize - 1, j]];
                        }
                    }

                }
            else
            {
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                    {
                        buttons[i, j].Tag = rnd.Next(0, 2);
                        ID[i, j] = (int)buttons[i, j].Tag;
                        buttons[i, j].BackgroundImage = levers[ID[i, j]];
                    }
            }
                

        }


        void btn_MouseClick(object sender, MouseEventArgs e)
        {
            int j = this.PointToClient(Cursor.Position).Y / 50;
            int i = this.PointToClient(Cursor.Position).X / 50;

                for (countI = 0; countI < fieldSize; countI++)
                {
                    flip(buttons[countI, j]);
                }
                for (countJ = 0; countJ < fieldSize; countJ++)
                {
                    if (countJ != j)
                        flip(buttons[i, countJ]);
                }
            
            for (i = 0; i < fieldSize; i++)
            {
                for (j = 0; j < fieldSize; j++)
                {
                    Console.Write("{0} ", buttons[j, i].Tag);
                }
                Console.WriteLine();
            }
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
            int prevI = 0;
            int prevJ = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 1; j < fieldSize; j++)
                {
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


        private void btnStart3_Click(object sender, EventArgs e)
        {
            restart();
            
        }


        private void restart()
        {
            if (buttons != null)
            {
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                    {
                        this.Controls.Remove(buttons[i, j]);
                        buttons[i, j].Dispose();
                    }
                CreateButtons();
            }
            else
                CreateButtons();  
        }

        private bool isCorrect()
        {
            int[] lineCount = new int[fieldSize];
            int[] columnCount = new int[fieldSize];
            for (int i = 0; i < fieldSize; i++)
                for (int j = 0; j < fieldSize; j++)
                {
                    if ((int)buttons[i, j].Tag == 1)
                    {
                        columnCount[i] += 1;
                        lineCount[j] += 1;
                    }
                }

            for (int i = 1; i < fieldSize; i++)
                {
                    if ((columnCount[i] % 2 != columnCount[i - 1] % 2) || (lineCount[i] % 2 != columnCount[i - 1] % 2))
                    {
                        Console.WriteLine("Нерешаемо");
                        return false;
                    }
                }
            Console.WriteLine("Решаемо");
            return true;
        }
    }
}
