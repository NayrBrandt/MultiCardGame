using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCardGame
{
    class GameController
    {
        Dictionary<string, int> Highscores;
        List<string> Usernames;
        string CurrentUser;
        Dealer Sharp;



        public GameController()
        {
            Usernames = new List<string>();
            Highscores = new Dictionary<string, int>();            
        }


        // Shows the menu to select which game, then calls Run to start the game loop
        public void Start()
        {
            Menu();            
        }


        // calls the update function unless the game is won
        public void Run()
        {
            Console.WriteLine("Hello World");
            while (!Sharp.GameWon() && Sharp.CheckBoardCombos())
            {
                Update();
            }
                        
        }

        // will be called constantly from Run while the game has not been won
        private void Update()
        {
            if(Sharp.GameWon())
            {
                Console.WriteLine("Congrats, you won!\n\nWant to play again?");
                Highscores.Add(Usernames[0], Sharp.score); 
                Start();
            }
            Sharp.Play();
        }

        private void AddUser()
        {
            Console.WriteLine("Type in your name: \n\n");
            Usernames.Add(Console.ReadLine());
        }

        private void Menu()
        {
            int selection = 0;
            while (selection != 6)
            {              
                Console.WriteLine("Welcome to the game.Make a selection: \n" +
                "1. Add your Username to play\n" +
                "2. Show the high scores\n" +
                "3. Play Tens\n" +
                "4. Play Elevens\n" +
                "5. Play Thirteens\n" +
                "6. Quit\n\n");

                selection = Convert.ToInt16(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Add your Username");
                        AddUser();
                        CurrentUser = Usernames[0];
                        break;
                    case 2:
                        Console.WriteLine("Show the high scores");
                        break;
                    case 3:
                        Console.WriteLine("Play Tens");
                        Sharp = new Tens();
                        Run();
                        break;
                    case 4:
                        Console.WriteLine("Elevens");
                        Sharp = new Elevens();
                        break;
                    case 5:
                        Console.WriteLine("Thirteens");
                        Sharp = new Thirteens();
                        break;
                    case 6:
                        Bye();
                        break;
                    default:
                        Console.WriteLine("You have not made a valid selection." +
                            "\n Choose 1-5 or 6 to exit. \n\n");
                        break;
                }                
            }
        }

        private void Bye()
        {
            Console.WriteLine("\n\nOkay bye!\n\n");
            Environment.Exit(0);
        }
    }
}
