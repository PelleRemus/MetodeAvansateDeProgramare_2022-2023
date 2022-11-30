using System.Drawing;

namespace _2._3.Shooter
{
    public abstract class Enemy
    {
        public double health, speed, damage, sizeX, sizeY, positionX;
        public int spawnTime;
        public Point position;
        public Image image;

        public Enemy(double health, double speed, double damage, double sizeX, double sizeY, int spawnTime, Image image)
        {
            this.health = health;
            this.speed = speed;
            this.damage = damage;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.spawnTime = spawnTime;
            this.image = image;
            position = Engine.GetRandomPoint((int)sizeX, (int)sizeY);
            positionX = position.X;
        }

        protected abstract bool IsHeadShot(Point click);

        public virtual void Move()
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

        public void Draw()
        {
            Engine.graphics.DrawImage(image, position.X, position.Y, (int)sizeX, (int)sizeY);
        }

        public void GetShot(Point click)
        {
            // verificam daca clickul a fost facut pe acest inamic
            // trebuie sa verificam in toate pozitiile, stanga, dreapta, sus si jos
            if(click.X > position.X && click.X < position.X + sizeX
                && click.Y > position.Y && click.Y < position.Y + sizeY)
            {
                // daca pixelul din imagine este transparent, inamicul nu a fost impuscat
                if (Engine.IsPixelTransparent(click, this))
                    return;

                int damageValue = 20;
                Color damageColor = Color.White;
                if (IsHeadShot(click))
                {
                    damageValue = 50;
                    damageColor = Color.Red;
                }

                health -= damageValue;
                Engine.damages.Add(new DamageNumber(damageValue, new Point(click.X, click.Y - 20), damageColor));
                Engine.UpdateDisplay();
            }
        }
    }
}
