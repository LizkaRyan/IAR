using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR
{
    public class Movable
    {
        public Point backPoint { get; set; }
        
        public float radius { get; set; }
        
        public List<Point> points { get; set; }

        public Movable(Point point,float radius) 
        {
            this.backPoint = point;
            this.radius = radius;
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void paint(Graphics g,Brush brush)
        { 
            g.FillEllipse(brush, backPoint.X, backPoint.Y, radius*2, radius*2);
        }
    }
}
