using System;

namespace MatatuCSharp{

    public class Deck{
        public Card[] cards = new Card[52];
        static public void shuffleDeck(int[] cards){  //method for shuffling
            Random rand = new Random();
            for(int i = cards.Length - 1; i > 0; --i){
                int randIdx = rand.Next(0, i + 1);
                int temp = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            } 
        }
    }
}