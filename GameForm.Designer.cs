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
            this.pbCurrentCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentCard)).BeginInit();
            this.SuspendLayout();
            // 
            // gxPlayer1
            // 
            this.gxPlayer1.Location = new System.Drawing.Point(328, 403);
            this.gxPlayer1.Name = "gxPlayer1";
            this.gxPlayer1.Size = new System.Drawing.Size(148, 117);
            this.gxPlayer1.TabIndex = 0;
            this.gxPlayer1.TabStop = false;
            // 
            // gxPlayer2
            // 
            this.gxPlayer2.Location = new System.Drawing.Point(345, 12);
            this.gxPlayer2.Name = "gxPlayer2";
            this.gxPlayer2.Size = new System.Drawing.Size(148, 117);
            this.gxPlayer2.TabIndex = 1;
            this.gxPlayer2.TabStop = false;
            // 
            // gxPlayer3
            // 
            this.gxPlayer3.Location = new System.Drawing.Point(32, 215);
            this.gxPlayer3.Name = "gxPlayer3";
            this.gxPlayer3.Size = new System.Drawing.Size(148, 117);
            this.gxPlayer3.TabIndex = 2;
            this.gxPlayer3.TabStop = false;
            this.gxPlayer3.Visible = false;
            // 
            // gxPlayer4
            // 
            this.gxPlayer4.Location = new System.Drawing.Point(578, 215);
            this.gxPlayer4.Name = "gxPlayer4";
            this.gxPlayer4.Size = new System.Drawing.Size(148, 117);
            this.gxPlayer4.TabIndex = 2;
            this.gxPlayer4.TabStop = false;
            this.gxPlayer4.Visible = false;
            // 
            // pbCurrentCard
            // 
            this.pbCurrentCard.Location = new System.Drawing.Point(242, 215);
            this.pbCurrentCard.Name = "pbCurrentCard";
            this.pbCurrentCard.Size = new System.Drawing.Size(118, 156);
            this.pbCurrentCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentCard.TabIndex = 3;
            this.pbCurrentCard.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 532);
            this.Controls.Add(this.pbCurrentCard);
            this.Controls.Add(this.gxPlayer4);
            this.Controls.Add(this.gxPlayer3);
            this.Controls.Add(this.gxPlayer2);
            this.Controls.Add(this.gxPlayer1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gxPlayer1;
        private System.Windows.Forms.GroupBox gxPlayer2;
        private System.Windows.Forms.GroupBox gxPlayer3;
        private System.Windows.Forms.GroupBox gxPlayer4;
        private System.Windows.Forms.PictureBox pbCurrentCard;
    }
}