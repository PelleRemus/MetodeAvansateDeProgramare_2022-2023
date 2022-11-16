using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace _2._3.Shooter
{
    public partial class Form1 : Form
    {
        public Image background = Image.FromFile("../../Images/Background.png");
        public Image pistol = Image.FromFile("../../Images/Pistol.png");
        public SoundPlayer backgroundSound = new SoundPlayer("../../Sounds/Thriller.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // nu stim latimea si inaltimea pana nu intram in full screen
            // deci trebuie sa le setam in cod dupa aceea
            pictureBox1.Width = MenuScreen.Width = StatusBar.Width = this.Width;
            pictureBox1.Height = this.Height - StatusBar.Height;
            MenuScreen.Height = this.Height;

            // asa ne asiguram ca background-ul label-urilor este in functie de imaginea de fundal
            TimeLabel.Parent = WaveLabel.Parent = HealthBar.Parent = StatusBar;
            Gun.Parent = pictureBox1;
            HealthLabel.Parent = HealthBar;

            // dam valori butoanelor de start si exit pentru a aparea asezate frumos in functie de imagine
            StartButton.Parent = ExitButton.Parent = MenuScreen;
            StartButton.Left = ExitButton.Left = this.Width / 2 - 3 * StartButton.Width / 8;
            StartButton.Top = this.Height - StartButton.Height * 3;
            ExitButton.Top = this.Height - StartButton.Height * 2;

            this.Cursor = Cursors.Cross;
            Engine.Init(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // pornim timer-ul doar dupa ce apasam Play
            timer1.Enabled = true;
            MenuScreen.Enabled = false;
            MenuScreen.Visible = false;

            // pornim sunetul de fundal
            backgroundSound.PlayLooping();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // daca cheia apasata este Esc, doar atunci inchidem jocul
            if (e.KeyCode == Keys.Escape)
            {
                // ne asiguram ca jocul nu continua sa ruleze cat timp pop-up-ul este afisat
                timer1.Enabled = false;
                Engine.BlurBackground();

                // salvam optiunea aleasa intr-o variabila
                var option = MessageBox.Show("Are you sure you want to exit this game? Your progress will not be saved",
                    "Exit Game", MessageBoxButtons.OKCancel);

                // si inchidem jocul doar daca jucatorul a apasat OK
                if (option == DialogResult.OK)
                    Close();
                // pornim jocul la loc in cazul in care nu s-a ales sa se inchida jocul
                timer1.Enabled = true;
            }
        }

        // folosim MouseClick in loc de Click pentru a sti niste informatie
        // despre click in sine, precum locul unde am dat click
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Shoot(e.Location);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Gun.Location = new Point(e.Location.X, e.Location.Y + 20);
        }

        // aceasta metoda se apeleaza la fiecare 100ms
        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Tick();
        }
    }
}
