using System;
using System.Runtime.CompilerServices;

namespace MatatuCSharp{
    public class Program{
        static void Main(string[] args){           
            //MENU
            bool startGame = true;
            bool playerPicked = false;
            bool stop = false;
            bool is_Eight_Jack = false;
            bool is_Ace = false;
            bool playAceCard = false;
            int count = 0;
            string userChoice;
            string suit = "";
            string suit2 = "";
            Card topCard = null;
            
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
                    Console.WriteLine("Please select (P) to automatically pick 4 cards. Select (S) to end game.");
                    string playerPick = Console.ReadLine();
                
                    if(playerPick == "P" || playerPick == "p"){ //if the player presses p it will pick 4 cards and 
                        playerPicked = true;
                        player = new Player(myDeck);
                        computer = new Player(myDeck);
                        Player.showCards(player);
                        Player.firstCard(myDeck);
                    } else if (playerPick == "S" || playerPick == "s"){ // ends the game
                        startGame = false;
                        playerPicked = true;
                        Console.WriteLine("Thanks for playing!");
                    }
                }
                
                
                

                while(player.cardInHandAmount() > 0 && computer.cardInHandAmount() > 0){
                    Console.WriteLine("\n******************************************");
                    
                    if(!is_Eight_Jack){ //if they put an eight or jack it will skip the users turn
                        Console.WriteLine("\nTop of Deck: " + Player.TopWastedDeck);
                        
                        Console.WriteLine("\nPlease PLAY a card (1-" + player.cardInHandAmount() + "), (P) to pick a card, or (S) to STOP");
                        string playerCard = Console.ReadLine();
                        if(playerCard == "S" || playerCard == "s"){ //if the input is an S it will terminate the game
                            Console.WriteLine("Thanks for playing!");
                            stop = true;
                            break;
                        } else if(playerCard == "P" || playerCard == "p"){
                            Card yourPick = player.drawCard();
                            Console.WriteLine($"You picked a(n) {yourPick} from the deck");
                            if(Logic.canYouPlay(yourPick, Player.TopWastedDeck)){ //if the card that was picked is playable it will
                                Console.WriteLine("This card is playable would you like to play? (Select [y] for yes, or any other key for no.)");
                                userChoice = Console.ReadLine();
                                if(userChoice == "y" || userChoice == "Y"){
                                    player.playCard(player.cardInHandAmount());
                                    if(Logic.jack_and_eight(Player.TopWastedDeck)){ //still checks if value placed was an 8 or Jack
                                        Console.WriteLine("The computer has been skipped!");
                                        Player.showCards(player);
                                        continue;
                                    } else if(Logic.two_Value(computer)){ //checks if the computer played a value of 2
                                        Console.WriteLine("The computer drew 2 cards");
                                        Player.showCards(player);
                                    }
                                    Console.WriteLine("You played: " + Player.TopWastedDeck);
                                } else {
                                    Console.WriteLine("You decided to keep the card. Interesting...");
                                }
                            }
                        } else  { //if the user inserts a number it will check if the number is valid and play that card
                            int card2Play = int.Parse(playerCard);
                            if(card2Play > player.cardInHandAmount() || card2Play < 1){ //if the user inputs a card that isn't valid it will continue the loop asking them to play again.
                                Console.WriteLine("Please put a valid card number");
                                continue;
                            }
                            //NEED TO FINISH. 
                            //IF COMPUTER DECIDES TO DRAW
                            //YOU MUST STILL PLAY THE SUIT
                            //THAT YOU DECIDED FROM THE 
                            //PREVIOUS ACE.
                            if(!playAceCard){

                            }
                            if(!Logic.canYouPlay(player.chooseCard(card2Play), Player.TopWastedDeck)){ //if that card doesn't follow the rules of the game it will make you play again until it does
                                Console.WriteLine("You can't place that, you must put either a " + Player.TopWastedDeck.CardSuit + " Suit or a value of " + Player.TopWastedDeck.CardValue);
                                continue;
                            } 
                            player.playCard(card2Play);
                            Console.WriteLine("You played a(n) " + Player.TopWastedDeck);
                            if(Logic.ace_Value()){ //checking if the value at the top of the deck is an Ace value
                                is_Ace = true;
                                topCard = Player.TopWastedDeck;
                                while(suit != "h" && suit != "c" && suit != "s" && suit != "d"){
                                    Console.WriteLine("What suit would you like? (H) for Heart, (C) for Clubs, (S) Spades, and (D) Diamonds");
                                    suit = Console.ReadLine().ToLower();
                                    if(suit == "h"){
                                        suit2 = "Hearts";
                                    } else if(suit == "s"){
                                        suit2 = "Spades";
                                    } else if(suit == "c"){
                                        suit2 = "Clubs";
                                    } else if(suit == "d"){
                                        suit2 = "Diamonds";
                                    } else {
                                        Console.WriteLine("Please input either an (S) for spades, (H) for Hearts, (C) for Clubs, (D) for Diamonds.");
                                    }
                                }
                            } else if(Logic.jack_and_eight(Player.TopWastedDeck)){
                                Console.WriteLine("The computer has been skipped!");
                                Player.showCards(player);
                                continue;
                            } else if(Logic.two_Value(computer)){ //checks if the computer played a value of 2
                                Console.WriteLine("The computer drew 2 cards");
                                Player.showCards(player);
                                continue;
                            } 
                        }
                    }
                    if(player.cardInHandAmount() == 0){ //if the user has no cards left it will break out of the loop and show results
                        break;
                    }
                    is_Eight_Jack = false;
                    if(is_Ace){
                        if(Logic.computerChoiceACE(computer, suit)){
                            Console.WriteLine("\nThe Computer played: " + Player.TopWastedDeck);
                            Console.WriteLine("The computer has " + computer.cardInHandAmount() + " left in hand");
                            if (Logic.jack_and_eight(Player.TopWastedDeck)){
                                is_Eight_Jack = true;
                                Console.WriteLine("You have been skipped");  
                            } else if(Logic.two_Value(player)){
                                is_Eight_Jack = true;
                                Console.WriteLine("You must draw 2 cards :(");
                            } else {
                                Player.showCards(player);
                            }
                        } else { 
                            Console.WriteLine("\nThe Computer Drew a card. The top of the deck is still: \n" + Player.TopWastedDeck);
                        }
                        is_Ace = false;
                    } else if(Logic.computerChoice(Player.TopWastedDeck, computer)){ //makes the computer play a card or draw a card based on their in hand, and what's on top of the deck
                        Console.WriteLine("\nThe Computer played: " + Player.TopWastedDeck);
                        Console.WriteLine("The computer has " + computer.cardInHandAmount() + " left in hand");
                        if(Logic.jack_and_eight(Player.TopWastedDeck)){
                            is_Eight_Jack = true;
                            Console.WriteLine("You have been skipped");   
                        } else if(Logic.two_Value(player)){ //checks if the computer played a value of 2
                            is_Eight_Jack = true;
                            Console.WriteLine("You must draw 2 cards :(");
                        } 
                    } else{
                        Card computerCard = computer.chooseCard(computer.cardInHandAmount());
                        if(Logic.canYouPlay(computerCard, Player.TopWastedDeck)){ //checks if the computer can play the picked card
                            computer.playCard(computer.cardInHandAmount());
                            Console.WriteLine("The Computer picked and played a(n) " + Player.TopWastedDeck);
                        }else {
                            Console.WriteLine("\nThe Computer Drew a card. The top of the deck is still: \n" + Player.TopWastedDeck);
                        }
                    }
                    Player.showCards(player);
                }  
                if(!stop){
                    if(player.cardInHandAmount()  < 1){
                        Console.WriteLine("You Won! You have no more cards left!  :)");
                    }  else {
                        Console.WriteLine("The Computer Won! :(");
                    }
                }            
            }
        }   
    }
}