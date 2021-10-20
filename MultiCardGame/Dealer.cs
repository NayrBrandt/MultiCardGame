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
        bool[] SelectedCards;
        public int score { get; }

        public Dealer()
        {
            deck = new Deck();
            goalsum = 10;
            ActiveCardsMax = 13;
            SelectedCards = new bool[13];
            score = 0;
        }

        public int Play()
        {
            // Not sure if I need this or if it's just staying in GameController
            return 0;
        }

        // Fill the board back up to however many cards should be on there
        private void FillBoard()
        {
            for(int i = 0; i < ActiveCardsMax; i++)
            {
                if (SelectedCards[i])
                {
                    Card newCard = deck.TakeTopCard();
                    newCard.FlipOver();
                    InPlayCards.Add(newCard);                    
                }
            }
            ResetSelectedCards();
        }

        // win state is determinant on if the deck and board are both empty
        public bool GameWon()
        {
            
            bool win = false;
            if (deck.Empty && InPlayCards.Count == 0)
                win = true;

            return win;
        }

        //this is showing the cards on the board I think
        private void DisplayCards()
        {
            
            int num = 1;
            foreach(Card c in InPlayCards)
            {
                Console.WriteLine(num + " " + c.Rank + " " + c.Suit + "\n");
                num++;
            }
        }

        // Flipping a toggle on Selected cards            
        private void GetPlayerSelection()
        {            
            Console.WriteLine("Enter a number to choose");
            bool choiceWorked = false;

            while (!choiceWorked)
            {
                int choice = Convert.ToInt16(Console.ReadLine());

                if (isValidInput(choice) && !SelectedCards[choice - 1])
                {
                    SelectedCards[choice - 1] = true;
                    choiceWorked = true;
                }
                else
                    Console.WriteLine("Invalid selection or card already chosen");
            }                
        }

        // Check if the input is a in bounds of the options given
        // Selected cards will always be the same size as the max size of the board
        private bool isValidInput(int userinput)
        {
            
            bool isValid = false;
            if (userinput <= SelectedCards.Length)
                isValid = true;

            return isValid;
        }

        //check the cards that are the ones on the board based on
        //the selected cards array and add them
        private bool IsValidSum()
        {            
            bool validSum = false;
            int valCard1 = 0;
            int valCard2 = 0;

            for(int i = 0; i < InPlayCards.Count; i++)
            {
                if (SelectedCards[i] && valCard1 == 0)
                {
                    valCard1 = (int)System.Enum.Parse(typeof(Rank), InPlayCards[i].Rank) + 1;
                }
                else
                    valCard2 = (int)System.Enum.Parse(typeof(Rank), InPlayCards[i].Rank) + 1;
            }
            if (valCard1 + valCard2 == goalsum)
                validSum = true;
            
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

        // compares selected cards to the cards on the board
        // and removes the appropriate cards
        private void RemoveSelectedCards()
        {
            for(int i = SelectedCards.Length; i > 0; i--)
            {
                if(SelectedCards[i])
                {
                    InPlayCards.RemoveAt(i);
                }
            }         

        }
        // Simply loops through the selected cards and makes them all false before the next set of selections start
        private void ResetSelectedCards()
        {
            for(int i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = false;
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
