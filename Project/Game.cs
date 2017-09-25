using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public List<Room> Rooms = new List<Room>();
        public List<Item> Inventory = new List<Item>();
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        Item BearMace = new Item("Bear Mace", "Who knows! This may come in handy!");

        public void Reset()
        {

        }

        public void Setup()
        {
            //Build Rooms
            Room room1 = new Room("You Have Entered: The Dark Cavern", "You can't see too much, but notice two entryways. You also notice bear mace, and a sword on the ground.");
            Room room2 = new Room("You Have Entered: The Bear's Lair", "Oh no! You have awoken a very angry momma bear");
            Room room3 = new Room("You Have Entered: Room of Nothing", "There seems to be nothing living here, but in the distance you hear eerie noises. Proceed with caution!");
            Room room4 = new Room("You Have Entered: Abyss of Death", "You took a wrong turn and fell into the abyss of death. See you in the afterlife.");
            Room room5 = new Room("YOU DID IT!", "CONGRATULATIONS SOCIETY WELCOMES YOU BACK");
            Room room6 = new Room("You Have Entered: The Bear's Lair", "The Bear seems to have ran off!");
            //Establish Relationships
            room1.Exits.Add("E", room2);
            room2.Exits.Add("W", room1);
            room2.Exits.Add("E", room3);
            room3.Exits.Add("E", room5);
            room3.Exits.Add("S", room4);
            room3.Exits.Add("W", room6);
            room6.Exits.Add("E", room3);


            //build Items and add to rooms


            room1.Items.Add(BearMace);


            CurrentRoom = room1;
        }

        public void PlayGame()
        {

            Item BearMace = new Item("Bear Mace", "Who knows! This may come in handy!");

            //System.Console.Clear();
            System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);
            System.Console.WriteLine("Type B to add Bear Mace To Inventory.");
            string userInput = System.Console.ReadLine();
            if (userInput == "b" || userInput == "B")
            {
                Inventory.Add(BearMace);
                System.Console.WriteLine("You added Bear Mace to Inventory");
            }
            else
            {
                System.Console.WriteLine("Alright, you've got your fists!");
            }
            System.Console.WriteLine("Alright Where to?");
            string secondInput = System.Console.ReadLine().ToUpper();
            if (secondInput == "W" || secondInput == "N" || secondInput == "S")
            {
                System.Console.WriteLine("Can't go that way, try again.");
                System.Console.WriteLine("Alright Where to?");
                string seconInput = System.Console.ReadLine().ToUpper();
                if (secondInput == "H" || secondInput == "h")
                {
                    ListCommands();
                }
                Go(seconInput);
            }
            Go(secondInput);
            System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);
            if (CurrentRoom.Name == "You Have Entered: The Bear's Lair")
            {
                System.Console.WriteLine("Quickly Use one of your Items!!");
                string bearSurvival = System.Console.ReadLine().ToUpper();
                if (bearSurvival == "MACE" && Inventory.Contains(BearMace))
                {
                    System.Console.WriteLine("You Use Your Bear Mace! The Bear Retreats into the darkness!");
                    System.Console.WriteLine("Alright, Where to? Your Possible Exits are 'E or W'");
                    string UserChoice = System.Console.ReadLine().ToUpper();
                    if (UserChoice == "N" || UserChoice == "S")
                    {
                        System.Console.WriteLine("You Can't Go That Way");
                        string Redemption = System.Console.ReadLine().ToUpper();
                        if (Redemption == "N" || Redemption == "S")
                        {
                            System.Console.WriteLine("You still Cant go that way.");

                        }
                        else if(Redemption == "E")
                        {
                            Go(Redemption);
                        }
                        else if(Redemption == "W")
                        {
                            System.Console.WriteLine("You want to give up already? youre a loser");
                        }
                        else if(Redemption == "H")
                        {
                            ListCommands();
                        }
                        else if(Redemption == "Q")
                        {
                            System.Console.WriteLine("Why Quit Now!! You're so close.");
                        }
                    }
                    else if(UserChoice == "W")
                    {
                        System.Console.WriteLine("You want to give up already? Youre a loser");
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong Choice, you were mauled. Game over.");
                }
            }


        }

        public void Go(string direction)
        {
            CurrentRoom = CurrentRoom.Exits[direction];

        }

        public void UseItem(string itemName)
        {
            if (itemName == "Bear Mace")
            {

                if (Inventory.Contains(BearMace))
                {
                    System.Console.WriteLine("You wield your Bear mace.");
                }
                else
                {
                    System.Console.WriteLine("You don't have that item!");
                }
            }
        }
        public void ListCommands()
        {
            System.Console.WriteLine("COMMANDS");
            System.Console.WriteLine("N, Move North");
            System.Console.WriteLine("S, Move South");
            System.Console.WriteLine("E, Move East");
            System.Console.WriteLine("W, Move West");
            System.Console.WriteLine("H, Display Commands");
            System.Console.WriteLine("Q, Quit Game");
            System.Console.WriteLine("MACE, Use Bear Mace");
        }
    }
}