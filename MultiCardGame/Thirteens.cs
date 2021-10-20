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
        }
        public override bool CheckBoardCombos() 
        {
            return true;
        }
        public override bool ValidateSelection()
        {
            return true;
        }
        // GetPlayerSelection() : void <<override>>
        //ValidPair() : bool <<override>>
        public bool ValidKing()
        {


            return true;
        }


    }
}
