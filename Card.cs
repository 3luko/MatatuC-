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
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King
    }

    public enum Suit {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
}