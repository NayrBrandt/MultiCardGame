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

        public void Start()
        {
            Menu();
            Run();
        }

        public void Run()
        {
            Console.WriteLine("Hello World");
            
        }

        private void Update()
        {

        }

        private void AddUser()
        {
            Console.WriteLine("Type in your name: \n\n");
            Usernames.Add(Console.ReadLine());
        }

        private void Menu()
        {
            Console.WriteLine("Welcome to the game. Make a selection: ");
            int selection = Convert.ToInt16(Console.ReadLine());
            while (selection != 6)
            {
                Console.WriteLine("\n" +
                "1. Add your Username to play\n" +
                "2. Show the high scores\n" +
                "3. Play Tens\n" +
                "4. Play Elevens\n" +
                "5. Play Thirteens\n" +
                "6. Quit\n\n");
                                       
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Add your Username");
                        AddUser();
                        CurrentUser = Usernames[1];
                        break;
                    case 2:
                        Console.WriteLine("Show the high scores");
                        break;
                    case 3:
                        Console.WriteLine("Play Tens");
                        break;
                    case 4:
                        Console.WriteLine("Elvens");
                        break;
                    case 5:
                        Console.WriteLine("Thirteens");
                        break;
                    default:
                        Console.WriteLine("You have not made a valid selection." +
                            "\n Choose 1-5 or 6 to exit. \n\n");
                        break;
                }
                selection = Convert.ToInt16(Console.ReadLine());
            }


        }

        private void Restart()
        {

        }
    }
}
