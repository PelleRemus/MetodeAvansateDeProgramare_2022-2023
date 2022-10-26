using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2._3.Shooter
{
    public partial class Form1 : Form
    {
        public Image background = Image.FromFile("../../Images/Background.png");
        public Image normalZombie = Image.FromFile("../../Images/NormalZombie.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // nu stim latimea si inaltimea pana nu intram in full screen
            // deci trebuie sa le setam in cod dupa aceea
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            Engine.Init(this);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // daca cheia apasata este Esc, doar atunci inchidem jocul
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        // folosim MouseClick in loc de Click pentru a sti niste informatie
        // despre click in sine, precum locul unde am dat click
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }

        // la fiecare 100ms, miscam fiecare inamic mai in fata si actualizam displayul
        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Tick();
        }
    }
}
