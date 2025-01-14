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
        
        public List<Point> points { get; set; }

        public Movable(List<Point> point) 
        {
            this.points = point;
            this.backPoint = point[0];
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void paint(Graphics g,Brush brush)
        {
            foreach (Point point in points)
            {
                g.FillEllipse(brush, point.X, point.Y, 10, 10);
            }
        }
    }
}
