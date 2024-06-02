using System;

namespace MatatuCSharp
{
    class Card{
        public Suit Suit { get; }
        public Value Value { get; }

        public Card(Suit suit, Value val){
            Suit = suit;
            Value = val;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
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
        Jack = 10,
        Queen = 11,
        King = 12
    }

    public enum Suit {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
}