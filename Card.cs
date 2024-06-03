using System;

namespace MatatuCSharp
{
    public class Card{
        private Suit suit;
        private Value value;
        
        public Card(Suit suit1, Value value1){
            suit = suit1;
            value = value1;
        }

        public Suit CardSuit{
            get { return suit;}
        }

        public Value CardValue{
            get{return value;}
        }
        public override string ToString(){
            return $"{value} of {suit}";

        }
    }

    public enum Value{
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public enum Suit {
        Hearts = 0,
        Spades = 1,
        Diamonds = 2,
        Clubs = 3
    }
}