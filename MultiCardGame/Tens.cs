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
        public override bool CheckBoardCombos()
        {
            Console.WriteLine("In the Tens Checking the combos");
            return base.CheckBoardCombos();
        }
        public override bool ValidateSelection()
        {
            // check if cards in play are ALL the same rank as the selected cards
            /* THIS IS A DUMB HACKY WAY TO MAKE THIS WORK AND I WANT TO FIX IT LATER */
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


            return( validFour ||  base.ValidateSelection());
        }
        protected override void GetPlayerSelection()
        {
            int numSelect = 0;
            while(numSelect < 4)
            {
                base.GetPlayerSelection();
                if (numSelect == 2)
                    if (base.ValidateSelection()) break;
            }     
            
        }
        //ValidPair() : bool <<override>>
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

            return validFour;
        }
    }
}
