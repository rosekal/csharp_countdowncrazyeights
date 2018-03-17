using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Human : Player{
        private Card refCard;

        public Human(string name, GroupBox gbx) : base(name, gbx) { }

        public override string ThrowDown(Card currentCard) {
            
            //If player can't go, pick up one.
            if (!CanGo(currentCard))
                PickUp(1);

            //If player stil can't go, skips turn.
            if (CanGo(currentCard)) { 
                bool badCard = false;
                Console.WriteLine("Here are your cards:");

                foreach (Card card in hand) 
                    Console.Write($"{card}\n");

                do {
                    Console.Write("Please choose a card and enter it here: ");
                    string chosenCard = Console.ReadLine();
                    string[] chosenCardDetails = Regex.Split(chosenCard, " of ");

                    if (CheckCard(currentCard, new Card(chosenCardDetails[0].ToLower(), chosenCardDetails[1].ToLower()))) {
                        badCard = true;
                        Console.WriteLine("That's an invalid card.  Please try again.");
                    }
                    else
                        badCard = false;

                } while (badCard);

                if(refCard.RankID == wild) {
                    bool badSuit = false;
                    do {
                        Console.Write("Enter the new suit: ");
                        string suit = Console.ReadLine().ToLower();
                        badSuit = CheckSuit(suit);

                        if (badSuit) {
                            Console.WriteLine("That's an invalid suit.  Please try again.");
                        }
                    } while (badSuit);
                }

                GameForm.Pile.Add(this.refCard);
                hand.Remove(this.refCard);
            }else
                Console.WriteLine($"{this.Name} can't go.");

            return null;
         }

        public override string ThrowDown(Card currentCard, string wildSuit) {
            throw new NotImplementedException();
        }

        private bool CheckCard(Card currentCard, Card chosenCard) {

            foreach (Card card in hand)
                //Checking to see if the player chose a card that's in their hand
                if (String.Equals(card.RankID, chosenCard.RankID) && String.Equals(card.Suit.ToLower(), chosenCard.Suit)) {
                    
                    //Checking to see if their chosen card is valid comparing to the flipped card
                    if (String.Equals(currentCard.RankID, chosenCard.RankID) || String.Equals(currentCard.Suit.ToLower(), chosenCard.Suit)) {
                        this.refCard = card;
                        return false;
                    }

                    //Checking to see if their chosen card is their current wild
                    if (int.Parse(chosenCard.Rank) == wild) {
                        this.refCard = card;
                        return false;

                    }
                }
            return true;
        }

        private bool CheckSuit(string chosenSuit) {
            if(String.Equals(chosenSuit, "clubs") || String.Equals(chosenSuit, "spades") || String.Equals(chosenSuit, "diamonds") || String.Equals(chosenSuit, "hearts")){
                return false;
            }

            return true;
        }
    }
}