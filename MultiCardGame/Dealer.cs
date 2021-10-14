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
        bool[] SelectedCardsArray;
        int score;

        public Dealer()
        {

        }

        public int Play()
        {

            return 0;
        }
        private void FillBoard()
        {

        }
        private bool GameWon()
        {
            bool win = false;


            return win;
        }
        private void DisplayCards()
        {

        }
        private void GetPlayerSelection()
        {


        }
        private bool isValidInput(int userinput)
        {
            bool isValid = false;


            return isValid;
        }
        private bool IsValidSum()
        {
            bool validSum = false;

            return validSum;
        }
        private virtual bool CheckBoardCombos()
        {
            bool comboCheck;


            return comboCheck;
        }
        private virtual bool ValidateSelection()
        {
            bool selectCheck;

            return selectCheck;
        }
        private void RemoveSelectedCards()
        {


        }

        private void ResetSelectedCardsArray()
        {

        }
        private virtual bool ValidPair()
        {
            bool goodPair = false;


            return goodPair;
        }


    }
}
