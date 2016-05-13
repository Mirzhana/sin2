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
            arr.Add(new PointF(0, 250));// Curve cannot be drawn without at least two points
            arr.Add(new PointF(0, 250));//So it is initial two points
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawWithLine(e);
            e.Graphics.DrawCurve(pen, arr.ToArray());
        
        }
        //drawing axis x and y
        private void DrawWithLine(PaintEventArgs e) 
        {
          
            Point p1 = new Point(0 , 250);
            Point p2 = new Point(500,250);
            Point p3 = new Point(260, 5);
            Point p4 = new Point(260, 500);
            Pen penO = new Pen(Color.Blue);
            e.Graphics.DrawLine(penO, p1, p2);
            e.Graphics.DrawLine(penO, p3, p4);
        }
    }
}
