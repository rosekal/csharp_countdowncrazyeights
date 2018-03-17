using System;
using System.Windows.Forms;

namespace ConsoleApp1 {
    public partial class InitialForm : Form {
        public static string name;
        public static byte numOfPlayers;

        public InitialForm() {
            InitializeComponent();
        }
  
        private void btnPlay_Click(object sender, EventArgs e) {
            if(txtbxName.Text.Length == 0){
                errorProvider1.SetError(txtbxName, "Please enter a name.");
            }else if(txtbxName.Text.Length > 20) {
                errorProvider1.SetError(txtbxName, "Name can't be over 20 characters.");
            }
            else {
                name = txtbxName.Text;
                numOfPlayers = (byte) nudNumOfPlayers.Value; 
                this.Hide();
                GameForm game = new GameForm();
                game.Show();
            }
        }

        private void btnHowToPlay_Click(object sender, EventArgs e) {
            String howToPlay = "Eight cards are dealt to each player. The remaining cards of the deck are placed " +
                "face down at the center of the table. The top card is then turned face up to start the game.  " +
                "Players discard by matching rank or suit with the top card of the discard pile"+
                "  If a player is unable to match the rank or suit of the top card " +
                "of the discard pile and does not have an 8, they draw cards from the stockpile until they " +
                "get a playable card.  When a player plays an 8, they must declare the suit that the next player is " +
                "to play; that player must then follow the named suit or play another 8.\n\n" +
                "As an example: Once 6♣ is played the next player:\ncan play any of the other 6s\n"+
                "can play any of the clubs\ncan play any 8 (then must declare a suit)\ncan draw from the" +
                " stockpile until willing and able to play one of the above.\n\nThe game ends as soon as one player " +
                "has emptied their hand.\n\nWild cards\nJacks: miss a turn" +
                "\nQueen of Spades: pick up 5 cards from the deck\n2's: pickup 2 from the deck. When stacked or paired " +
                "with other 2's they add to the total you pick up ex.  Three 2's is 6 total cards picked up from the " +
                "deck.\n8's: are wild and can be used to change suit no matter what the card previously laid " +
                "down is. For example, Queen of clubs is laid, the next player lays 8 of diamonds and changes the suit to " +
                "hearts.\n\n" +
                "Now, that was Crazy Eights.  Don't worry, Countdown Crazy Eights isn't much different in terms of gameplay." +
                " Remember when the player who loses all his cards is the winner?  Well, this time he has to pick up 7 instead " +
                "of winning right away." +
                "  THAT player's \"wild\" card is now 7, instead of 8.  This means that to change suit, the player can" +
                " throw any 7, but not any 8.  Once he gets rid of all cards, the wild goes to 6, and so on.  Once a player " +
                "gets rid of all cards when their wild is \"1\", the game is complete!";
            MessageBox.Show(howToPlay, "How to play Countdown Crazy Eights");
        }

        private void InitialForm_Load(object sender, EventArgs e) {

        }
    }
}