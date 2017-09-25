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
            System.Console.WriteLine("Would you like to play again? Y/N");
            string UserChoice = System.Console.ReadLine().ToUpper();
            if (UserChoice == "N")
            {
                System.Console.WriteLine("Alrighty then");
            }
            else
            {
                System.Console.Clear();
                Setup();
                System.Console.WriteLine("Welcome to my game! What is your name?");
                string heroName = System.Console.ReadLine();
                System.Console.Clear();
                System.Console.WriteLine($"{heroName}, you have been trapped within a series of caverns! Find your way out!");
                ListCommands();
                System.Console.WriteLine("Begin? Y/N");
                string userInput = System.Console.ReadLine().ToUpper();
                if (userInput == "Y")
                {
                    
                    PlayGame();

                }
            }
        }

            public void Setup()
            {
                //Build Rooms
                Room room1 = new Room("You Have Entered: The Dark Cavern", "You can't see too much, but notice two entryways. You also notice bear mace on the ground.");
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
                System.Console.WriteLine("Alright Where to? You can travel 'E'");
                string secondInput = System.Console.ReadLine().ToUpper();
                if (secondInput == "W" || secondInput == "N" || secondInput == "S")
                {
                    System.Console.WriteLine("Can't go that way, try again.");
                    System.Console.WriteLine("Alright Where to? You can travel 'E'");
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
                            else if (Redemption == "E")
                            {
                                Go(Redemption);
                            }
                            else if (Redemption == "W")
                            {
                                System.Console.WriteLine("You want to give up already? youre a loser");
                            }
                            else if (Redemption == "H")
                            {
                                ListCommands();
                            }
                            else if (Redemption == "Q")
                            {
                                System.Console.WriteLine("Why Quit Now!! You're so close.");
                            }
                        }
                        else if (UserChoice == "W")
                        {
                            System.Console.WriteLine("You want to give up already? Youre a loser");
                        }
                        else if (UserChoice == "E")
                        {
                            Go(UserChoice);
                            System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);
                            System.Console.WriteLine("Alright, Where to? Your Possible Exits are 'W' 'E' or 'S'");
                            string nextChoice = System.Console.ReadLine().ToUpper();
                            Go(nextChoice);
                            System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);

                        }
                        else if (UserChoice == "H")
                        {
                            ListCommands();
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong Choice, you were mauled. Game over.");
                    }
                }
                if (CurrentRoom.Description == "The Bear seems to have ran off!")
                {
                    System.Console.WriteLine("Alright Where, to? You can only go 'E'");
                    string UserChoice = System.Console.ReadLine().ToUpper();
                    if (UserChoice == "H")
                    {
                        ListCommands();
                        string secondChoice = System.Console.ReadLine().ToUpper();
                        if (secondChoice == "E")
                        {
                            Go(secondChoice);
                            System.Console.WriteLine("Alright, Where to? You can go 'E' or 'S'");
                            string thirdChoice = System.Console.ReadLine().ToUpper();
                            if (thirdChoice == "E" || thirdChoice == "S")
                            {
                                Go(thirdChoice);
                            }
                            else if (thirdChoice == "Q")
                            {
                                System.Console.WriteLine("You are a quitter");
                            }
                            else if (thirdChoice == "H")
                            {
                                ListCommands();
                                System.Console.WriteLine("Alright Where, to? You can go 'E' or 'S'");
                                string fourthChoice = System.Console.ReadLine();
                                if (fourthChoice == "E" || fourthChoice == "S")
                                {
                                    Go(thirdChoice);
                                }
                                else
                                {
                                    System.Console.WriteLine("The Bear tracked you down and mauled you. Game over");
                                }

                            }
                            else
                            {
                                System.Console.WriteLine("The bear tracked you down and mauled you. Game over");
                            }

                        }
                        else
                        {
                            System.Console.WriteLine("The Bear returned and ate you for dinner! Game Over");
                        }
                    }
                    else if (UserChoice == "Q")
                    {
                        System.Console.WriteLine("You are a quitter. You have to live with that.");
                    }
                    else if (UserChoice == "E")
                    {
                        Go(UserChoice);
                        System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);
                        System.Console.WriteLine("Alright, Where to? You can Go 'E' or 'S'");
                        string secondChoice = System.Console.ReadLine().ToUpper();
                        if (secondChoice == "H")
                        {
                            ListCommands();
                            string thirdChoice = System.Console.ReadLine().ToUpper();
                            if (thirdChoice == "E" || thirdChoice == "S")
                            {
                                Go(thirdChoice);
                            }
                        }
                        if (secondChoice == "Q")
                        {
                            System.Console.WriteLine("You are a quitter.");
                        }
                        if (secondChoice == "E" || secondChoice == "S")
                        {
                            Go(secondChoice);
                            System.Console.WriteLine(CurrentRoom.Name + "- " + CurrentRoom.Description);

                        }

                    }
                    else
                    {
                        System.Console.WriteLine("The Bear returned and ate you for dinner. Game Over.");
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