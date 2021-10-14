// Ryan Brandt //
// CSC 350H    //
// Professor Hao Tang //
// Project 1 - Multiple Card Games //



using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        bool isEmpty;
        static Random random = new Random();

        public Deck() 
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }


        // checks if cards.Count is 0, if so, we know the deck is empty and will return true.
        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        // takes the top card from the deck and returns it.
        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }
            else
                return null;
        }

        //will print out the list of cards, face up.
        public void Print() 
        {
            int num = 1;
            foreach(Card c in cards)
            {
                c.FlipOver(); // have to flip over cards to show them
                Console.WriteLine(num + " " + c.Rank + " of " + c.Suit); // ex 1 Ace of Spades
                num++; // incrementer for the card numbers
            }
        }
        
        // Homework 1.2
        //will randomly rearrange the cards, should run in linear time
        public void Shuffle() 
        {
            
            for (int i = cards.Count-1; i > 0; --i) // starts at the end of the deck and counts backwards
            {
                int rand = random.Next(i+1);
                Card temp = cards[i]; // take our last card and hold it 
                cards[i] = cards[rand]; // take a random card and put it in the last position
                cards[rand] = temp; // take our last card and put it where the random card was taken from
            }
           
        }

        // selects the midpoint of the deck and moves all cards below that point to the top, in order.
        public void Cut() 
        {
            int mid = (cards.Count / 2); // divide the deck in two
            Card[] cutArr = new Card[cards.Count]; // holder array for the cut
            cards.CopyTo(mid, cutArr, 0, mid); // starting at mid, fill up the start of cutArr
            cards.CopyTo(0, cutArr, mid, mid); // starting at 0, take the top half and put it behind, in cutArr
            cards.Clear(); // necessary so there are not two decks when we are done
            cards.InsertRange(0, cutArr); //inserts the now-cut cutArr into our decks' cards
        }

        public int Size()
        {
            return cards.Count;
        }
    }
}
