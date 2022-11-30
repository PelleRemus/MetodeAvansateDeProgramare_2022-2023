using System.Drawing;

namespace _2._3.Shooter
{
    public class DamageNumber
    {
        public int value, timeLeft;
        public Point position;
        public Color color;

        public DamageNumber(int value, Point position, Color color)
        {
            timeLeft = 5;
            this.value = value;
            this.position = position;
            this.color = color;
        }

        public void Draw()
        {
            Engine.graphics.DrawString(value.ToString(), new Font("Arial", 12, FontStyle.Bold),
                           new SolidBrush(color), position.X, position.Y);
        }
    }
}
