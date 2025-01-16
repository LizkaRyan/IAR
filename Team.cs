using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR
{
    public class Team
    {
        public List<Movable> players { get; set; }
        Brush color { get; set; }
        public string teamName { get; set; }

        protected Boolean attackingUp=false;

        public Team(List<Movable> joueurs,string teamName,Brush color) 
        {
            this.teamName = teamName;
            this.players = joueurs;
            this.color = color;
        }

        public Boolean GetAttackingUp()
        {
            return this.attackingUp;
        }

        public void setAttackingUp(Boolean attackingUp)
        {
            this.attackingUp = attackingUp;
            foreach (var player in players)
            {
                player.SetAttackingUp(attackingUp);
            }
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
            if (attackingUp)
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
            Debug.WriteLine(attackingUp);
            if (attackingUp)
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
                if (this.attackingUp)
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