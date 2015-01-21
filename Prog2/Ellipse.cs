using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Prog2
{
    class Ellipse : GraphObject
    {
        int a, b;
        public Ellipse()
        {
            a = 30;
            b = 25;
        }

        public Ellipse(int x, int y)
            : base(x, y)
        {
            a = 30;
            b = 25;
        }
        public override void draw(Graphics g)
        {
            g.FillEllipse(Brush, base.X, base.Y, 2 * a, 2 * b);
            g.DrawEllipse(base.Selected ? Pens.Black : Pens.Gray, base.X, base.Y, 2 * a, 2 * b);
        }

        public override void selectInContainsPoint(Point p)
        {
            int x0, y0;
            x0 = X + a ;
            y0 = Y + b ;
            if ((((double)p.X - x0) * (p.X - x0) / (a * a) + ((double) p.Y - y0) * (p.Y - y0) / (b * b)) <= 1)
            {
                base.Selected = true;
            }
            else
            {
                base.Selected = false;
            }
        }
    }
}
