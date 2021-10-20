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
            goalsum = 10;
            ActiveCardsMax = 13;
            SelectedCards = new bool[13];
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
        public bool ValidJQK()
        {
            return true;
        }




    }


}
