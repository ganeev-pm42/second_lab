using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prog2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void paint_panel(object sender, PaintEventArgs e)
        {
            foreach (GraphObject elem in elements)
            {
                elem.draw(e.Graphics);
            }
        }

        List<GraphObject> elements = new List<GraphObject>();
        GraphObject movingElem;
        bool press_elem;
        int dx, dy;
        Random r = new Random();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (r.Next(2) == 0)
            {
                elements.Add(new Rectangle());
            }
            else
            {
                elements.Add(new Ellipse());
            }
            panel1.Refresh();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            elements[0].X += 5;
            elements[0].Y += 5;
            panel1.Refresh();
        }

        private void panel_double_click(object sender, MouseEventArgs e)
        {
            GraphObject dr;
           // this.toolStripButton1_Click(sender, e);
           // func1();
            if (r.Next(2) == 0)
            {
                dr = new Rectangle(e.X, e.Y);
                elements.Add(dr);
            }
            else
            {
                dr = new Ellipse(e.X, e.Y);
                elements.Add(dr);
            }
            panel1.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (GraphObject elem in elements) {
                 if (elem.Selected)
                 {
                     elements.Remove(elem);
                     break;
                 }
            }
            panel1.Refresh();
        }

        private void mouse_down(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].selectInContainsPoint(e.Location);
                if (elements[i].Selected)
                {
                    if (movingElem != null)
                        movingElem.Selected = false;
                    movingElem = elements[i];
                }
            }
            if (movingElem != null)
            {
                press_elem = true;
                dx = e.X - movingElem.X;
                dy = e.Y - movingElem.Y;
            }
            panel1.Refresh();
        }

        private void mouse_mouve(object sender, MouseEventArgs e)    
        {
            if (press_elem)
            {
                try{  movingElem.X = e.X - dx; }
                catch (ArgumentException ex) 
                {
                    movingElem.X = 5;
                }
                try { movingElem.Y = e.Y - dy; }
                catch (ArgumentException)
                {
                    movingElem.Y = 5;
                }
                panel1.Refresh();
            }
        }

        private void mouse_up(object sender, MouseEventArgs e)
        {
            press_elem = false;
            if (movingElem != null)
                 movingElem = null;
        }

    }
}
