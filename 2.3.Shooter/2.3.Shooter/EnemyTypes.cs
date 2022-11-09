using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.Shooter
{
    public class NormalEnemy : Enemy
    {
        public static Image normalZombie = Image.FromFile("../../Images/NormalZombie.png");

        public NormalEnemy(int spawnTime): base(100, 5, 20, 50, 100, spawnTime)
        {
            image = normalZombie;
        }

        public override void Move()
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

        public override void Draw()
        {
            Engine.graphics.DrawImage(image, position.X, position.Y, (int)sizeX, (int)sizeY);
        }
    }
}
