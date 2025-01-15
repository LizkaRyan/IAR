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

        public Boolean attackingUp;

        public Team(List<Movable> joueurs,string teamName,Brush color) 
        {
            this.teamName = teamName;
            this.players = joueurs;
            this.color = color;
        }

        public double GetMoyenne()
        {
            double moyenne = 0;
            foreach (Movable player in players)
            {
                moyenne += player.backPoint.Y;
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
                    if (player.backPoint.Y>max)
                    {
                        lastDefender = player;
                        max = player.backPoint.Y;
                    }
                }
                return lastDefender;
            }
            double min = 999999999d;
            foreach (Movable player in players)
            {
                if (player.backPoint.Y < min)
                {
                    min = player.backPoint.Y;
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
                    if (player.backPoint.Y > max && lastDefender != player)
                    {
                        beforeLastDefender = player;
                        max=player.backPoint.Y;
                    }
                }
                return beforeLastDefender;
            }
            double min = 999999999d;
            foreach (Movable player in players)
            {
                if (player.backPoint.Y < min && lastDefender != player)
                {
                    beforeLastDefender = player;
                    min = player.backPoint.Y;
                }
            }
            return beforeLastDefender;
        }
    }
}