using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _2._3.Shooter
{
    public static class Engine
    {
        public static Form1 form;
        public static Random random = new Random();
        public static List<Enemy> enemies = new List<Enemy>(), wave = new List<Enemy>();
        public static Graphics graphics;
        public static Bitmap bitmap;

        public static int horizon = 200;
        public static double fortHealth = 100, time = 0;

        public static void Init(Form1 f1)
        {
            // formularul deschis in momentul acesta
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            // aceste date sunt hardcodate deocamdata
            wave.Add(new Enemy(100, 5, 20, 50, 100, 0));
            wave.Add(new Enemy(100, 5, 20, 50, 100, 20));
            wave.Add(new Enemy(100, 5, 20, 50, 100, 35));
            wave.Add(new Enemy(100, 5, 20, 50, 100, 45));
            wave.Add(new Enemy(100, 5, 20, 50, 100, 55));
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = $"{time / 10}s";

            // adaugam inamicii in lista de inamici afisati doar cand se ajunge la spawnTime
            if (wave.Any() && wave[0].spawnTime <= time)
            {
                enemies.Add(wave[0]);
                wave.RemoveAt(0);
            }

            // miscam fiecare inamic mai in fata
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Move();

                // verificam daca inamicul nu mai este vazut, caz in care primim damage
                if(enemy.position.Y >= form.Height)
                {
                    fortHealth -= enemy.damage;
                    form.HealthLabel.Text = $"Health {fortHealth}";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }

            // verificam daca pierdem
            if(fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You fort walls were destroyed!", "You Lose!");
                form.Close();
            }
            UpdateDisplay();
        }

        public static void Shoot(Point click)
        {
            // parcurgem toti inamicii pentru a verifica daca toti dintre ei sunt impuscati
            // astfel, avem efectul unui piercing shot (in viitor, vom avea arme cu sau fara)
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetShot(click);
                // daca inamicul nu mai are viata, il scoatem din lista de inamici
                if (enemies[i].health <= 0)
                {
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }

            // daca nu mai exista inamici, inseamna ca ai castigat
            if(wave.Count == 0 && enemies.Count == 0)
            {
                form.timer1.Enabled = false;
                MessageBox.Show("You defeated all the enemies!", "You Win!");
                form.Close();
            }    
        }

        public static void UpdateDisplay()
        {
            // Aici setam imaginea de fundal
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);

            // parcurgem toti inamicii pentru a afisa imaginea acestora pentru toti.
            foreach (Enemy enemy in enemies)
            {
                graphics.DrawImage(form.normalZombie, enemy.position.X, enemy.position.Y,
                    (int)enemy.sizeX, (int)enemy.sizeY);
            }

            form.pictureBox1.Image = bitmap;
        }

        public static Point GetRandomPoint(int sizeX, int sizeY)
        {
            // pozitia y a fiecarui inamic este mereu la linia orizontului
            // iar pozitia x este la intamplare
            return new Point(random.Next(form.Width - sizeX), horizon - sizeY);
        }
    }
}
