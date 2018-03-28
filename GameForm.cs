using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp1 {
    public partial class GameForm : Form {
        private string[] compNames = { "Matt", "Nate", "Arthur" };
        private List<Player> players = new List<Player>();
        private Player currentPlayer;
        private bool gameFinished = false;

        //deck is where the player picks up cards, the pile refers to all cards that were placed down (last index is 'flipped up')
        private static List<Card> pile = new List<Card>();
        private static List<Card> deck = new List<Card>();

        internal static List<Card> Pile { get => pile; set => pile = value; }
        internal static List<Card> Deck { get => deck; set => deck = value; }

        public GameForm() {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e) {
            string name = InitialForm.name;
            byte numOfPlayers = InitialForm.numOfPlayers;

            switch (numOfPlayers) {
                case 3:
                    gxPlayer3.Visible = true;
                    break;
                case 4:
                    gxPlayer3.Visible = true;
                    gxPlayer4.Visible = true;
                    break;
            }

            SetUp(name, numOfPlayers);

            int twosMultiplier = 1;
            bool firstRound = true, jack = false;
            string wildSuit = null;

            //The game in a do-while loop, ends when there is no more cards in the current player's hand
            do {
                foreach (Player currentPlayer in players) {
                    this.currentPlayer = currentPlayer;

                    Card currentCard = Pile.Last();
                    pbCurrentCard.Image = currentCard.GetImageFile();

                    if (Deck.Count == 8) {
                        lblMessage.Text = "Shuffling...";
                        Deck = Pile.ToList();
                        Shuffle();
                    }

                    //If it's the first round, don't check the special conditions.
                    if (!firstRound) {
                        //If previous person throws down a rank of 2, the next person has to pick up.  Sequential 2's will increment the pick up by 2 
                        if (currentCard.RankID == 2)
                            currentPlayer.PickUp(2 * twosMultiplier++);
                        else
                            twosMultiplier = 1;

                        if (currentCard.RankID == 11 && !jack) {
                            lblMessage.Text = $"{currentPlayer.Name} has missed their turn.";
                            jack = true;
                            continue;
                        }
                        else
                            jack = false;

                        if (currentCard.RankID == 12 && String.Equals(currentCard.Suit, "Spades"))
                            currentPlayer.PickUp(5);

                    }
                    else
                        firstRound = false;

                    //pile.Last() is the 'flipped up' card, where the player needs to match a suit or rank with it (or place a wild card
                    lblMessage.Text = $"\nIt's {currentPlayer.Name}'s turn. {(wildSuit != null ? $" (Follow suit: {wildSuit})" : "")}";

                    LoadCards(currentPlayer);
                    Thread.Sleep(1000);

                    //Go to the overriden ThrowDown method within either Human.cs or Computer.cs and pass the current card object
                    //If the previous card wasn't a wild suit (ThrowDown returns a string if true), pass the literal card values.
                    if (wildSuit == null)
                        wildSuit = currentPlayer.ThrowDown(currentCard);
                    else
                        wildSuit = currentPlayer.ThrowDown(currentCard, wildSuit);

                    if (currentPlayer.GetNumberInHand() == 0) {
                        gameFinished = true;
                        lblMessage.Text = $"And the game is over! {currentPlayer.Name} is the winner!";
                        break;
                    }
                }
            } while (!gameFinished);

            Console.ReadLine();
        }

        //This method sets up all the necessary attributes before starting the game
        void SetUp(string humanName, byte numOfPlayers) {
            PopulateCards();
            Shuffle();

            List<GroupBox> gbx = new List<GroupBox> { gxPlayer2, gxPlayer3, gxPlayer4 };

            for (int i = 0; i < numOfPlayers; i++) {
                if (i == 0) 
                    players.Add(new Human(humanName, gxPlayer1));
                else
                    players.Add(new Computer(compNames[i - 1], gbx[i-1]));
            }

            Pile.Add(Deck.First());
            Deck.RemoveAt(0);

            foreach(Player player in players) {
                LoadCards(player);
            }

        }

        //This method shuffles the deck using the Random class
        public void Shuffle() {
            Random rng = new Random();
            byte n = (byte)Deck.Count;

            while (n > 1) {
                n--;
                byte k = (byte)rng.Next(n + 1);
                Card tmp = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = tmp;
            }
        }


        //This method adds 52 card objects to the 'deck' list, using a for loop within a for loop and string arrays
        void PopulateCards() {
            string[] suits = { "Spades", "Clubs", "Hearts", "Diamonds" },
                     ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 13; j++) {
                    Deck.Add(new Card(ranks[j], suits[i]));
                }
        }

        private void LoadCards(Player player) {
            List<PictureBox> pics = new List<PictureBox>();
            if (player is Human) {
                int x = 0;
                foreach (Card c in ((Human)player).Hand) {
                    PictureBox pb = new PictureBox {
                        Tag = c,
                        Image = c.GetImageFile(),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 80,
                        Height = 120,
                    };

                    pb.Click += new EventHandler(PictureBoxClicked);

                    pics.Add(pb);
                }

                x = 20 * (player.GetNumberInHand() - 1);

                for (int i = pics.Capacity - 1; i >= 0; i--) {
                    pics[i].Left = x;
                    gxPlayer1.Controls.Add(pics[i]);

                    x -= 20;
                }
            }
            /*
            else if (player is Computer) {
                int y = 0;

                Image image = Card.GetBlueBack();
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                for (int i = 0; i < player.GetNumberInHand(); i++) {

                    PictureBox pb = new PictureBox {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 90,
                        Height = 140,

                    };


                    pb.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    pb.Refresh();
                    pics.Add(pb);

                }
                             

                foreach(PictureBox pb in pics){
                    pb.Top = y;
                    gxPlayer3.Controls.Add(pb);
                    y += 15;
                }
            }
            */
        }

        private void PictureBoxClicked(object sender, EventArgs e) {
            PictureBox pb =  (PictureBox) sender;
            Card card = (Card) pb.Tag;

            Debug.WriteLine(card);
            //currentPlayer.ThrowDown((Card) pb.Tag);
        }
    }
}
