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
    }
}