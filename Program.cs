using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){


           // string myValue = Console.ReadLine();
           
            //MENU

            Console.WriteLine("Welcome to Matatu!!\n");
            Console.Write("Press (1) to start game.\nPress (Enter) to exit.");
            string play = Console.ReadLine();
            if(play == "1"){
                Console.WriteLine("It's working!");
            } else {
                Console.WriteLine("Bye!");
            }
            
/*
            try
            {
                Value result = (Value)Int32.Parse(myValue);

                Card myCard = new Card(Suit.Clubs , result);
                Console.WriteLine(myCard);
            }
            catch (FormatException)
            {
               Console.WriteLine($"Unable to parse '{myValue}'");
            }

            */
        }
    }
}

