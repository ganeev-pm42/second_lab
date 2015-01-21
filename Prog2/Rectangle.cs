using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Prog2
{
    class Rectangle : GraphObject
    {
        int w, h;

        public Rectangle()
        {
            w = 50;
            h = 50;
        }

        public Rectangle(int x, int y)
            : base(x, y)
        {
            w = 50;
            h = 50;
        }
        public override void selectInContainsPoint(Point p)
        {
            if (p.X >= base.X && p.X <= base.X + w && p.Y >= base.Y && p.Y <= base.Y + h)
            {
                base.Selected = true;
            }
            else
            {
                base.Selected = false;
            }
        }
        public override void draw(Graphics g)
        {
            g.FillRectangle(Brush, base.X, base.Y, w, h);
            g.DrawRectangle(base.Selected ? Pens.Black : Pens.Gray, base.X, base.Y, w, h);
        }
    }
}
