using System;

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

        //method to check if a card is valid to play
        //returns a bool variable

        public static bool canYouPlay(Card yourCard, Card topcard){
            if(yourCard.CardSuit == topcard.CardSuit || yourCard.CardValue == topcard.CardValue){
                return true;
            } else {
                return false;
            }  
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

        public static bool value_ACE(Card topCard){

            return false;
        }

        
    }
}