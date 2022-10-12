using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2._2.X_si_O
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 3;
        Button[,] buttons;
        bool isPlayerX = true;

        private void button1_Click(object sender, EventArgs e)
        {
            // daca butoanele nu au fost create inca, trebuie sa facem initializarea
            if (buttons == null)
            {
                buttons = new Button[n, n];
                // dimensiunea butoanelor va fi o treime din ecran, pt ca matricea este de dimensiunea 3x3
                int size = pictureBox1.Width / 3;

                // parcurgem matricea ca si orice matrice, pentru a initializa toate butoanele
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Button button = new Button();
                        button.Parent = pictureBox1; // fara aceasta proprietate, butonul exista dar nu stie unde sa fie afisat
                        button.Size = new Size(size, size);
                        button.Location = new Point(j * size, i * size); // pozitia butonului este in funtie de linie, coloana si dimensiune
                        button.Font = new Font("Arial", 30);

                        // cand se intampla evenimentul Click la orice buton, vrem sa se apeleze metoda gridButton_Click
                        // nu apelam noi metoda, deci scriem doar numele acesteia fara sa folosim paranteze
                        // la evenimentul Click, se pot intampla mai multe lucruri, deci am putea adauga mai multe metode, si de aceea folosim operatorul +=
                        button.Click += gridButton_Click;
                        buttons[i, j] = button;
                    }
            }
            // altfel, aducem butoanele si variabilele din joc la starea lor initiala
            else
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i, j].Enabled = true;
                        buttons[i, j].Text = "";
                    }

                isPlayerX = true;
            }
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            // "sender" este chiar butonul pe care am dat click
            Button button = sender as Button;

            // dam valoare butonului in functie de jucatorul al carui tura a venit
            if (isPlayerX)
                button.Text = "X";
            else
                button.Text = "O";

            if (CheckGameWon())
            {
                // decidem cum afisam jucatorul in functie de tura
                int player;
                if (isPlayerX)
                    player = 1;
                else
                    player = 2;

                MessageBox.Show($"Player {player} has won", "Game Won");
            }
            else if (CheckGameOver())
                MessageBox.Show("Remiza", "Game Over");

            // la final, trecem la celalalt jucator si nu mai lasam jucatorul sa aleaga acelasi buton
            isPlayerX = !isPlayerX;
            button.Enabled = false;
        }

        bool CheckGameOver()
        {
            // jocul s-a sfarsit daca jucatorul nu mai are nicio optiune de ales
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Enabled)
                        return false;
                }

            return true;
        }

        bool CheckGameWon()
        {
            // pentru a verifica daaca am castigat, numaram cati X sau O sunt pe linii, coloane si diagonale
            // iar la final, verificam daca vreuna din sume a ajuns la 3.
            int sumaX, sumaO;
            for (int i = 0; i < n; i++)
            {
                // verificare pe linii
                sumaX = 0; sumaO = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Text == "X")
                        sumaX++;
                    else if (buttons[i, j].Text == "O")
                        sumaO++;
                }
                if (sumaX == 3 || sumaO == 3)
                    return true;

                // verificare pe coloane
                sumaX = 0; sumaO = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[j, i].Text == "X")
                        sumaX++;
                    else if (buttons[j, i].Text == "O")
                        sumaO++;
                }
                if (sumaX == 3 || sumaO == 3)
                    return true;
            }

            // diagonala principala
            sumaX = 0; sumaO = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, i].Text == "X")
                    sumaX++;
                else if (buttons[i, i].Text == "O")
                    sumaO++;
            }
            if (sumaX == 3 || sumaO == 3)
                return true;

            // diagonala secundara
            sumaX = 0; sumaO = 0;
            for (int i = 0; i < n; i++)
            {
                if (buttons[i, n - i - 1].Text == "X")
                    sumaX++;
                else if (buttons[i, n - i - 1].Text == "O")
                    sumaO++;
            }
            if (sumaX == 3 || sumaO == 3)
                return true;

            // daca nici una din sume nu este 3, inseamna ca nimeni nu a castigat inca
            return false;
        }
    }
}
