using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){           
            //MENU
            bool startGame = true;
            bool playerPicked = false;
            

            Console.WriteLine("Welcome to Matatu!!\n");
            Console.Write("Press (1) to START GAME OR (Enter) to EXIT.");
            string play = Console.ReadLine();
            if(play == "1"){
                Console.WriteLine("Shuffling deck...\n");
            } else {
                Console.WriteLine("Bye!");
                startGame = false;
            }
            
            Deck myDeck = new Deck();
            myDeck.shuffleDeck();
            Player player = null;
            if(startGame){

                //player has to pick 4 cards from deck
                
                while(!playerPicked){ //while playerPicked is equal to false it will continue the loop
                    Console.WriteLine("Please PICK 4 cards! (P) or (S) to END GAME");
                    string playerPick = Console.ReadLine();
                
                    if(playerPick == "P" || playerPick == "p"){ //if the player presses p it will pick 4 cards and 
                        playerPicked = true;
                        player = new Player(myDeck);
                        Console.WriteLine("Showing Hand...\n");
                        foreach (Card card in player.SeeCards)
                        {
                            Console.WriteLine(card);
                            
                        }
                    } else if (playerPick == "S" || playerPick == "s"){ // ends the game
                        startGame = false;
                        playerPicked = true;
                        Console.WriteLine("Thanks for playing!");
                    }
                }
                bool played = false;

                while(player.cardInHandAmount() > 0){
                    Console.WriteLine("\nPlease PLAY a card (1-" + player.cardInHandAmount() + ") or (H) to SHOW HAND or (S) to STOP");
                    string playerCard = Console.ReadLine();
                    if(playerCard == "S" || playerCard == "s"){ //if the input is an S it will terminate the game
                        Console.WriteLine("Thanks for playing!");
                        break;
                    } else if(playerCard == "H" || playerCard == "h"){ //if the user input is an H it will show what is currently in your hand
                        Console.WriteLine("Showing Hand...\n");
                        foreach (Card card in player.SeeCards)
                        {
                            Console.WriteLine(card);
                            
                        }
                    } else { //if the user inserts a number it will check if the number is valid and play that card
                        int card2Play = int.Parse(playerCard);
                        if(card2Play > player.cardInHandAmount() || card2Play < 1){
                            Console.WriteLine("Please put a valid card number");
                            continue;
                        }
                        player.playCard(card2Play);
                        Console.WriteLine("Top of waste deck:\n" + player.TopWastedDeck);
                    }
                }    
            }


        }

        
    }
}

