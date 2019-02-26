using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScreenSaver
{
    class Ball
    {
        public int x, y, size, xSpeed, ySpeed;

        public Ball(int _x, int _y, int _size, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            size = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(int xSpeed, int ySpeed)
        {
            x += xSpeed;
            y += ySpeed;
        }

        public bool Collision(Ball b)
        {
            Rectangle rec1 = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle rec2 = new Rectangle(x, y, size, size);

            if (rec1.IntersectsWith(rec2))
            {
                return true;
            }
            return false;
        }
    }
}
