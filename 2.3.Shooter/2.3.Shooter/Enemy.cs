using System.Drawing;

namespace _2._3.Shooter
{
    public class Enemy
    {
        public double health, speed, damage, sizeX, sizeY, positionX;
        public int spawnTime;
        public Point position;

        public Enemy(double health, double speed, double damage, double sizeX, double sizeY, int spawnTime)
        {
            this.health = health;
            this.speed = speed;
            this.damage = damage;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.spawnTime = spawnTime;
            position = Engine.GetRandomPoint((int)sizeX, (int)sizeY);
            positionX = position.X;
        }

        public void Move()
        {
            // inamicul se apropie de noi cu speed pixeli.
            position.Y += (int)speed;

            // dimensiunile cresc doar cu o parte din viteza pentru a nu fi prea mare spre final
            sizeX += speed / 16;
            sizeY += speed / 8;

            // iar pozitia scade cu jumatate din cat a crescut dimensiunea pentru a pastra inamicul centrat
            positionX -= speed / 32;
            position.X = (int)positionX;
        }

        public void GetShot(Point click)
        {
            // verificam daca clickul a fost facut pe acest inamic
            // trebuie sa verificam in toate pozitiile, stanga, dreapta, sus si jos
            if(click.X > position.X && click.X < position.X + sizeX
                && click.Y > position.Y && click.Y < position.Y + sizeY)
            {
                // viata scade cu 20
                health -= 20;

                // si afisam scrisul cu damage-ul primit chiar deasupra clickului dat
                Engine.graphics.DrawString("20", new Font("Arial", 12, FontStyle.Bold),
                    new SolidBrush(Color.White), click.X, click.Y - 20);
                Engine.form.pictureBox1.Image = Engine.bitmap;
            }
        }
    }
}
