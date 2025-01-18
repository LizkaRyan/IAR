namespace IAR.Game
{
    public class Movable
    {
        public Point centerPoint { get; set; }
        
        protected Point frontPoint { get; set; }
        
        protected Point backPoint { get; set; }
        
        public float radius { get; set; }
        
        public List<Point> points { get; set; }

        protected Boolean attackingUp { get; set; }

        public Movable(Point point,float radius) 
        {
            this.centerPoint = point;
            this.radius = radius;
        }

        public void SetAttackingUp(Boolean attackingUp)
        {
            this.attackingUp = attackingUp;
            if (attackingUp)
            {
                frontPoint = new Point(centerPoint.X, centerPoint.Y-(int)radius);
                backPoint = new Point(centerPoint.X, centerPoint.Y+(int)radius);
                return;
            }
            frontPoint = new Point(centerPoint.X, centerPoint.Y+(int)radius);
            backPoint = new Point(centerPoint.X, centerPoint.Y-(int)radius);
        }

        public Point GetFrontPoint()
        {
            return frontPoint;
        }

        public Point GetBackPoint()
        {
            return backPoint;
        }

        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public void paint(Graphics g,Brush brush)
        { 
            g.FillEllipse(brush, centerPoint.X, centerPoint.Y, radius*2, radius*2);
        }
    }
}
