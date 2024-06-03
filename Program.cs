using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){           
            //MENU
            bool startGame = true;
            bool playerPicked = false;

            Console.WriteLine("Welcome to Matatu!!\n");
            Console.Write("Press (1) to start game.\nPress (Enter) to exit.");
            string play = Console.ReadLine();
            if(play == "1"){
                Console.WriteLine("Shuffling deck...\n");
            } else {
                Console.WriteLine("Bye!");
                startGame = false;
            }
            int count = 0;
            Deck myDeck = new Deck();
            if(startGame){

                //player has to pick 4 cards from deck
                
                while(!playerPicked){ //while playerPicked is equal to false it will continue the loop
                    Console.WriteLine("Please pick 4 cards! (P)");
                    string playerPick = Console.ReadLine();
                
                    if(playerPick == "P" || playerPick == "p"){ //if the player presses p it will pick 4 cards and 
                        playerPicked = true;
                        
                    } 
                }
                
                
                

            }


        }

        
    }
}

