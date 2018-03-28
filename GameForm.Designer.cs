namespace ConsoleApp1 {
    partial class GameForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gxPlayer1 = new System.Windows.Forms.GroupBox();
            this.gxPlayer2 = new System.Windows.Forms.GroupBox();
            this.gxPlayer3 = new System.Windows.Forms.GroupBox();
            this.gxPlayer4 = new System.Windows.Forms.GroupBox();
            this.lblCurrentCard = new System.Windows.Forms.Label();
            this.pbCurrentCard = new System.Windows.Forms.PictureBox();
            this.pbPile = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPile)).BeginInit();
            this.SuspendLayout();
            // 
            // gxPlayer1
            // 
            this.gxPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gxPlayer1.Location = new System.Drawing.Point(307, 488);
            this.gxPlayer1.Name = "gxPlayer1";
            this.gxPlayer1.Size = new System.Drawing.Size(350, 150);
            this.gxPlayer1.TabIndex = 0;
            this.gxPlayer1.TabStop = false;
            // 
            // gxPlayer2
            // 
            this.gxPlayer2.Location = new System.Drawing.Point(307, 12);
            this.gxPlayer2.Name = "gxPlayer2";
            this.gxPlayer2.Size = new System.Drawing.Size(350, 150);
            this.gxPlayer2.TabIndex = 1;
            this.gxPlayer2.TabStop = false;
            // 
            // gxPlayer3
            // 
            this.gxPlayer3.Location = new System.Drawing.Point(12, 151);
            this.gxPlayer3.Name = "gxPlayer3";
            this.gxPlayer3.Size = new System.Drawing.Size(150, 350);
            this.gxPlayer3.TabIndex = 2;
            this.gxPlayer3.TabStop = false;
            this.gxPlayer3.Visible = false;
            // 
            // gxPlayer4
            // 
            this.gxPlayer4.Location = new System.Drawing.Point(765, 151);
            this.gxPlayer4.Name = "gxPlayer4";
            this.gxPlayer4.Size = new System.Drawing.Size(150, 350);
            this.gxPlayer4.TabIndex = 2;
            this.gxPlayer4.TabStop = false;
            this.gxPlayer4.Visible = false;
            // 
            // lblCurrentCard
            // 
            this.lblCurrentCard.AutoSize = true;
            this.lblCurrentCard.Location = new System.Drawing.Point(304, 261);
            this.lblCurrentCard.Name = "lblCurrentCard";
            this.lblCurrentCard.Size = new System.Drawing.Size(68, 13);
            this.lblCurrentCard.TabIndex = 4;
            this.lblCurrentCard.Text = "Current card:";
            // 
            // pbCurrentCard
            // 
            this.pbCurrentCard.Location = new System.Drawing.Point(293, 277);
            this.pbCurrentCard.Name = "pbCurrentCard";
            this.pbCurrentCard.Size = new System.Drawing.Size(102, 156);
            this.pbCurrentCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentCard.TabIndex = 3;
            this.pbCurrentCard.TabStop = false;
            // 
            // pbPile
            // 
            this.pbPile.Image = global::ConsoleApp1.Properties.Resources.blue_back;
            this.pbPile.Location = new System.Drawing.Point(555, 277);
            this.pbPile.Name = "pbPile";
            this.pbPile.Size = new System.Drawing.Size(102, 156);
            this.pbPile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPile.TabIndex = 5;
            this.pbPile.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(451, 193);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 650);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbPile);
            this.Controls.Add(this.lblCurrentCard);
            this.Controls.Add(this.pbCurrentCard);
            this.Controls.Add(this.gxPlayer4);
            this.Controls.Add(this.gxPlayer3);
            this.Controls.Add(this.gxPlayer2);
            this.Controls.Add(this.gxPlayer1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gxPlayer1;
        private System.Windows.Forms.GroupBox gxPlayer2;
        private System.Windows.Forms.GroupBox gxPlayer3;
        private System.Windows.Forms.GroupBox gxPlayer4;
        private System.Windows.Forms.PictureBox pbCurrentCard;
        private System.Windows.Forms.Label lblCurrentCard;
        private System.Windows.Forms.PictureBox pbPile;
        private System.Windows.Forms.Label lblMessage;
    }
}