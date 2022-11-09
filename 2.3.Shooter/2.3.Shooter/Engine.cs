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
        public static List<Enemy> enemies = new List<Enemy>(), currentWave = new List<Enemy>();
        public static List<List<Enemy>> waves = new List<List<Enemy>>();
        public static Graphics graphics;
        public static Bitmap bitmap;

        public static int horizon = 200, wave = 1;
        public static double fortHealth = 100, time = 0;

        public static void Init(Form1 f1)
        {
            // formularul deschis in momentul acesta
            form = f1;
            bitmap = new Bitmap(form.Width, form.Height);
            graphics = Graphics.FromImage(bitmap);

            // aceste date sunt hardcodate deocamdata
            var wave1 = new List<Enemy>();
            wave1.Add(new NormalZombie(0));
            wave1.Add(new NormalZombie(20));
            wave1.Add(new NormalZombie(35));
            wave1.Add(new NormalZombie(45));
            wave1.Add(new NormalZombie(55));

            var wave2 = new List<Enemy>();
            wave2.Add(new NormalZombie(0));
            wave2.Add(new NormalZombie(10));
            wave2.Add(new NormalZombie(17));
            wave2.Add(new NormalZombie(22));
            wave2.Add(new NormalZombie(27));
            wave2.Add(new NormalZombie(37));
            wave2.Add(new FatZombie(42));
            wave2.Add(new FatZombie(52));

            waves.Add(wave1);
            waves.Add(wave2);
            currentWave = wave1;
        }

        public static void Tick()
        {
            time++;
            form.TimeLabel.Text = $"{time / 10}s";

            // daca nu mai exista inamici, ori trecem la urmatorul wave, ori ai castigat
            if (currentWave.Count == 0 && enemies.Count == 0)
            {
                if (wave < waves.Count)
                    NextWave();
                else
                    Win();
            }

            // adaugam inamicii in lista de inamici afisati doar cand se ajunge la spawnTime
            if (currentWave.Any() && currentWave[0].spawnTime <= time)
            {
                enemies.Add(currentWave[0]);
                currentWave.RemoveAt(0);
            }

            MoveEnemies();
            CheckIfYouLose();
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
        }

        public static void NextWave()
        {
            wave++;
            currentWave = waves[wave-1];
            time = 0;
            form.WaveLabel.Text = $"Wave {wave}";
        }

        public static void UpdateDisplay()
        {
            // Aici setam imaginea de fundal
            graphics.DrawImage(form.background, 0, 0, form.Width, form.Height);

            // parcurgem toti inamicii pentru a afisa imaginea acestora pentru toti,
            // dar nu inainte de a-i sorta pentru a ne asigura ca se afla in ordinea buna
            enemies.Sort((Enemy e1, Enemy e2) => e1.position.Y - e2.position.Y);
            foreach (Enemy enemy in enemies)
                enemy.Draw();

            form.pictureBox1.Image = bitmap;
        }

        public static bool IsPixelTransparent(Point click, Enemy enemy)
        {
            int x = click.X - enemy.position.X;
            int y = click.Y - enemy.position.Y;

            Bitmap zombie = new Bitmap((int)enemy.sizeX, (int)enemy.sizeY);
            Graphics grp = Graphics.FromImage(zombie);
            grp.DrawImage(enemy.image, 0, 0, (int)enemy.sizeX, (int)enemy.sizeY);

            return zombie.GetPixel(x, y).ToArgb() == 0;
        }

        public static void MoveEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];
                enemy.Move();

                // verificam daca inamicul nu mai este vazut, caz in care primim damage
                if (enemy.position.Y >= form.Height)
                {
                    fortHealth -= enemy.damage;
                    form.HealthLabel.Text = $"Health {fortHealth}";
                    enemies.Remove(enemies[i]);
                    i--;
                }
            }
        }

        public static void Win()
        {
            form.timer1.Enabled = false;
            form.backgroundSound.Stop();
            MessageBox.Show("You defeated all the enemies!", "You Win!");
            form.Close();
        }

        public static void CheckIfYouLose()
        {
            if (fortHealth <= 0)
            {
                form.timer1.Enabled = false;
                form.backgroundSound.Stop();
                MessageBox.Show("You fort walls were destroyed!", "You Lose!");
                form.Close();
            }
        }

        public static Point GetRandomPoint(int sizeX, int sizeY)
        {
            // pozitia y a fiecarui inamic este mereu la linia orizontului
            // iar pozitia x este la intamplare
            return new Point(random.Next(form.Width - sizeX), horizon - sizeY);
        }
    }
}
