using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._4.Platformer
{
    public class Player
    {
        public PictureBox image;
        public int speed = 5, gravity;
        public bool isMovingLeft, isMovingRight, isJumping = true;
        public const int maxGravity = 25;

        public Player()
        {
            image = new PictureBox();
            image.Parent = Engine.form;
            image.Location = new Point(Engine.form.Width / 2, Engine.form.Height * 3 / 4);
            image.Size = new Size(100, 100);
            image.BackColor = Color.Transparent;
            image.Image = Image.FromFile("../../Images/Player.png");
            image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Move()
        {
            if (isMovingLeft)
            {
                image.Left -= speed;
            }
            else if(isMovingRight)
            {
                image.Left += speed;
            }
            gravity = Math.Min(maxGravity, gravity + 1);
            image.Top += gravity;
            Engine.PlayerCollision();
        }
    }
}
