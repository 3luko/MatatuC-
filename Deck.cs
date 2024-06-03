using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{

    public class Deck{
        private Card[] cards = new Card[52];

        public Deck(){
            int i = 0;
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach(Value value in Enum.GetValues(typeof(Value))){
                    cards[i] = new Card(suit, value);
                    i++;
                }
            }

        }
        public Card[] Cards{
            get{
                return cards;
            }
        }
        static public void shuffleDeck(Card[] cards){  //method for shuffling
            Random rand = new Random();
            for(int i = cards.Length - 1; i > 0; --i){
                int randIdx = rand.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            } 
        }
    }
}