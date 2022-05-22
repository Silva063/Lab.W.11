using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab.W._11
{
    public partial class Form1 : Form
    {

        int r = 100;
        int count = 8;
        Point[] points = new Point[8];
        Point center;
        double angle1 = -Math.PI * 0.5;
        int p = 0;
        private Pen pen = new Pen(Color.Black, 2);
        private int x = 0, y = 0;
        const int d = 30;
        Graphics g;
        int w = 0;
        int steps = 2;
        int wid, hei, x2, y2;

       

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            center.X = ClientSize.Width / 2;
            center.Y = ClientSize.Height / 2;

            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(
                    center.X + (int)Math.Round(Math.Cos(angle1 + Math.PI * 2.0 * i / count) * r),
                    center.Y + (int)Math.Round(Math.Sin(angle1 + Math.PI * 2.0 * i / count) * r)
                );
            }
            wid = ClientSize.Width;
            hei = ClientSize.Height;
            timer1.Interval = 50; 
            timer1.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawPolygon(pen, points);
            g.FillEllipse(Brushes.Maroon, x, y, d, d);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            x = ClientSize.Width / 2;
            y = ClientSize.Height - 300;
        }

         private void timer1_Tick(object sender, EventArgs e)
        {
            if (p == 0)
            {
                x2 = center.X -10 + (int)Math.Round(Math.Cos(angle1 + Math.PI * 2.0 * w / count) * r);
                y2 = center.Y -10 + (int)Math.Round(Math.Sin(angle1 + Math.PI * 2.0 * w / count) * r);
                w++;
                p = 10;
            }
            x = x + (x2 - x) * 1 / steps;
            y = y + (y2 - y) * 1 / steps;

            p--;
            Invalidate();
        }
    }
}
