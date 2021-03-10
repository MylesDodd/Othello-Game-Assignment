
namespace Othello_Game_Assignment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.player0ScoreLabel = new System.Windows.Forms.Label();
            this.player1ScoreLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newGameToolStripMenuItem.Image")));
            this.newGameToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // startNewGame
            // 
            this.startNewGame.Location = new System.Drawing.Point(12, 27);
            this.startNewGame.Name = "startNewGame";
            this.startNewGame.Size = new System.Drawing.Size(75, 23);
            this.startNewGame.TabIndex = 1;
            this.startNewGame.Text = "New Game";
            this.startNewGame.UseVisualStyleBackColor = true;
            this.startNewGame.Click += new System.EventHandler(this.startNewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player 2";
            // 
            // player1TextBox
            // 
            this.player1TextBox.Location = new System.Drawing.Point(164, 404);
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(100, 23);
            this.player1TextBox.TabIndex = 4;
            this.player1TextBox.TextChanged += new System.EventHandler(this.player1TextBox_TextChanged);
            // 
            // player2TextBox
            // 
            this.player2TextBox.Location = new System.Drawing.Point(533, 399);
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(100, 23);
            this.player2TextBox.TabIndex = 5;
            // 
            // player0ScoreLabel
            // 
            this.player0ScoreLabel.AutoSize = true;
            this.player0ScoreLabel.Location = new System.Drawing.Point(77, 407);
            this.player0ScoreLabel.Name = "player0ScoreLabel";
            this.player0ScoreLabel.Size = new System.Drawing.Size(27, 15);
            this.player0ScoreLabel.TabIndex = 6;
            this.player0ScoreLabel.Text = "egg";
            // 
            // player1ScoreLabel
            // 
            this.player1ScoreLabel.AutoSize = true;
            this.player1ScoreLabel.Location = new System.Drawing.Point(435, 404);
            this.player1ScoreLabel.Name = "player1ScoreLabel";
            this.player1ScoreLabel.Size = new System.Drawing.Size(38, 15);
            this.player1ScoreLabel.TabIndex = 7;
            this.player1ScoreLabel.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.player1ScoreLabel);
            this.Controls.Add(this.player0ScoreLabel);
            this.Controls.Add(this.player2TextBox);
            this.Controls.Add(this.player1TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startNewGame);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button startNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox player1TextBox;
        private System.Windows.Forms.TextBox player2TextBox;   
        private System.Windows.Forms.Label player1ScoreLabel;
        private System.Windows.Forms.Label player0ScoreLabel;
    }
}

