using System;
using System.Collections.Generic;

namespace MultiCardGame
{
    public class Dealer
    {
        protected int ActiveCardsMax;
        protected int goalsum;
        protected Deck deck;
        protected List<Card> InPlayCards;
        protected bool[] SelectedCards;
        public int score { get; protected set; }

        public Dealer()
        {
            deck = new Deck();
            goalsum = 10;
            ActiveCardsMax = 13;
            SelectedCards = new bool[13];
            score = 0;
            Load();
        }

        // dealing out the original board of cards
        protected void Load()
        {
            for (int i = 0; i < ActiveCardsMax; i++)
            {
                Card freshCard = deck.TakeTopCard();
                freshCard.FlipOver();
                InPlayCards.Add(freshCard);
            }
        }

        // Should only be 1 game loop of logic
        public void Play()
        {
            if (CheckBoardCombos())
            {
                DisplayCards();
                GetPlayerSelection();
                ValidateSelection();
                RemoveSelectedCards();
                FillBoard();
            }
            else
                Console.WriteLine("No combos left! Game Over!");
                        
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
        protected virtual void GetPlayerSelection()
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
        protected bool IsValidSum()
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

        // Loop through the combos on the board, return as soon as a valid combo is found
        public virtual bool CheckBoardCombos()
        {
            bool comboCheck = false;
            int valCard1 = 0;
            int valCard2 = 0;

            // I think this is n**2 time but it's only ever looping through 2x 13 elements
            foreach(Card c in InPlayCards)
            {
                valCard1 = (int)System.Enum.Parse(typeof(Rank), c.Rank) + 1;
                //starting at 1 because outside loop starts at 0 and we don't need to compare a card against itself
                for (int i = 1; i < InPlayCards.Count-1; i++) 
                {
                    // GOING TO NEED A REFACTOR!!!!!
                    valCard2 = (int)System.Enum.Parse(typeof(Rank), InPlayCards[i].Rank) + 2;
                    if (valCard1 + valCard2 == goalsum)
                        comboCheck = true; break;
                }
            }            
            return comboCheck;
        }
        //separate from valid sum because you could just be picking cards you don't want to add
        public virtual bool ValidateSelection()
        {     

            return IsValidSum();
            // need to override                       
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
