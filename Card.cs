using System.Drawing;

namespace ConsoleApp1{
    class Card {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int RankID { get; set; }


        public Card(string rank, string suit) {
            this.Suit = suit;
            this.Rank = rank;

            switch(rank){
                case "Jack":
                case "jack":
                    RankID = 11;
                    break;
                case "Queen":
                case "queen":
                    RankID = 12;
                    break;
                case "king":
                case "King":
                    RankID = 13;
                    break;
                case "ace":
                case "Ace":
                    RankID = 14;
                    break;
                default:
                    RankID = int.Parse(rank);
                    break;
            }
        }

        public Image GetImageFile() {
            return (Image) Properties.Resources.ResourceManager.GetObject($"{(RankID <= 10 ? "_" : "") + this.Rank}_{this.Suit}");
        }

        public override string ToString() {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}
