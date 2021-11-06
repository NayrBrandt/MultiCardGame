/* Ryan Brandt
 * CSC 350H
 * Professor Hao Tang
 * Project 1 
 */

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
            ActiveCardsMax = 13;
            goalsum = 10;
            deck = new Deck();
            InPlayCards = new List<Card>();
            SelectedCards = new bool[13];
            score = 0;            
        }

        // dealing out the original board of cards
        protected void Load()
        {
            deck.Shuffle();
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

                Console.WriteLine("There are " + deck.Size() + " cards left in the deck.");

                DisplayCards();
                GetPlayerSelection();
                ValidateSelection();
                ReplaceSelectedCards();
            }
                        
        }

        // win state is determinant on if the deck and board are both empty
        public bool GameWon()
        {            
            bool win = false;
            if (deck.Empty && InPlayCards.Count == 0)
                win = true;

            return win;
        }

        // shows the cards on the board
        private void DisplayCards()
        {
            
            int num = 1;
            foreach(Card c in InPlayCards)
            {
                Console.WriteLine(num + " " + c.Rank + " " + c.Suit);
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
                else if (SelectedCards[i])
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
            for(int i = 0; i < InPlayCards.Count; i++)
            {
                valCard1 = (int)System.Enum.Parse(typeof(Rank), InPlayCards[i].Rank) + 1;
                //Console.WriteLine("Card 1 " + InPlayCards[i].Rank + " val is " + valCard1);                
                for (int j = 0; j < InPlayCards.Count; j++) 
                {
                    if (i == j) // Don't compare a card with itself
                        continue;
                    
                    valCard2 = (int)System.Enum.Parse(typeof(Rank), InPlayCards[j].Rank) + 1;

                    if (valCard1 + valCard2 == goalsum)
                        comboCheck = true; //break;
                }
            }            
            return comboCheck;
        }
        //separate from valid sum because you could just be picking cards you don't want to add
        public virtual bool ValidateSelection()
        {
            // should always be overridden
            // should not check SUM, if they made a mistake should reset and let them check again

            if(!IsValidSum())
                ResetSelectedCards();
            return false;                                 
        }

        
        // This replaces the cards that have been selected and then calls the function
        // to reset the cards that have been selected
        protected void ReplaceSelectedCards()
        {
            // loop through, if find a match at [i], then
            // draw, flip over, replace, in that loop through.
            // I don't need to change this behavior as long as my selected cards
            // array is accurate? 

            for (int i = InPlayCards.Count-1; i >= 0; i--)
            {
                if (SelectedCards[i])
                {
                    if (!deck.Empty)
                    {
                        Card newCard = deck.TakeTopCard();
                        newCard.FlipOver();
                        InPlayCards[i] = newCard;
                    }
                    else
                        InPlayCards.RemoveAt(i);
                }
                
            }
            ResetSelectedCards();
        }

        // Simply loops through the selected cards and makes them all false before the next set of selections start
        private void ResetSelectedCards()
        {
            for(int i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = false;
            }
        }    

    }
}
