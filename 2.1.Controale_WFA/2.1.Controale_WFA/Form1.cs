using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2._1.Controale_WFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Graphics graphics;
        Bitmap bitmap;

        private void Form1_Load(object sender, EventArgs e)
        {
            // obiectul de tip bitmap reprezint[ imaginea pe care vrem sa o afisam in pictureBox
            // deci acesta va avea dimensiunile pictureBox-ului
            bitmap = new Bitmap(mainDisplay.Width, mainDisplay.Height);

            // obiectul graphics va "desena" lucruri pe acest bitmap
            // deci este creat folosindu-l ca imagine de baza
            graphics = Graphics.FromImage(bitmap);

            // cu functia Clear, dam culoarea primita ca parametru pe intreaga imagine
            graphics.Clear(Color.Crimson);

            Brush brush = new SolidBrush(Color.Black);
            // cu functia DrawString, afisam textul la pozitia si cu fontul specificat
            graphics.DrawString("Hello World!", new Font("Consolas", 20), brush, NewPoint(-100, 10));
            
            // toate modificarile sunt salvate in bitmap. pentru afisare, il folosim ca imagine a pictureBox-ului
            mainDisplay.Image = bitmap;
        }

        // cu aceasta functie, cream punctele in sistemul de coordonate de la matematica, cu originea in centru
        Point NewPoint(int x, int y)
        {
            return new Point(mainDisplay.Width / 2 + x, mainDisplay.Height / 2 - y);
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
