
namespace Eander17RPGProject
{
    partial class GameForm
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
            this.battleFieldPnl = new System.Windows.Forms.Panel();
            this.enemy3HPBar = new System.Windows.Forms.ProgressBar();
            this.enemy2HPBar = new System.Windows.Forms.ProgressBar();
            this.enemy1HPBar = new System.Windows.Forms.ProgressBar();
            this.player1HPBar = new System.Windows.Forms.ProgressBar();
            this.player2HPBar = new System.Windows.Forms.ProgressBar();
            this.player3HPBar = new System.Windows.Forms.ProgressBar();
            this.enemy3PB = new System.Windows.Forms.PictureBox();
            this.enemy2PB = new System.Windows.Forms.PictureBox();
            this.player3PB = new System.Windows.Forms.PictureBox();
            this.player2PB = new System.Windows.Forms.PictureBox();
            this.player1PB = new System.Windows.Forms.PictureBox();
            this.enemy1PB = new System.Windows.Forms.PictureBox();
            this.attackPnl = new System.Windows.Forms.Panel();
            this.specialBtn = new System.Windows.Forms.Button();
            this.atkBtn = new System.Windows.Forms.Button();
            this.AttackLbl = new System.Windows.Forms.Label();
            this.logPnl = new System.Windows.Forms.Panel();
            this.battleLogTB = new System.Windows.Forms.TextBox();
            this.logLbl = new System.Windows.Forms.Label();
            this.gameMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chanceyManaLbl = new System.Windows.Forms.Label();
            this.alakazamManaLbl = new System.Windows.Forms.Label();
            this.hitmonleeManaLbl = new System.Windows.Forms.Label();
            this.chanceyHPLbl = new System.Windows.Forms.Label();
            this.alakazamHPLbl = new System.Windows.Forms.Label();
            this.hitmonleeHPLbl = new System.Windows.Forms.Label();
            this.chanceyLbl = new System.Windows.Forms.Label();
            this.alakazamLbl = new System.Windows.Forms.Label();
            this.hitmonleeLbl = new System.Windows.Forms.Label();
            this.battleFieldPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1PB)).BeginInit();
            this.attackPnl.SuspendLayout();
            this.logPnl.SuspendLayout();
            this.gameMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // battleFieldPnl
            // 
            this.battleFieldPnl.BackgroundImage = global::Eander17RPGProject.Properties.Resources.Grass_1;
            this.battleFieldPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.battleFieldPnl.Controls.Add(this.enemy3HPBar);
            this.battleFieldPnl.Controls.Add(this.enemy2HPBar);
            this.battleFieldPnl.Controls.Add(this.enemy1HPBar);
            this.battleFieldPnl.Controls.Add(this.player1HPBar);
            this.battleFieldPnl.Controls.Add(this.player2HPBar);
            this.battleFieldPnl.Controls.Add(this.player3HPBar);
            this.battleFieldPnl.Controls.Add(this.enemy3PB);
            this.battleFieldPnl.Controls.Add(this.enemy2PB);
            this.battleFieldPnl.Controls.Add(this.player3PB);
            this.battleFieldPnl.Controls.Add(this.player2PB);
            this.battleFieldPnl.Controls.Add(this.player1PB);
            this.battleFieldPnl.Controls.Add(this.enemy1PB);
            this.battleFieldPnl.Location = new System.Drawing.Point(12, 47);
            this.battleFieldPnl.Name = "battleFieldPnl";
            this.battleFieldPnl.Size = new System.Drawing.Size(1099, 476);
            this.battleFieldPnl.TabIndex = 0;
            // 
            // enemy3HPBar
            // 
            this.enemy3HPBar.Location = new System.Drawing.Point(948, 192);
            this.enemy3HPBar.Name = "enemy3HPBar";
            this.enemy3HPBar.Size = new System.Drawing.Size(100, 23);
            this.enemy3HPBar.TabIndex = 1;
            this.enemy3HPBar.Value = 100;
            // 
            // enemy2HPBar
            // 
            this.enemy2HPBar.Location = new System.Drawing.Point(789, 192);
            this.enemy2HPBar.Name = "enemy2HPBar";
            this.enemy2HPBar.Size = new System.Drawing.Size(100, 23);
            this.enemy2HPBar.TabIndex = 1;
            this.enemy2HPBar.Value = 100;
            // 
            // enemy1HPBar
            // 
            this.enemy1HPBar.Location = new System.Drawing.Point(648, 188);
            this.enemy1HPBar.Name = "enemy1HPBar";
            this.enemy1HPBar.Size = new System.Drawing.Size(100, 23);
            this.enemy1HPBar.TabIndex = 1;
            this.enemy1HPBar.Value = 100;
            // 
            // player1HPBar
            // 
            this.player1HPBar.Location = new System.Drawing.Point(377, 322);
            this.player1HPBar.Name = "player1HPBar";
            this.player1HPBar.Size = new System.Drawing.Size(100, 23);
            this.player1HPBar.TabIndex = 1;
            this.player1HPBar.Value = 100;
            // 
            // player2HPBar
            // 
            this.player2HPBar.Location = new System.Drawing.Point(224, 322);
            this.player2HPBar.Name = "player2HPBar";
            this.player2HPBar.Size = new System.Drawing.Size(100, 23);
            this.player2HPBar.TabIndex = 1;
            this.player2HPBar.Value = 100;
            // 
            // player3HPBar
            // 
            this.player3HPBar.Location = new System.Drawing.Point(64, 322);
            this.player3HPBar.Name = "player3HPBar";
            this.player3HPBar.Size = new System.Drawing.Size(100, 23);
            this.player3HPBar.TabIndex = 1;
            this.player3HPBar.Value = 100;
            // 
            // enemy3PB
            // 
            this.enemy3PB.BackColor = System.Drawing.Color.Transparent;
            this.enemy3PB.Location = new System.Drawing.Point(948, 217);
            this.enemy3PB.Name = "enemy3PB";
            this.enemy3PB.Size = new System.Drawing.Size(78, 64);
            this.enemy3PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy3PB.TabIndex = 0;
            this.enemy3PB.TabStop = false;
            // 
            // enemy2PB
            // 
            this.enemy2PB.BackColor = System.Drawing.Color.Transparent;
            this.enemy2PB.Location = new System.Drawing.Point(789, 221);
            this.enemy2PB.Name = "enemy2PB";
            this.enemy2PB.Size = new System.Drawing.Size(78, 64);
            this.enemy2PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy2PB.TabIndex = 0;
            this.enemy2PB.TabStop = false;
            // 
            // player3PB
            // 
            this.player3PB.BackColor = System.Drawing.Color.Transparent;
            this.player3PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player3PB.Image = global::Eander17RPGProject.Properties.Resources.chanseyMirrored;
            this.player3PB.Location = new System.Drawing.Point(64, 365);
            this.player3PB.Name = "player3PB";
            this.player3PB.Size = new System.Drawing.Size(100, 100);
            this.player3PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player3PB.TabIndex = 0;
            this.player3PB.TabStop = false;
            // 
            // player2PB
            // 
            this.player2PB.BackColor = System.Drawing.Color.Transparent;
            this.player2PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player2PB.Image = global::Eander17RPGProject.Properties.Resources.AlakazamMirrored;
            this.player2PB.Location = new System.Drawing.Point(224, 365);
            this.player2PB.Name = "player2PB";
            this.player2PB.Size = new System.Drawing.Size(100, 100);
            this.player2PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2PB.TabIndex = 0;
            this.player2PB.TabStop = false;
            // 
            // player1PB
            // 
            this.player1PB.BackColor = System.Drawing.Color.Transparent;
            this.player1PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.player1PB.Image = global::Eander17RPGProject.Properties.Resources.hitmonleeMirrored;
            this.player1PB.Location = new System.Drawing.Point(377, 365);
            this.player1PB.Name = "player1PB";
            this.player1PB.Size = new System.Drawing.Size(100, 100);
            this.player1PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1PB.TabIndex = 0;
            this.player1PB.TabStop = false;
            // 
            // enemy1PB
            // 
            this.enemy1PB.BackColor = System.Drawing.Color.Transparent;
            this.enemy1PB.Image = global::Eander17RPGProject.Properties.Resources.magikarp;
            this.enemy1PB.Location = new System.Drawing.Point(670, 217);
            this.enemy1PB.Name = "enemy1PB";
            this.enemy1PB.Size = new System.Drawing.Size(78, 64);
            this.enemy1PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy1PB.TabIndex = 0;
            this.enemy1PB.TabStop = false;
            // 
            // attackPnl
            // 
            this.attackPnl.Controls.Add(this.specialBtn);
            this.attackPnl.Controls.Add(this.atkBtn);
            this.attackPnl.Controls.Add(this.AttackLbl);
            this.attackPnl.Location = new System.Drawing.Point(322, 529);
            this.attackPnl.Name = "attackPnl";
            this.attackPnl.Size = new System.Drawing.Size(131, 157);
            this.attackPnl.TabIndex = 1;
            // 
            // specialBtn
            // 
            this.specialBtn.Location = new System.Drawing.Point(11, 98);
            this.specialBtn.Name = "specialBtn";
            this.specialBtn.Size = new System.Drawing.Size(117, 47);
            this.specialBtn.TabIndex = 3;
            this.specialBtn.Text = "Special Attack";
            this.specialBtn.UseVisualStyleBackColor = true;
            // 
            // atkBtn
            // 
            this.atkBtn.Location = new System.Drawing.Point(11, 45);
            this.atkBtn.Name = "atkBtn";
            this.atkBtn.Size = new System.Drawing.Size(117, 47);
            this.atkBtn.TabIndex = 3;
            this.atkBtn.Text = "Basic Attack";
            this.atkBtn.UseVisualStyleBackColor = true;
            // 
            // AttackLbl
            // 
            this.AttackLbl.AutoSize = true;
            this.AttackLbl.Location = new System.Drawing.Point(47, 0);
            this.AttackLbl.Name = "AttackLbl";
            this.AttackLbl.Size = new System.Drawing.Size(48, 15);
            this.AttackLbl.TabIndex = 0;
            this.AttackLbl.Text = "Action: ";
            // 
            // logPnl
            // 
            this.logPnl.Controls.Add(this.battleLogTB);
            this.logPnl.Controls.Add(this.logLbl);
            this.logPnl.Location = new System.Drawing.Point(456, 529);
            this.logPnl.Name = "logPnl";
            this.logPnl.Size = new System.Drawing.Size(645, 157);
            this.logPnl.TabIndex = 2;
            // 
            // battleLogTB
            // 
            this.battleLogTB.BackColor = System.Drawing.SystemColors.Control;
            this.battleLogTB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.battleLogTB.Location = new System.Drawing.Point(0, 19);
            this.battleLogTB.Multiline = true;
            this.battleLogTB.Name = "battleLogTB";
            this.battleLogTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.battleLogTB.Size = new System.Drawing.Size(645, 109);
            this.battleLogTB.TabIndex = 1;
            this.battleLogTB.Text = "Battle Info Goes Here!";
            // 
            // logLbl
            // 
            this.logLbl.AutoSize = true;
            this.logLbl.Location = new System.Drawing.Point(3, 0);
            this.logLbl.Name = "logLbl";
            this.logLbl.Size = new System.Drawing.Size(60, 15);
            this.logLbl.TabIndex = 0;
            this.logLbl.Text = "Battle Log";
            // 
            // gameMenu
            // 
            this.gameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.gameMenu.Location = new System.Drawing.Point(0, 0);
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.Size = new System.Drawing.Size(1123, 24);
            this.gameMenu.TabIndex = 3;
            this.gameMenu.Text = "gameMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.restartGameToolStripMenuItem,
            this.resetStatisticsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // restartGameToolStripMenuItem
            // 
            this.restartGameToolStripMenuItem.Name = "restartGameToolStripMenuItem";
            this.restartGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restartGameToolStripMenuItem.Text = "Restart Game";
            this.restartGameToolStripMenuItem.Click += new System.EventHandler(this.RestartGameToolStripMenuItem_Click);
            // 
            // resetStatisticsToolStripMenuItem
            // 
            this.resetStatisticsToolStripMenuItem.Name = "resetStatisticsToolStripMenuItem";
            this.resetStatisticsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetStatisticsToolStripMenuItem.Text = "Reset Statistics";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chanceyManaLbl);
            this.panel1.Controls.Add(this.alakazamManaLbl);
            this.panel1.Controls.Add(this.hitmonleeManaLbl);
            this.panel1.Controls.Add(this.chanceyHPLbl);
            this.panel1.Controls.Add(this.alakazamHPLbl);
            this.panel1.Controls.Add(this.hitmonleeHPLbl);
            this.panel1.Controls.Add(this.chanceyLbl);
            this.panel1.Controls.Add(this.alakazamLbl);
            this.panel1.Controls.Add(this.hitmonleeLbl);
            this.panel1.Location = new System.Drawing.Point(12, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 157);
            this.panel1.TabIndex = 4;
            // 
            // chanceyManaLbl
            // 
            this.chanceyManaLbl.AutoSize = true;
            this.chanceyManaLbl.Location = new System.Drawing.Point(209, 130);
            this.chanceyManaLbl.Name = "chanceyManaLbl";
            this.chanceyManaLbl.Size = new System.Drawing.Size(68, 15);
            this.chanceyManaLbl.TabIndex = 9;
            this.chanceyManaLbl.Text = "PP: 100/100";
            // 
            // alakazamManaLbl
            // 
            this.alakazamManaLbl.AutoSize = true;
            this.alakazamManaLbl.Location = new System.Drawing.Point(209, 77);
            this.alakazamManaLbl.Name = "alakazamManaLbl";
            this.alakazamManaLbl.Size = new System.Drawing.Size(68, 15);
            this.alakazamManaLbl.TabIndex = 9;
            this.alakazamManaLbl.Text = "PP: 100/100";
            // 
            // hitmonleeManaLbl
            // 
            this.hitmonleeManaLbl.AutoSize = true;
            this.hitmonleeManaLbl.Location = new System.Drawing.Point(209, 18);
            this.hitmonleeManaLbl.Name = "hitmonleeManaLbl";
            this.hitmonleeManaLbl.Size = new System.Drawing.Size(68, 15);
            this.hitmonleeManaLbl.TabIndex = 9;
            this.hitmonleeManaLbl.Text = "PP: 100/100";
            // 
            // chanceyHPLbl
            // 
            this.chanceyHPLbl.AutoSize = true;
            this.chanceyHPLbl.Location = new System.Drawing.Point(107, 130);
            this.chanceyHPLbl.Name = "chanceyHPLbl";
            this.chanceyHPLbl.Size = new System.Drawing.Size(58, 15);
            this.chanceyHPLbl.TabIndex = 8;
            this.chanceyHPLbl.Text = "HP: 75/75";
            // 
            // alakazamHPLbl
            // 
            this.alakazamHPLbl.AutoSize = true;
            this.alakazamHPLbl.Location = new System.Drawing.Point(107, 77);
            this.alakazamHPLbl.Name = "alakazamHPLbl";
            this.alakazamHPLbl.Size = new System.Drawing.Size(58, 15);
            this.alakazamHPLbl.TabIndex = 7;
            this.alakazamHPLbl.Text = "HP: 50/50";
            // 
            // hitmonleeHPLbl
            // 
            this.hitmonleeHPLbl.AutoSize = true;
            this.hitmonleeHPLbl.Location = new System.Drawing.Point(107, 19);
            this.hitmonleeHPLbl.Name = "hitmonleeHPLbl";
            this.hitmonleeHPLbl.Size = new System.Drawing.Size(70, 15);
            this.hitmonleeHPLbl.TabIndex = 6;
            this.hitmonleeHPLbl.Text = "HP: 100/100";
            // 
            // chanceyLbl
            // 
            this.chanceyLbl.AutoSize = true;
            this.chanceyLbl.Location = new System.Drawing.Point(3, 130);
            this.chanceyLbl.Name = "chanceyLbl";
            this.chanceyLbl.Size = new System.Drawing.Size(53, 15);
            this.chanceyLbl.TabIndex = 5;
            this.chanceyLbl.Text = "Chancey";
            // 
            // alakazamLbl
            // 
            this.alakazamLbl.AutoSize = true;
            this.alakazamLbl.Location = new System.Drawing.Point(3, 77);
            this.alakazamLbl.Name = "alakazamLbl";
            this.alakazamLbl.Size = new System.Drawing.Size(58, 15);
            this.alakazamLbl.TabIndex = 5;
            this.alakazamLbl.Text = "Alakazam";
            // 
            // hitmonleeLbl
            // 
            this.hitmonleeLbl.AutoSize = true;
            this.hitmonleeLbl.Location = new System.Drawing.Point(3, 18);
            this.hitmonleeLbl.Name = "hitmonleeLbl";
            this.hitmonleeLbl.Size = new System.Drawing.Size(63, 15);
            this.hitmonleeLbl.TabIndex = 5;
            this.hitmonleeLbl.Text = "Hitmonlee";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 696);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logPnl);
            this.Controls.Add(this.attackPnl);
            this.Controls.Add(this.battleFieldPnl);
            this.Controls.Add(this.gameMenu);
            this.MainMenuStrip = this.gameMenu;
            this.MaximumSize = new System.Drawing.Size(1139, 735);
            this.MinimumSize = new System.Drawing.Size(1139, 735);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not Another Dungeon Crawler";
            this.battleFieldPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enemy3PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1PB)).EndInit();
            this.attackPnl.ResumeLayout(false);
            this.attackPnl.PerformLayout();
            this.logPnl.ResumeLayout(false);
            this.logPnl.PerformLayout();
            this.gameMenu.ResumeLayout(false);
            this.gameMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel battleFieldPnl;
        private System.Windows.Forms.PictureBox enemy3PB;
        private System.Windows.Forms.PictureBox enemy2PB;
        private System.Windows.Forms.PictureBox player3PB;
        private System.Windows.Forms.PictureBox player2PB;
        private System.Windows.Forms.PictureBox player1PB;
        private System.Windows.Forms.PictureBox enemy1PB;
        private System.Windows.Forms.ProgressBar enemy3HPBar;
        private System.Windows.Forms.ProgressBar enemy2HPBar;
        private System.Windows.Forms.ProgressBar enemy1HPBar;
        private System.Windows.Forms.ProgressBar player1HPBar;
        private System.Windows.Forms.ProgressBar player2HPBar;
        private System.Windows.Forms.ProgressBar player3HPBar;
        private System.Windows.Forms.Panel attackPnl;
        private System.Windows.Forms.Panel logPnl;
        private System.Windows.Forms.Button specialBtn;
        private System.Windows.Forms.Button atkBtn;
        private System.Windows.Forms.Label AttackLbl;
        private System.Windows.Forms.TextBox battleLogTB;
        private System.Windows.Forms.Label logLbl;
        private System.Windows.Forms.MenuStrip gameMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetStatisticsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label chanceyManaLbl;
        private System.Windows.Forms.Label alakazamManaLbl;
        private System.Windows.Forms.Label hitmonleeManaLbl;
        private System.Windows.Forms.Label chanceyHPLbl;
        private System.Windows.Forms.Label alakazamHPLbl;
        private System.Windows.Forms.Label hitmonleeHPLbl;
        private System.Windows.Forms.Label chanceyLbl;
        private System.Windows.Forms.Label alakazamLbl;
        private System.Windows.Forms.Label hitmonleeLbl;
    }
}

