using System.Diagnostics;
using Emgu.CV.Structure;

namespace IAR.Game
{
    public class Team
    {
        public List<Movable> players;
        
        Brush color { get; set; }
        public string teamName { get; set; }
        
        private LineSegment2D but;

        public int point=0;

        public LineSegment2D But
        {
            get { return but; }
            set
            {
                SetLineSegments(value);
            }
        }

        protected void SetLineSegments(LineSegment2D but)
        {
            this.but = but;
        }

        protected Boolean _attackingUp;

        public Boolean AttackingUp
        {
            get { return _attackingUp; }
        }

        public Team(List<Movable> joueurs,string teamName,Brush color) 
        {
            this.teamName = teamName;
            this.players = joueurs;
            this.color = color;
        }

        public void setAttackingUp(Boolean attackingUp,List<LineSegment2D> buts)
        {
            this._attackingUp = attackingUp;
            foreach (var player in players)
            {
                player.SetAttackingUp(attackingUp);
            }
            if (this._attackingUp)
            {
                buts = buts.OrderByDescending(but => but.P1.Y).ToList();
            }
            else
            {
                buts = buts.OrderBy(but => but.P1.Y).ToList();
            }
            this.SetLineSegments(buts[0]);
        }

        public Boolean LostAPoint(Movable ball)
        {
            Boolean behindTheBut = false;
            if (_attackingUp)
            {
                behindTheBut = ball.centerPoint.Y > but.P1.Y;
            }
            else
            {
                behindTheBut = ball.centerPoint.Y < but.P1.Y;
            }

            int xMin=Math.Min(but.P1.X, but.P2.X);
            int xMax=Math.Max(but.P1.X, but.P2.X);
            return xMin < ball.centerPoint.X && ball.centerPoint.X < xMax && behindTheBut;
        }

        public Movable GetPlayerNearestBall(Movable ball)
        {
            double min = 999999;
            Movable nearest = null;
            foreach (Movable player in players)
            {
                double distance = Math.Sqrt(Math.Pow(ball.centerPoint.X - player.centerPoint.X, 2) + Math.Pow(ball.centerPoint.Y - player.centerPoint.Y, 2));
                if (distance < min)
                {
                    nearest = player;
                    min = distance;
                }
            }
            return nearest;
        }

        public double GetMoyenne()
        {
            double moyenne = 0;
            foreach (Movable player in players)
            {
                moyenne += player.centerPoint.Y;
            }

            return moyenne / players.Count;
        }
        
        public void paint(Graphics g)
        {
            for(int i = 0; i < this.players.Count; i++)
            {
                players[i].paint(g,color);
            }
        }

        public Movable GetLastDefender()
        {
            Movable lastDefender=null;
            if (_attackingUp)
            {
                double max = 0;
                foreach (Movable player in this.players)
                {
                    if (player.centerPoint.Y>max)
                    {
                        lastDefender = player;
                        max = player.centerPoint.Y;
                    }
                }
                return lastDefender;
            }
            double min = 999999999d;
            foreach (Movable player in players)
            {
                if (player.centerPoint.Y < min)
                {
                    min = player.centerPoint.Y;
                    lastDefender = player;
                }
            }
            return lastDefender;
        }

        public Movable GetBeforeLastDefender()
        {
            Movable lastDefender = this.GetLastDefender();
            Movable beforeLastDefender=null;
            if (_attackingUp)
            {
                double max = 0;
                foreach (Movable player in players)
                {
                    if (player.centerPoint.Y > max && lastDefender != player)
                    {
                        beforeLastDefender = player;
                        max=player.centerPoint.Y;
                    }
                }
                return beforeLastDefender;
            }
            double min = 999999999d;
            foreach (Movable player in players)
            {
                if (player.centerPoint.Y < min && lastDefender != player)
                {
                    beforeLastDefender = player;
                    min = player.centerPoint.Y;
                }
            }
            return beforeLastDefender;
        }

        public List<Movable> GetPLayerInFrontOfTheBall(Movable ball)
        {
            List<Movable> mety = new List<Movable>();
            foreach (var player in players)
            {
                if (this._attackingUp)
                {
                    if (player.GetFrontPoint().Y < ball.centerPoint.Y)
                    {
                        mety.Add(player);
                    }
                    continue;
                }
                if (player.GetFrontPoint().Y > ball.centerPoint.Y)
                {
                    mety.Add(player);
                }
            }

            return mety;
        }
    }
}