using System;

namespace MatatuCSharp
{
    public class Player{
        private List<Card> cardsInHand;
        private List<Card> deckOfCards;

        private List<Card> wastedDeck;
        
        public Player(Deck myDeck){
            deckOfCards = myDeck.Cards;
            cardsInHand = new List<Card>();

            for(int i = 0; i < 4; i++){
                cardsInHand.Add(drawCard());
            }

        }


        public void playCard(){ //method to play a card

        }

        public Card drawCard(){ 
            if(deckOfCards.Count == 0){
                throw new InvalidOperationException("No cards left!");
            } else {
                Card drawnCard = deckOfCards[0];
                deckOfCards.RemoveAt(0);
                return drawnCard;
            }
        }

        public List<Card> SeeCards{
            get{
                return cardsInHand;
            }
        }

    }
}