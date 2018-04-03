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
        private Card currentCard;
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

            StartRound();
        }

        private void StartRound() {
            int twosMultiplier = 1;
            bool firstRound = true, jack = false;
            string wildSuit = null;

            currentCard = Pile.Last();

            pbCurrentCard.Image = currentCard.GetImageFile();
            pbCurrentCard.Refresh();

            if (Deck.Count == 8) {
                UpdateMessage("Shuffling...");
                Deck = Pile.ToList();
                Shuffle();
            }

            //If it's not the first round, check if current card has wildcards properties
            if (!firstRound) {
                //If previous person throws down a rank of 2, the next person has to pick up.  Sequential 2's will increment the pick up by 2 
                if (currentCard.RankID == 2)
                    currentPlayer.PickUp(2 * twosMultiplier++);
                else
                    twosMultiplier = 1;

                if (currentCard.RankID == 11 && !jack) {
                    UpdateMessage($"{currentPlayer.Name} has missed their turn.");
                    jack = true;
                }
                else
                    jack = false;

                if (currentCard.RankID == 12 && String.Equals(currentCard.Suit, "Spades"))
                    currentPlayer.PickUp(5);

            }

            RefreshCards(currentPlayer);

            //pile.Last() is the 'flipped up' card, where the player needs to match a suit or rank with it (or place a wild card
            UpdateMessage($"\nIt's {currentPlayer.Name}'s turn. {(wildSuit != null ? $" (Follow suit: {wildSuit})" : "")}");

            Thread.Sleep(1000);

            if (currentPlayer is Human human) {
                if (!human.CanGo(currentCard)) {
                    human.PickUp(1);

                    if (!human.CanGo(currentCard))
                        AdvanceToNextPlayer();
                }
            }

            if (currentPlayer is Computer comp) 
                comp.ThrowDown(currentCard);
            

            if (currentPlayer.GetNumberInHand() == 0) {
                gameFinished = true;
                UpdateMessage($"And the game is over! {currentPlayer.Name} is the winner!");
            }

            if (currentPlayer is Computer) {
                RefreshCards(currentPlayer);
                AdvanceToNextPlayer();
            }

            firstRound = false;
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
                RefreshCards(player);
            }
            currentPlayer = players[0];
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

        private void RefreshCards(Player player) {
            //Removing all existing cards in gbx
            try {
                currentPlayer.gbx.Controls.Clear();
            }catch(Exception) {}

            List<PictureBox> pics = new List<PictureBox>();
            if (player is Human) {
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
                
                for (int i = pics.Count - 1; i >= 0; i--) {
                    pics[i].Left = i*20;
                    player.gbx.Controls.Add(pics[i]);
                }
            }
            
            else if (player is Computer) {

                Image image = Card.GetBlueBack();
                bool isPlayer2 = players.IndexOf(player) == 1;

                if (!isPlayer2) 
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                for (int i = 0; i < player.GetNumberInHand(); i++) {
                    PictureBox pb = new PictureBox {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = (isPlayer2 ? 90 : 140),
                        Height = (isPlayer2 ? 140 : 90),

                    };
                    pics.Add(pb);

                }

                for (int i = pics.Count - 1; i >= 0; i--) {
                    if (!isPlayer2) 
                        pics[i].Top = i * 20;
                    
                    else
                        pics[i].Left = i * 20;

                    player.gbx.Controls.Add(pics[i]);
                }
            }

            player.gbx.Refresh();
        }

        private void PictureBoxClicked(object sender, EventArgs e) {
            PictureBox pb =  (PictureBox) sender;

            if (((Human)currentPlayer).ThrowDown(currentCard, (Card)pb.Tag)) {
                currentPlayer.gbx.Controls.Remove(pb);
                pbCurrentCard.Image = pb.Image;
                currentCard = (Card) pb.Tag;
                RefreshCards(currentPlayer);
                AdvanceToNextPlayer();
            }
        }

        private void AdvanceToNextPlayer() {
            int nextPlayerIndex = players.IndexOf(currentPlayer) + 1;
            currentPlayer = players[(nextPlayerIndex >= players.Count ? 0 : nextPlayerIndex)];
            StartRound();
        }

        private void UpdateMessage(string message) {
            lblMessage.Text = message;
            lblMessage.Refresh();
        }
    }
}