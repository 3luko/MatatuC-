using System;

namespace MatatuCSharp{
    class Program{
        static void Main(string[] args){
            Random rand = new Random();

            int num = rand.Next(1,53);

            Card myCard = new Card(Suit.Club , Value.Ace);

            Console.WriteLine(myCard);
            


            Console.WriteLine(Planets.Earth + " is a planet. This is planet number " + (int)Planets.Earth);

        }

        enum Planets{
            Mercury = 1,
            Venus = 2,
            Earth = 3,
            Mars = 4,
            Jupiter = 5,
            Saturn = 6,
            Uranus = 7,
            Neptune = 8,
            Pluto = 9
        }
    }
}

