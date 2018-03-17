using System;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Computer : Player
    {
        private Card refCard;

        public Computer(string name, GroupBox gbx) : base(name, gbx) { }

        //This method makes the computer throw down, if they can.
        public override string ThrowDown(Card currentCard) {
            if (!CanGo(currentCard))
                PickUp(1);

            if (CanGo(currentCard)) {
                //If there's any cards that match in terms of rank, do it first.  This is because this is less common than suits matching.
                if (RankMatch(currentCard)) {
                    GameForm.Pile.Add(refCard);
                    hand.Remove(refCard);

                //Then figure out if there's any suits available.
                } else if (SuitMatch(currentCard)) {
                    GameForm.Pile.Add(refCard);
                    hand.Remove(refCard);

                //If all else fails, throw down their wild card.
                } else if (HasWild()) {
                    GameForm.Pile.Add(refCard);
                    hand.Remove(refCard);
                }
            }
            else {
                Console.WriteLine($"{this.Name} can't go");
            }

            return null;
        }

        public override string ThrowDown(Card currentCard, string wildSuit) {
            throw new NotImplementedException();
        }

        //This method checks if there's any cards in hand that match with the current card in terms of rank
        private bool RankMatch(Card currentCard) {
            foreach (Card card in hand) {
                if (card.RankID == currentCard.RankID) {
                    refCard = card;
                    return true;
                }
            }
            return false;
        }

        //This method checks if there's any cards in hand that match with the current card in terms of suit
        private bool SuitMatch(Card currentCard) {
            foreach (Card card in hand) {
                if (String.Equals(card.Suit, currentCard.Suit)) {
                    refCard = card;
                    return true;
                }
            }
            return false;
        }

        //This method checks if there's any cards in hand that is a wild card
        private bool HasWild() {
            foreach (Card card in hand) {
                if (card.RankID == this.wild) {
                    refCard = card;
                    return true;
                }
            }
            return false;
        }
    }
}
