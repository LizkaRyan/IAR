using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR
{
    public class Match
    {
        Team team1 { get; set; }
        Team team2 { get; set; }
        public Movable ball { get; set; }

        public Match(Team team1,Team team2,Movable ball)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.ball = ball;
            this.setDirection();
        }
        
        protected void setDirection()
        {
            Movable minY = null;
            Movable maxY = null;
            int valueMinY = 9999999;
            int valueMaxY = 0;
            foreach (var player in team1.players)
            {
                if (valueMinY>player.centerPoint.Y)
                {
                    valueMinY = player.centerPoint.Y;
                    minY = player;
                }
                if (valueMaxY<player.centerPoint.Y)
                {
                    valueMaxY = player.centerPoint.Y;
                    maxY = player;
                }
            }
            foreach (var player in team2.players)
            {
                if (valueMinY>player.centerPoint.Y)
                {
                    valueMinY = player.centerPoint.Y;
                    minY = player;
                }
                if (valueMaxY<player.centerPoint.Y)
                {
                    valueMaxY = player.centerPoint.Y;
                    maxY = player;
                }
            }

            if (team1.players.Contains(minY))
            {
                team1.setAttackingUp(false);
                team2.setAttackingUp(true);
                return;
            }
            team1.setAttackingUp(true);
            team2.setAttackingUp(false);
        }

        public void paint(Graphics g)
        {
            team1.paint(g);
            team2.paint(g);
            ball.paint(g,Brushes.Black);
            List<Movable> movables = GetPlayerOffside();
            Font font = new Font("Arial", 15);
            foreach (Movable movable in movables)
            {
                g.DrawString("H", font, Brushes.Black, movable.centerPoint.X, movable.centerPoint.Y);
            }
            font.Dispose();
        }

        public Team GetTeamLeadingTheBall()
        {
            double closest = 9999999999d;
            foreach (Movable player1 in team1.players)
            {
                double distance = Math.Sqrt(Math.Pow(ball.centerPoint.X - player1.centerPoint.X, 2) + Math.Pow(ball.centerPoint.Y - player1.centerPoint.Y, 2));
                if (distance < closest)
                {
                    closest = distance;
                }
            }
            foreach (Movable player2 in team2.players)
            {
                double distance = Math.Sqrt(Math.Pow(ball.centerPoint.X - player2.centerPoint.X, 2) + Math.Pow(ball.centerPoint.Y - player2.centerPoint.Y, 2));
                if (distance < closest)
                {
                    closest = distance;
                    return team2;
                }
            }
            return team1;
        }

        public Team GetOpposingTeam(Team team)
        {
            if (team == this.team1)
            {
                return team2;
            }
            return this.team1;
        }

        public Movable GetBeforeLastDefender()
        {
            Team teamLeadingTheBall = GetTeamLeadingTheBall();
            Team opposingTeam = GetOpposingTeam(teamLeadingTheBall);
            return opposingTeam.GetBeforeLastDefender();   
        }

        public List<Movable> GetPlayerOffside()
        {
            Team teamLeadingTheBall = GetTeamLeadingTheBall();
            Team opposingTeam = GetOpposingTeam(teamLeadingTheBall);
            Movable beforeLastDefender = opposingTeam.GetBeforeLastDefender();
            List<Movable> players = new List<Movable>();
            foreach (Movable player in teamLeadingTheBall.players)
            {
                if (teamLeadingTheBall.GetAttackingUp())
                {
                    if (player.GetFrontPoint().Y < beforeLastDefender.GetBackPoint().Y && player.GetFrontPoint().Y < ball.centerPoint.Y)
                    {
                        players.Add(player);
                    }
                }
                else
                {
                    if (player.GetFrontPoint().Y > beforeLastDefender.GetBackPoint().Y && player.GetFrontPoint().Y > ball.centerPoint.Y)
                    {
                        players.Add(player);
                    }
                }
            }
            return players;
        }
    }
}
