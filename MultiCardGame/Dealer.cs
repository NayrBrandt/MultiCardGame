using System;
using System.Collections.Generic;

namespace MultiCardGame
{
    class Dealer
    {
        int ActiveCardsMax;
        int goalsum;
        Deck deck;
        List<Card> InPlayCards;
        bool[] SelectedCardsArray;
        int score;

        public Dealer()
        {
            deck = new Deck();
            goalsum = 10;
            ActiveCardsMax = 2;
            SelectedCardsArray = new bool[10];
            score = 0;
        }

        public int Play()
        {
            // Not sure if I need this or if it's just staying in GameController
            return 0;
        }
        private void FillBoard()
        {

        }
        private bool GameWon()
        {
            // win state is determinant on if the deck and board are both empty
            bool win = false;
            if (deck.Empty && InPlayCards.Count == 0)
                win = true;

            return win;
        }
        private void DisplayCards()
        {
            //this is showing the cards on the board I think?
            

        }
        private void GetPlayerSelection()
        {
            //just getting a number from the user and that's it?
            Console.WriteLine("Enter a number to choose");
            Console.ReadLine();

        }
        private bool isValidInput(int userinput)
        {

            //Check if the input is a correct option
            bool isValid = false;


            return isValid;
        }
        private bool IsValidSum()
        {
            //check the cards that are the ones on the board based on
            //the selected cards array and add them
            bool validSum = false;



            return validSum;
        }
        public virtual bool CheckBoardCombos()
        {

            //this one is going to be annoying, will need to loop through all the combos?
            // can usually ignore face cards or put them in a separate array depending on game?
            bool comboCheck = false;


            return comboCheck;
        }
        public virtual bool ValidateSelection()
        {
            //separate from valid sum because you could just be picking cards you don't want to add
            bool selectCheck = false;

            return selectCheck;
        }
        private void RemoveSelectedCards()
        {
            // just removes the cards 

        }
        // Simply loops through the selected cards and makes them all false before the next set of selections start
        private void ResetSelectedCardsArray()
        {
            for(int i = 0; i < SelectedCardsArray.Length; i++)
            {
                SelectedCardsArray[i] = false;
            }
        }
        public virtual bool ValidPair()
        {
            //not sure why this is separate from the other two validate functions but we'll see
            bool goodPair = false;


            return goodPair;
        }


    }
}
