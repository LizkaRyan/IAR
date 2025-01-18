using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using IAR.Database;
using IAR.Image;
using Npgsql;
using Console = System.Console;

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
            // NpgsqlConnection connection = DatabaseManager.GetConnection();
            // connection.Open();
            // var list=DatabaseManager.Get("select * from produit",connection);
            // connection.Close();
            // Console.WriteLine(list[0]["produit"]);
            // DatabaseManager.Execute("Insert into client(nom) values('Malko')");
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}