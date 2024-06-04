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
            Player computer = null;
            if(startGame){

                //player has to pick 4 cards from deck
                
                while(!playerPicked){ //while playerPicked is equal to false it will continue the loop
                    Console.WriteLine("Please PICK 4 cards! (P) or (S) to END GAME");
                    string playerPick = Console.ReadLine();
                
                    if(playerPick == "P" || playerPick == "p"){ //if the player presses p it will pick 4 cards and 
                        playerPicked = true;
                        player = new Player(myDeck);
                        computer = new Player(myDeck);
                        Console.WriteLine("Showing Hand...\n");
                        int count = 1;
                        foreach (Card card in player.SeeCards)
                        {
                            Console.WriteLine(card + " (" + count + ")" );
                            count++;
                            
                        }
                        
                    } else if (playerPick == "S" || playerPick == "s"){ // ends the game
                        startGame = false;
                        playerPicked = true;
                        Console.WriteLine("Thanks for playing!");
                    }
                }
                Console.WriteLine("******************************************");
                bool played = false;
                bool stop = false;

                while(player.cardInHandAmount() > 0 && computer.cardInHandAmount() > 0){
                    Console.WriteLine("\nPlease PLAY a card (1-" + player.cardInHandAmount() + "), (H) to SHOW HAND, (P) to pick a card, or (S) to STOP");
                    string playerCard = Console.ReadLine();
                    if(playerCard == "S" || playerCard == "s"){ //if the input is an S it will terminate the game
                        Console.WriteLine("Thanks for playing!");
                        stop = true;
                        break;
                    } else if(playerCard == "H" || playerCard == "h"){ //if the user input is an H it will show what is currently in your hand
                        Console.WriteLine("Showing Hand...\n");
                        int count = 1;
                        foreach (Card card in player.SeeCards)
                        {
                            Console.WriteLine(card + " (" + count + ")" );
                            count++;
                            
                        }
                        Console.WriteLine("\nTop of Deck: " + Player.TopWastedDeck);
                    } else if(playerCard == "P" || playerCard == "p"){
                        Card yourPick = player.drawCard();
                        Console.WriteLine($"You picked a {yourPick} from the deck");
                        Console.WriteLine("\nThe Computer played:");
                        computer.playCard(1);
                        Console.WriteLine(Player.TopWastedDeck);
                    } else  { //if the user inserts a number it will check if the number is valid and play that card
                        int card2Play = int.Parse(playerCard);
                        if(card2Play > player.cardInHandAmount() || card2Play < 1){
                            Console.WriteLine("Please put a valid card number");
                            continue;
                        }
                        player.playCard(card2Play);
                        Console.WriteLine("You played:\n" + Player.TopWastedDeck);
                        
                        if(Logic.computerChoice(Player.TopWastedDeck, computer)){
                            Console.WriteLine("\nThe Computer played: " + Player.TopWastedDeck);
                        } else {
                            Console.WriteLine("\nThe Computer Drew a card. The top of the deck is still: \n" + Player.TopWastedDeck);
                        }
                        
                    }
                    Console.WriteLine("\n******************************************");
                }  
                if(!stop){
                    if(player.cardInHandAmount() < 1){
                        Console.WriteLine("You Won! You have no more cards left!");
                    
                    }  else {
                        Console.WriteLine("The Computer Won!");
                    }

                }
                
                
            }


        }

        
    }
}

