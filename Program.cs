using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Project.Game MyGame = new Project.Game();
            MyGame.Setup();
            System.Console.WriteLine("Welcome to my game! What is your name?");
            string heroName = System.Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine($"{heroName}, you have been trapped within a series of caverns! Find your way out!");
            MyGame.ListCommands();
            System.Console.WriteLine("Begin? Y/N");
            string userInput = System.Console.ReadLine().ToUpper();
            if (userInput == "Y")
            {
                MyGame.PlayGame();

            }
            else
            {
                System.Console.WriteLine("Suit Yourself");
            }


        }
    }
}
