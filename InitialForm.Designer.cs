namespace ConsoleApp1 {
    partial class InitialForm {
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.lblNumOfPlayers = new System.Windows.Forms.Label();
            this.nudNumOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnPlay = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnHowToPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Enter your name:";
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(118, 24);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(151, 20);
            this.txtbxName.TabIndex = 1;
            // 
            // lblNumOfPlayers
            // 
            this.lblNumOfPlayers.AutoSize = true;
            this.lblNumOfPlayers.Location = new System.Drawing.Point(18, 62);
            this.lblNumOfPlayers.Name = "lblNumOfPlayers";
            this.lblNumOfPlayers.Size = new System.Drawing.Size(94, 13);
            this.lblNumOfPlayers.TabIndex = 2;
            this.lblNumOfPlayers.Text = "Amount of players:";
            // 
            // nudNumOfPlayers
            // 
            this.nudNumOfPlayers.Location = new System.Drawing.Point(118, 60);
            this.nudNumOfPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudNumOfPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumOfPlayers.Name = "nudNumOfPlayers";
            this.nudNumOfPlayers.ReadOnly = true;
            this.nudNumOfPlayers.Size = new System.Drawing.Size(38, 20);
            this.nudNumOfPlayers.TabIndex = 3;
            this.nudNumOfPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(27, 108);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Location = new System.Drawing.Point(158, 107);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(78, 23);
            this.btnHowToPlay.TabIndex = 5;
            this.btnHowToPlay.Text = "How To Play";
            this.btnHowToPlay.UseVisualStyleBackColor = true;
            this.btnHowToPlay.Click += new System.EventHandler(this.BtnHowToPlay_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 144);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.nudNumOfPlayers);
            this.Controls.Add(this.lblNumOfPlayers);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.lblName);
            this.Name = "InitialForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.InitialForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label lblNumOfPlayers;
        private System.Windows.Forms.NumericUpDown nudNumOfPlayers;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnHowToPlay;
    }
}