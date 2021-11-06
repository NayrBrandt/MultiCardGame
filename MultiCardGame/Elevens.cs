using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCardGame
{
    public class Elevens : Dealer
    {
        public Elevens()
        {
            deck = new Deck();
            goalsum = 11;
            ActiveCardsMax = 9;
            SelectedCards = new bool[ActiveCardsMax];
            score = 0;
            Load();
        }

        public override bool CheckBoardCombos()
        {
            return (ValidJQK() || base.CheckBoardCombos());
        }
        public override bool ValidateSelection()
        {
            // check if cards in play are ALL the same rank as the selected cards            
            int J = 0, Q = 0, K = 0;
            bool validJQK = false;
            for (int i = 0; i < SelectedCards.Length; i++)
            {
                if (SelectedCards[i])
                {
                    switch (InPlayCards[i].Rank)
                    {
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
            if (J == 1 && Q == 1 && K == 1)
                validJQK = true;
                        
            return (validJQK || base.ValidateSelection());
        }

        // Overrides base Get Selection because we have to be able
        // to select up to 3 cards for a valid selection
        protected override void GetPlayerSelection()
        {
            Console.WriteLine("Choose a pair of cards that add up to 11");
            Console.WriteLine("Or a combo of Jack, Queen, and King. ");
            int numSelect = 0;
            while (numSelect < 3)
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

        // Check for J + Q + K
        public bool ValidJQK()
        {
            bool validJQK = false;
            int counterJ = 0, counterQ = 0, counterK = 0;
            foreach (Card c in InPlayCards)
            {               
                if (c.Rank == "Jack")
                    counterJ++;
                if (c.Rank == "Queen")
                    counterQ++;
                if (c.Rank == "King")
                    counterK++;
            }
            if (counterJ > 0 &&
                counterQ > 0 &&
                counterK > 0)
                validJQK = true;
            
            return validJQK;
        }
    



    }


}
