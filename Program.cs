using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){


           // string myValue = Console.ReadLine();
           /*
            //MENU

            Console.WriteLine("Welcome to Matatu!!\n");
            Console.Write("Press (1) to start game.\nPress (Enter) to exit.");
            string play = Console.ReadLine();
            if(play == "1"){
                Console.WriteLine("It's working!");
            } else {
                Console.WriteLine("Bye!");
            }
            */
            
            int[] cards = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            shuffleTest(cards);
            foreach(int val in cards){
                Console.Write(val);
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

        static public void shuffleTest(int[] cards){
            Random rand = new Random();
            for(int i = cards.Length - 1; i > 0; --i){
                int randIdx = rand.Next(1, i + 1);
                int temp = cards[i];
                cards[i] = cards[randIdx];
                cards[randIdx] = temp;
            } 
        }
    }
}

