using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Human : Player{
        private Card refCard;

        public List<Card> Hand {
            get => hand;
        }

        public Human(string name, GroupBox gbx) : base(name, gbx) { }

        public bool ThrowDown(Card currentCard, Card chosenCard) {
            //Checking to see if their chosen card is valid comparing to the flipped card
            if (String.Equals(currentCard.RankID, chosenCard.RankID) || String.Equals(currentCard.Suit.ToLower(), chosenCard.Suit.ToLower())) {
                GameForm.Pile.Add(chosenCard);
                hand.Remove(chosenCard);
                return true;
            }

            //Checking to see if their chosen card is their current wild
            if (chosenCard.RankID == wild) {
                GameForm.Pile.Add(chosenCard);
                hand.Remove(chosenCard);
                return true;
            }

            return false;
         }

        public override string ThrowDown(Card currentCard, string wildSuit) {
            throw new NotImplementedException();
        }

        private bool CheckSuit(string chosenSuit) {
            if(String.Equals(chosenSuit, "clubs") || String.Equals(chosenSuit, "spades") || String.Equals(chosenSuit, "diamonds") || String.Equals(chosenSuit, "hearts")){
                return false;
            }

            return true;
        }

        public string Test() {
            return Name;
        }
    }
}