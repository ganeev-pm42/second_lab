using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Prog2
{
    abstract class GraphObject
    { 
        Color c;
        private int x, y;
       
        public bool Selected
        {
            set;
            get;
        }
        Brush brush;
        Random r = new Random();

        public Brush Brush { get { return brush; } }
        public int X
        {
            set
            {
                if ((value < 0) || (value > 500))
                {
                    throw new ArgumentException();
                }
                else
                {
                    x = value;
                }
            }
            get { return x; }
        }
        public int Y
        {
            set
            {
                if ((value < 0) || (value > 360))
                {
                    throw new ArgumentException();
                }
                else
                {
                    y = value;
                }
            }
            get { return y; }
        }
        public Point Location
        {
            set { x = value.X; y = value.Y; }
            get { return new Point(x, y); }
        }


        public GraphObject()
            : this(0, 0)
        {
            x = r.Next(200);
            y = r.Next(200);
        }

        public GraphObject(int x, int y)
        {
            Color[] cols = { Color.Red, Color.Green, Color.YellowGreen, Color.Tomato, Color.Cyan };
            c = cols[r.Next(cols.Length)];
            this.x = x;
            this.y = y;
            brush = new SolidBrush(c);
        }

        public abstract void draw(Graphics g);

        public abstract void selectInContainsPoint(Point p);
    }
}
