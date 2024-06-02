using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){


           // string myValue = Console.ReadLine();
           
            //MENU
            bool startGame = true;

            Console.WriteLine("Welcome to Matatu!!\n");
            Console.Write("Press (1) to start game.\nPress (Enter) to exit.");
            string play = Console.ReadLine();
            if(play == "1"){
                Console.WriteLine("It's working!");
            } else {
                Console.WriteLine("Bye!");
                startGame = false;
            }

            if(startGame){
                Console.WriteLine("Shuffling Deck!\n");
                Console.WriteLine("Please pick 4 cards! (P)");
                
            }





        }

        
    }
}

