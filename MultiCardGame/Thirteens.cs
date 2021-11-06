/* Ryan Brandt
 * CSC 350H
 * Professor Hao Tang
 * Project 1 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCardGame
{
    public class Thirteens : Dealer
    {
        public Thirteens()
        {
            deck = new Deck();
            goalsum = 13;
            ActiveCardsMax = 10;
            SelectedCards = new bool[ActiveCardsMax];
            score = 0;
            Load();
        }
        

        // overrides base board checking to return true if any of the cards are a King
        public override bool CheckBoardCombos()
        {
            bool isKingThere = false;
            foreach (Card c in InPlayCards)
                if (c.Rank == "King")
                    isKingThere = true;

            return (isKingThere || base.CheckBoardCombos());
        }

        // Checks for kings to remove, then checks if there are pairs that add up to remove
        public override bool ValidateSelection()
        {
            ReplaceKing();           
           
            return base.ValidateSelection();
        }

        // Overrides base Get Selection because we have to be able
        // To select and remove kings by themselves, but not from here?
        protected override void GetPlayerSelection()
        {
            // Validate selection of Kings and remove before the pair
            Console.WriteLine("Choose a pair of cards that add up to 13");
            Console.WriteLine("You can remove King cards by themselves.");

            int numSelect = 0;
            while (numSelect < 2)
            {                
                base.GetPlayerSelection();
                numSelect++;
                if (numSelect == 1)
                    if (ReplaceKing())
                        break;
                if (numSelect == 2)
                {
                    if (base.IsValidSum())
                        break;
                }
            }
            ValidateSelection();
        }

        

        // Compares if any kings have been selected, replaces them if so
        public bool ReplaceKing()
        {
            bool foundKing = false;
            for(int i = 0; i < SelectedCards.Length; i++)
            {
                if (SelectedCards[i])
                {
                    if(InPlayCards[i].Rank == "King")
                    {
                        ReplaceSelectedCards();
                        foundKing = true;
                    }
                }
            }
            return foundKing;
        }
    }    
}
