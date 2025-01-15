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
        Movable ball { get; set; }

        public Match(Team team1,Team team2,Movable ball)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.ball = ball;
            this.setDirection();
        }
        
        protected void setDirection()
        {
            if (team1.GetMoyenne()<team2.GetMoyenne())
            {
                team1.attackingUp = false;
                team2.attackingUp = true;
            }
            else
            {
                team2.attackingUp = false;
                team1.attackingUp = true;
            }
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
                g.DrawString("H", font, Brushes.Black, movable.backPoint.X, movable.backPoint.Y);
            }
            font.Dispose();
        }

        public Team GetTeamLeadingTheBall()
        {
            double closest = 9999999999d;
            foreach (Movable player1 in team1.players)
            {
                double distance = Math.Sqrt(Math.Pow(ball.backPoint.X - player1.backPoint.X, 2) + Math.Pow(ball.backPoint.Y - player1.backPoint.Y, 2));
                if (distance < closest)
                {
                    closest = distance;
                }
            }
            foreach (Movable player2 in team2.players)
            {
                double distance = Math.Sqrt(Math.Pow(ball.backPoint.X - player2.backPoint.X, 2) + Math.Pow(ball.backPoint.Y - player2.backPoint.Y, 2));
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
                if (teamLeadingTheBall.attackingUp)
                {
                    if (player.backPoint.Y < beforeLastDefender.backPoint.Y && player.backPoint.Y < ball.backPoint.Y)
                    {
                        players.Add(player);
                    }
                }
                else
                {
                    if (player.backPoint.Y > beforeLastDefender.backPoint.Y && player.backPoint.Y > ball.backPoint.Y)
                    {
                        players.Add(player);
                    }
                }
            }
            return players;
        }
    }
}
