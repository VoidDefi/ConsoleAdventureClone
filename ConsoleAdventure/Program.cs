using System.Text;
using System;

namespace ConsoleAdventure
{
    public class Program
    {
        private static string ApplicationData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string SavePath => ApplicationData + "\\ConsoleAdventure-Clone\\";

        public static ConsoleAdventure Game { get; private set; }

        [STAThread]
        public static void Main()
        {
            Game = new ConsoleAdventure();

            try
            {
                Game.Run();
            }

            catch (Exception ex)
            {
                //ConsoleAdventure.logger.AddException(ex);
                throw;
            }
        }
    }
}