using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{

    public class Deck{
        private List<Card> cards;

        public Deck(){
            cards = new List<Card>();
            for(int i = 0; i < 4; i++){
                for(int j = 1; j <= 13; j++){
                    cards.Add(new Card((Suit)i, (Value)j));
                }
            }
        }
        public List<Card> Cards{
            get{
                return cards;
            }
        }
        static public void shuffleDeck(List<Card> cards){  //method for shuffling
            Random rand = new Random();
            
            for(int i = cards.Count - 1; i > 0; --i){
                int randIdx = rand.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            } 
        }
    }
}