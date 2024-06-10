using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace MatatuCSharp
{
    public class Logic{
        public static bool computerChoice(Card topCard, Player computer){
            bool suit = false;
            bool value = false;
            int idx = 0;
            
            foreach(Card card in computer.SeeCards){
                if(card.CardSuit == topCard.CardSuit){
                    suit = true;
                }
                if(card.CardValue == topCard.CardValue){
                    value = true;
                }
                if(suit || value){
                    break;
                }
                idx++;
            }
            if(suit || value){
                idx++;
                computer.playCard(idx);
                return true;
            } else {
                computer.drawCard();
                return false;
            }
        }

        //method that makes sure the computer plays whatever card
        //that you chose in as the suit after playing an ace
        //it automatically checks it's deck and 

        public static bool computerChoiceACE(Player computer, String suit){
            bool suits = false;
            int idx = 0;

            if(suit == "h" || suit == "H"){//if the string inputed is an h meaning they want hearts
                foreach (Card card in computer.SeeCards)//checks each card in the computers deck
                {
                    if(card.CardSuit == Suit.Hearts){ //if it finds the card it will break loop
                        suits = true;
                        idx++;
                        break;
                    }
                    idx++;
                }
                if(suits){ //it will play that card and return true;
                    computer.playCard(idx);
                    return true;
                } else { //if suits is false it will just draw a card
                    computer.drawCard();
                    return false;
                }

            } else if(suit == "c" || suit == "C"){ //does the same for if it is a club
                foreach (Card card in computer.SeeCards)
                {
                    if(card.CardSuit == Suit.Clubs){
                        suits = true;
                        idx++;
                        break;
                    }
                    idx++;
                }
                if(suits){
                    computer.playCard(idx);
                    return true;
                } else {
                    computer.drawCard();
                    return false;
                }

            } else if(suit == "s" || suit == "S"){ //if the suit is a spade
                foreach (Card card in computer.SeeCards)
                {
                    if(card.CardSuit == Suit.Spades){
                        suits = true;
                        idx++;
                        break;
                    }
                    idx++;
                }
                if(suits){
                    computer.playCard(idx);
                    return true;
                } else {
                    computer.drawCard();
                    return false;
                }

            } else if(suit == "d" || suit == "D"){ //if the suit is a diamond
                foreach (Card card in computer.SeeCards)
                {
                    if(card.CardSuit == Suit.Diamonds){
                        suits = true;
                        idx++;
                        break;
                    }
                    idx++;
                }
                if(suits){
                    computer.playCard(idx);
                    return true;
                } else {
                    computer.drawCard();
                    return false;
                }

            } else {
                Console.WriteLine("Invalid suit entered. The computer will play as the Ace's Suit.");
                return false;
            }
        }



        //method to check if a card is valid to play
        //returns a bool variable

        public static bool canYouPlay(Card yourCard, Card topcard){
            if(yourCard.CardSuit == topcard.CardSuit || yourCard.CardValue == topcard.CardValue || yourCard.CardValue == Value.Ace){
                return true;
            } else {
                return false;
            }  
        }

        //method to allow the player to play whatever suit 
        //they want and if the computer can't play they
        //will have to play that card.

        public static bool playAce(Card yourCard, string suit){
            if(suit == "Hearts"){
                if(yourCard.CardSuit == Suit.Hearts){
                    return true;
                } else {
                    return false;
                }
            } else if(suit == "Spades"){
                if(yourCard.CardSuit == Suit.Spades){
                    return true;
                } else {
                    return false;
                }
            } else if(suit == "Clubs"){
                if(yourCard.CardSuit == Suit.Clubs){
                    return true;
                } else {
                    return false;
                }
            } else if(suit == "Diamonds"){
                if(yourCard.CardSuit == Suit.Diamonds){
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        //method to check if the card at the top is an
        //eight or a jack. If it is the player that is next
        //(Computer your user) will be skipped.

        public static bool jack_and_eight(Card topCard){
            if(topCard.CardValue == Value.Eight || topCard.CardValue == Value.Jack){
                return true;
            } else {
                return false;
            }   
        }

        //method that checks if the value placed 
        //at the top of the waste deck is a two
        //then it will automatically make you play 
        //two cards
        public static bool two_Value(Player player){
            if(Player.TopWastedDeck.CardValue == Value.Two){
                player.drawCard();
                player.drawCard();
                return true;
            } else {
                return false;
            }
        }


        //methed that checks if the value at the top
        //of the waste deck is an ace.
        //if it is an ace it will allow any suit to 
        //be placed.

        public static bool ace_Value(){
            if(Player.TopWastedDeck.CardValue == Value.Ace){
                return true;
            }
            return false;
        }

        //method that checks if the value at the top wasted deck is a seven.

        public static bool firstSevenCard(){
            if(Player.TopWastedDeck.CardValue == Value.Seven){
                return true;
            } else {
                return false;
            }
        }

        
    }
}