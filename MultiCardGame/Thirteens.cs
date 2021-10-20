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
        public bool ValidKing()
        {


            return true;
        }


    }
}
