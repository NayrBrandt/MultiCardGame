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
    public class Tens : Dealer
    {

        public Tens()
        {
            deck = new Deck();
            goalsum = 10;
            ActiveCardsMax = 13;
            SelectedCards = new bool[ActiveCardsMax];
            score = 0;
            Load();
        }

        // overrides the regular check of the board to also check for quartets
        public override bool CheckBoardCombos()
        {
            return(ValidQuartets() || base.CheckBoardCombos());
        }
        public override bool ValidateSelection()
        {
            // check if cards in play are ALL the same rank as the selected cards            
            int T = 0, J = 0, Q = 0, K = 0;
            bool validFour = false;            
            for(int i = 0; i < SelectedCards.Length; i++)
            {
                if(SelectedCards[i])
                {
                    switch (InPlayCards[i].Rank)
                    {
                        case "Ten":
                            T++;
                            break;
                        case "Jack":
                            J++;
                            break;
                        case "Queen":
                            Q++;
                            break;
                        case "King":
                            K++;
                            break;
                    }
                }
            }
            if (T == 4 || J == 4 || Q == 4 || K == 4)
                validFour = true;

            Console.WriteLine("Is there a valid 4? " + validFour);
            return( validFour ||  base.ValidateSelection());
        }

        // Overrides base Get Selection because we have to be able
        // to select up to 4 cards for a valid selection
        protected override void GetPlayerSelection()
        {
            Console.WriteLine("Choose a pair of cards that add up to 10");
            Console.WriteLine("Or a combo of four Tens, Jacks, Queens, or Kings.");
            int numSelect = 0;
            while(numSelect < 4)
            {
                base.GetPlayerSelection();
                numSelect++;
                if (numSelect == 2)
                {             
                    if (base.IsValidSum())                      
                        break;                    
                }                
            }
            ValidateSelection();
            
        }
        
        // Checks if there are 4 of any of the 10-value cards to remove
        public bool ValidQuartets()
        {
            bool validFour = false;
            int counterT = 0, counterJ = 0, counterQ = 0, counterK = 0;
            foreach(Card c in InPlayCards)
            {
                if (c.Rank == "Ten")
                    counterT++;
                if (c.Rank == "Jack")
                    counterJ++;
                if (c.Rank == "Queen")
                    counterQ++;
                if (c.Rank == "King")
                    counterK++;
            }
            if (counterT == 4 ||
                counterJ == 4 ||
                counterQ == 4 ||
                counterK == 4)
                validFour = true;
            // Console.WriteLine("Are there any quartets? " + validFour);
            return validFour;
        }
    }
}
