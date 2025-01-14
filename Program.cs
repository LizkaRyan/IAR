using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using IAR.Image;

namespace IAR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            // List<Movable> joueurs1 = new List<Movable>();
            // joueurs1.Add(new Movable(new Point(10, 10)));
            // joueurs1.Add(new Movable(new Point(20, 15)));
            // joueurs1.Add(new Movable(new Point(15, 30)));
            // joueurs1.Add(new Movable(new Point(5, 40)));
            // Team team1 = new Team(joueurs1);
            // team1.attackingUp = true;
            //
            // List<Movable> joueurs2 = new List<Movable>();
            // joueurs2.Add(new Movable(new Point(5, 5)));
            // joueurs2.Add(new Movable(new Point(5, 15)));
            // joueurs2.Add(new Movable(new Point(5, 32)));
            // joueurs2.Add(new Movable(new Point(5, 35)));
            // Team team2 = new Team(joueurs2);
            // team2.attackingUp = false;
            //
            // Match match = new Match(team1,team2,new Movable(new Point(5, 4)));
            //
            // List<Movable> players=match.GetPlayerOffside();
            //
            // foreach (Movable player in players)
            // {
            //     Debug.WriteLine(player.point);
            // 
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}