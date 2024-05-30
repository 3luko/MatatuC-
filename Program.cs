using System;

namespace FiguringCardGame
{
    class Program{
        static void Main(string[] args){
            Random rand = new Random();

            int num = rand.Next(1,53);
            

            Console.WriteLine(Planets.Earth + " is a planet");

        }

        enum Planets{
            Mercury,
            Venus,
            Earth,
            Mars,
            Jupiter,
            Saturn,
            Uranus,
            Neptune,
            Pluto
        }
    }
}

