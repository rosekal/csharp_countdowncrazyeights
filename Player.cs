using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConsoleApp1{
    abstract class Player{
        protected List<Card> hand = new List<Card>();
        protected int wild;
        public string Name { get; set; }
        public GroupBox gbx;

        public Player(string name, GroupBox gbx) {
            this.Name = name;
            this.wild = 8;
            PickUp(8);

            this.gbx = gbx;
            this.gbx.Text = this.Name;
        }

        public int GetNumberInHand() {
            return this.hand.Count();
        }

        //This method makes the player pick up x amount of cards from the deck
        public void PickUp(int num)  {
            for (int i = 0; i < num; i++) {
                hand.Add(GameForm.Deck[0]);
                GameForm.Deck.RemoveAt(0);
            }

            Console.WriteLine(Name + " has picked up " + (num == 1 ? "a card." : $"{num} cards"));
        }

        //Checking if the player can go by comparing all cards in hand with the flipped up card
        public bool CanGo(Card current) {
            foreach(Card card in hand) {
                if (String.Equals(card.Rank, current.Rank) || String.Equals(card.Suit, current.Suit) || String.Equals(card.Rank, "" + wild))
                    return true;
            }

            return false;
        }

        //Since human and computer play differently, an abstract method is needed.
        public abstract string ThrowDown(Card currentCard, string wildSuit);

    }
}
