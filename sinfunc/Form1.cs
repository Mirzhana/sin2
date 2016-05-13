using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinfunc
{
    public partial class Form1 : Form
    {
        List<PointF> arr = new List<PointF>(); //All points of the function y=sinx
        Pen pen = new Pen(Color.Red); //Pen for drawing y=sinx
        public Form1()
        {
            Timer t = new Timer(); //new timer
            t.Interval = 100; //Each point will be drawen after 100 ms 
            t.Tick += T_Tick;
            t.Start();
            InitializeComponent();
            
           
        }
        public void PutPixel(Graphics g, int x, int y, Color c)
        {
            Bitmap bm = new Bitmap(1, 1);
            bm.SetPixel(0, 0, c);
            g.DrawImageUnscaled(bm, x, y);
        }
        bool m_bPlotTanSeries = true;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.Clear(Color.LightYellow);
            Rectangle rect = new Rectangle(0, 0, 500, 400);

            int margin = 60;
            int width = rect.Width - margin * 2;
            int height = rect.Height - margin * 2;

            Pen tPen = new Pen(Color.Black);
            g.DrawRectangle(tPen, 0 + margin / 2, 0 + margin / 2, width, height);
            g.DrawLine(tPen, 0 + margin / 2, margin / 2 + height / 2, width + margin / 2, margin / 2 + height / 2);

            double legendypos = margin;
            double legendxpos = margin;

            double PI = Math.PI;
           

            if (m_bPlotTanSeries == true)
            {
                double factor = 10; // Don't use this factor, it is only for drawing purpose.
                tPen = new Pen(Color.DarkBlue);
                Brush br = new SolidBrush(Color.DarkBlue);
               for (double i = 0; i <= 720.01; i += 0.1)
                {
                    double value = Math.Tan(i * PI / 180);

                    if (value > factor)
                        value = factor;
                    if (value < -factor)
                        value = -factor;
                    value += factor;

                    int ypos = (int)(value / (factor * 2) * height + margin / 2);
                    int xpos = (int)(i / 720.0 * width + margin / 2);

                    PutPixel(g, xpos, ypos, Color.DarkBlue);

                }
                g.DrawString("TAN Series - DarkBlue Color", Font, br, (float)legendxpos, (float)legendypos, StringFormat.GenericDefault);
                legendypos += 20;
            }
            g.Dispose();
        }

 
        int x;
        private void T_Tick(object sender, EventArgs e)
        {
            double y = Math.Sin(x++);
            double px = x * 10;
            double py = -y * 10 + 250;
            arr.Add(new PointF((float)px, (float)py));
            Refresh();
        }


        
    }
}
