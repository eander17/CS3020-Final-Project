using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eander17RPGProject
{
    /// <summary>
    /// class that creates the visual portion of the game. 
    /// contains some logic for player inputs. 
    /// Controls file read/write. 
    /// </summary>
    public partial class GameForm : Form
    {

        static Game myGame = new Game();
        PictureBox[] playerBoxes = new PictureBox[3];
        PictureBox[] enemyBoxes = new PictureBox[3];



        static int mostBattlesWon = 0;
        static int totalEnemiesDefeated = 0; 

        /// <summary>
        /// Constructor method for GameForm class. 
        /// </summary>
        public GameForm()
        {
            ReadFile();
            InitializeComponent();
            PrepareBoard();
            InitializeGame();
            HighlightPlayerTurn();
        }


        #region GUI Methods

        /// <summary>
        /// prepares the picture boxes for the game. 
        /// </summary>
        private void PrepareBoard()
        {
            player1PB.Tag = 0;
            player2PB.Tag = 1;
            player3PB.Tag = 2;

            playerBoxes[0] = player1PB;
            playerBoxes[1] = player2PB;
            playerBoxes[2] = player3PB;

            enemy1PB.Tag = 0;
            enemy2PB.Tag = 1;
            enemy3PB.Tag = 2;

            enemyBoxes[0] = enemy1PB;
            enemyBoxes[1] = enemy2PB;
            enemyBoxes[2] = enemy3PB;
        }

        /// <summary>
        /// initializes gameboard
        /// </summary>
        private void InitializeGame()
        {
            myGame.PlayerTurn += OnPlayerTurn;
            myGame.GameOver += OnGameOver;
            myGame.BattleWon += OnBattleWon; 
            myGame.EnemyTurnResult += OnEnemyResult;
            myGame.StartGame();
            DisplayOrder();
            UpdateSprites();
            SetLifeBars();
            UpdateLifeBars();
            UpdateLabels(); 
            myGame.NextTurn();
        }

        /// <summary>
        /// writes message to battlelog displaying initiative
        /// </summary>
        private void DisplayOrder()
        {
            battleLogTB.Text = "Battle Order Set:\r\n";

            foreach (Character e in myGame.turnOrder)
            {
                battleLogTB.AppendText($"{e.Name}\r\n");
            }
        }

        /// <summary>
        /// updates sprites, changing them if necessary. 
        /// </summary>
        private void UpdateSprites()
        {
            foreach (Character e in myGame.turnOrder)
            {
                if (e.IsPlayerControlled)
                {
                    SetPlayerSprites(e);
                }
                else
                {
                    SetEnemySprites(e);
                }
            }
        }

        /// <summary>
        /// sets life bar min and max parameters for all characters. 
        /// </summary>
        private void SetLifeBars()
        {
            player1HPBar.Minimum = 0;
            player2HPBar.Minimum = 0;
            player3HPBar.Minimum = 0;

            foreach (Character e in myGame.turnOrder)
            {
                if (e.IsPlayerControlled)
                {
                    SetPlayerLifeBarMax(e);
                }
                else
                {
                    SetEnemyLifeBarMax(e);
                }
            }
        }

        /// <summary>
        /// updates the visuals of lifebars for HP gain/loss for all characters. 
        /// </summary>
        private void UpdateLifeBars()
        {
            foreach (Character e in myGame.turnOrder)
            {
                if (e.IsPlayerControlled)
                {
                    UpdatePlayerLifeBars(e);
                }
                else
                {
                    UpdateEnemyLifeBars(e);
                }
            }
        }


        /// <summary>
        /// updates the info labels for all player characters. 
        /// </summary>
        private void UpdateLabels()
        {
            foreach(Character player in myGame.turnOrder)
            {
                if(player.IsPlayerControlled)
                {
                    switch(player.Name)
                    {
                        case "Hitmonlee":
                            hitmonleeHPLbl.Text = $"HP: {player.Hitpoints}/{player.MaxHP}";
                            hitmonleeManaLbl.Text = $"PP: {player.Mana}/{player.MaxMana}"; 
                            break;
                        case "Alakazam":
                            alakazamHPLbl.Text = $"HP: {player.Hitpoints}/{player.MaxHP}";
                            alakazamManaLbl.Text = $"PP: {player.Mana}/{player.MaxMana}";
                            break;
                        case "Chancey":
                            chanceyHPLbl.Text = $"HP: {player.Hitpoints}/{player.MaxHP}";
                            chanceyManaLbl.Text = $"PP: {player.Mana}/{player.MaxMana}"; 
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// sets a yellow background on character whose turn it is. 
        /// </summary>
        private void HighlightPlayerTurn()
        {
            if (myGame.turnOrder[myGame.currentTurn].IsPlayerControlled)
            {
                playerBoxes[myGame.turnOrder[myGame.currentTurn].Location].BackColor = Color.Yellow;
            }
        }

        #endregion

        #region GUI helper methods

        /// <summary>
        /// sets the max for enemy lifebar
        /// </summary>
        /// <param name="e"></param>
        private void SetEnemyLifeBarMax(Character e)
        {
            switch (e.Location)
            {
                case 0:
                    enemy1HPBar.Maximum = e.MaxHP;
                    break;
                case 1:
                    enemy2HPBar.Maximum = e.MaxHP;
                    break;
                case 2:
                    enemy3HPBar.Maximum = e.MaxHP;
                    break;
            }
        }

        /// <summary>
        /// sets max for player lifebars. 
        /// </summary>
        /// <param name="e"></param>
        private void SetPlayerLifeBarMax(Character e)
        {
            switch (e.Location)
            {
                case 0:
                    player1HPBar.Maximum = e.MaxHP;
                    break;
                case 1:
                    player2HPBar.Maximum = e.MaxHP;
                    break;
                case 2:
                    player3HPBar.Maximum = e.MaxHP;
                    break;
            }
        }

        /// <summary>
        /// changes enemies life bar reflected by change in hitpoints. 
        /// </summary>
        /// <param name="e"></param>
        private void UpdateEnemyLifeBars(Character e)
        {
            if (e.Hitpoints > 0)
            {
                switch (e.Location)
                {
                    case 0:
                        enemy1HPBar.Value = e.Hitpoints;
                        enemy1HPBar.Visible = true; 
                        break;
                    case 1:
                        enemy2HPBar.Value = e.Hitpoints;
                        enemy2HPBar.Visible = true; 
                        break;
                    case 2:
                        enemy3HPBar.Value = e.Hitpoints;
                        enemy3HPBar.Visible = true; 
                        break;
                }
            }
            else
            {
                 
                switch (e.Location)
                {
                    case 0:
                        enemy1HPBar.Visible = false;
                        enemyBoxes[0].Visible = false; 
                        break;
                    case 1:
                        enemy2HPBar.Visible = false;
                        enemyBoxes[1].Visible = false; 
                        break;
                    case 2:
                        enemy3HPBar.Visible = false;
                        enemyBoxes[2].Visible = false; 
                        break;
                }
            }
        }

        /// <summary>
        /// updates player life bar reflected by change in hitpoints. 
        /// </summary>
        /// <param name="e"></param>
        private void UpdatePlayerLifeBars(Character e)
        {
            if (e.Hitpoints > 0)
            {
                switch (e.Location)
                {
                    case 0:
                        player1HPBar.Value = e.Hitpoints;
                        break;
                    case 1:
                        player2HPBar.Value = e.Hitpoints;
                        break;
                    case 2:
                        player3HPBar.Value = e.Hitpoints;
                        break;
                }
            }
            else
            {
                 
                switch (e.Location)
                {
                    case 0:
                        player1HPBar.Visible = false;
                        playerBoxes[0].Visible = false; 
                        break;
                    case 1:
                        player2HPBar.Visible = false;
                        playerBoxes[1].Visible = false; 
                        break;
                    case 2:
                        player3HPBar.Visible = false;
                        playerBoxes[2].Visible = false; 
                        break;
                }
            }
        }

        /// <summary>
        /// displays correct sprite for each enemy location. dependent upon enemyCharacter class' name. 
        /// </summary>
        /// <param name="e"></param>
        private void SetEnemySprites(Character e)
        {
            switch (e.Name)
            {
                case "Magikarp":
                    enemyBoxes[e.Location].Image = Properties.Resources.magikarp;
                    enemyBoxes[e.Location].BackColor = Color.Transparent;
                    enemyBoxes[e.Location].Visible = true; 
                    break;
                case "Snorlax":
                    enemyBoxes[e.Location].Image = Properties.Resources.snorlax;
                    enemyBoxes[e.Location].BackColor = Color.Transparent;
                    enemyBoxes[e.Location].SizeMode = PictureBoxSizeMode.StretchImage;
                    enemyBoxes[e.Location].Visible = true; 
                    break;
                case "Charizard":
                    enemyBoxes[e.Location].Image = Properties.Resources.charizard;
                    enemyBoxes[e.Location].BackColor = Color.Transparent;
                    enemyBoxes[e.Location].SizeMode = PictureBoxSizeMode.StretchImage;
                    enemyBoxes[e.Location].Visible = true;
                    break;
            }
        }

        /// <summary>
        /// sets sprites for each hero. Dependent upon class' name. 
        /// </summary>
        /// <param name="e"></param>
        private void SetPlayerSprites(Character e)
        {
            switch (e.Name)
            {
                case "Hitmonlee":
                    playerBoxes[e.Location].Image = Properties.Resources.hitmonleeMirrored;
                    break;
                case "Chancey":
                    playerBoxes[e.Location].Image = Properties.Resources.chanseyMirrored;
                    break;
                case "Alakazam":
                    playerBoxes[e.Location].Image = Properties.Resources.AlakazamMirrored;
                    break;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// starts player's turn. subscribes attack button click, updates life bars, signals whose turn it is and highlights them. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPlayerTurn(object sender, EventArgs e)
        {
            EnableAttackBtns();
            UpdateLifeBars();
            UpdateLabels(); 
            foreach (PictureBox p in playerBoxes)
            {
                p.BackColor = Color.Transparent;
            }
            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name}'s turn\r\n");
            HighlightPlayerTurn();
        }


        /// <summary>
        /// triggered when game is over. prompts user to play again and restarts game on yes and ends application on no. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnGameOver(object sender, EventArgs e)
        {
            if(MessageBox.Show("Play again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateFileVariables(); 
                WriteFile(); 
                RestartGame();    
            }
            else
            {
                WriteFile(); 
                Application.Exit(); 
            }
        }

        /// <summary>
        /// triggered when player wins a battle. displays message telling them they won the battle then sets up next battle. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBattleWon(object sender, EventArgs e)
        {
            MessageBox.Show("You won the battle!");
            myGame.NextBattle();
            ResetScreen(); 
        }


        /// <summary>
        /// triggered when the attack button is clicked. perform's player attack logic and displays messages to battlelog. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAttackButtonClick(object sender, EventArgs e)
        {
            DisableAttackBtns();
            playerBoxes[myGame.GetCurrentTurnLocation()].BackColor = Color.Transparent;
            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name} chose to attack!\r\n");

            foreach (var pb in enemyBoxes)
            {
                if (pb.Visible == true) //only changes back color if they're alive. 
                {
                    pb.BackColor = Color.Red;
                    pb.Click += OnEnemyClick;
                }
            }
        }


        /// <summary>
        /// triggered when the special attack button is clicked. Perform's player's special attack logic. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSpecialButtonClick(object sender, EventArgs e)
        {
            DisableAttackBtns(); 
            playerBoxes[myGame.GetCurrentTurnLocation()].BackColor = Color.Transparent;
            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name} chose to use their special!\r\n"); 

            if(myGame.turnOrder[myGame.currentTurn].Name == "Chancey")
            {
                foreach(var pb in playerBoxes)
                {
                    if(pb.Visible == true)
                    {
                        pb.BackColor = Color.Green;
                        pb.Click += OnChanceySpecial;
                    }
                }
            }
            else
            {
                foreach(var pb in enemyBoxes)
                {
                    if(pb.Visible == true)
                    {
                        pb.BackColor = Color.Red;
                        pb.Click += OnSpecialAttack; 
                    }
                }
            }
        }

        /// <summary>
        /// handles Cleric healing. triggered when player selects ally to heal. 
        /// triggers Chancey's heal ability and displays message to battlelog. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanceySpecial(object sender, EventArgs e)
        {
            int targetNum = int.Parse(((PictureBox)sender).Tag.ToString());

            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name} heals " +
                                   $"{myGame.GetAlly(targetNum).Name} for " +
                                   $"{myGame.turnOrder[myGame.currentTurn].Special(myGame.GetAlly(targetNum))} Hitpoints.\r\n");
            UpdateLifeBars();
            UpdateLabels(); 
            
            foreach(var pb in playerBoxes)
            {
                pb.BackColor = Color.Transparent;
                pb.Click -= OnChanceySpecial; 
            }

            myGame.NextTurn(); 
        }

        /// <summary>
        /// triggered when player selects enemy to Special attack. Triggers player's special attack ability and displays special attack message to battlelog. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSpecialAttack(object sender, EventArgs e)
        {
            int targetNum = int.Parse(((PictureBox)sender).Tag.ToString());

            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name} special attacks {myGame.GetTarget(targetNum).Name}");
            int damage = myGame.turnOrder[myGame.currentTurn].Special(myGame.GetTarget(targetNum));
            if (damage == 0)
                battleLogTB.AppendText(", but they missed!\r\n");
            else
                battleLogTB.AppendText($" for {damage} damage.\r\n"); 


            UpdateLifeBars();
            UpdateLabels(); 
            if (myGame.GetTarget(targetNum).Hitpoints <= 0)
            {
                myGame.SetDead(myGame.GetTarget(targetNum));
                myGame.TotalEnemiesDefeated++;
            }
                 

            foreach(var pb in enemyBoxes)
            {
                pb.BackColor = Color.Transparent;
                pb.Click -= OnSpecialAttack; 
            }

            myGame.NextTurn(); 
        }

        /// <summary>
        /// triggered when player selects enemy to attack. triggers player's attack ability and displays attack message to battlelog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnemyClick(object sender, EventArgs e)
        {
            int targetNum = int.Parse(((PictureBox)sender).Tag.ToString());            

            battleLogTB.AppendText($"{myGame.turnOrder[myGame.currentTurn].Name} attacks {myGame.GetTarget(targetNum).Name}");

            int damage = myGame.turnOrder[myGame.currentTurn].Attack(myGame.GetTarget(targetNum));

            //check for critical hit. 
            if (myGame.GetTarget(targetNum).Crit)
                battleLogTB.AppendText($"\r\nCRITICAL HIT!\r\n{myGame.turnOrder[myGame.currentTurn].Name} deals {damage} damage!\r\n"); 
            //check for missed attack. 
            else if (damage == 0)
                battleLogTB.AppendText(", but they missed!\r\n");
            //displays basic attack damage. 
            else
                battleLogTB.AppendText($" for {damage} damage.\r\n"); 

            UpdateLifeBars();
            UpdateLabels();
            Thread.Sleep(1500);
            //check to see if attack defeated enemy. 
            if (myGame.GetTarget(targetNum).Hitpoints <= 0)
            {
                myGame.SetDead(myGame.GetTarget(targetNum));
                myGame.TotalEnemiesDefeated++; 
            }
                 
            //resets enemyBoxes backcolor to transparent. 
            foreach(var pb in enemyBoxes)
            {
                pb.BackColor = Color.Transparent;
                pb.Click -= OnEnemyClick; 
            }
            myGame.NextTurn(); 
        }

        /// <summary>
        /// event listener, displays a message sent from Game.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnEnemyResult(object sender, EnemyEventArgs e)
        {
            battleLogTB.AppendText(e.Message + "\r\n");
            Thread.Sleep(1500); 
        }


        #endregion

        #region Event Helpers

        private void RestartGame()
        {
            UpdateFileVariables(); 
            WriteFile();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            this.Close();
        }

        /// <summary>
        /// resets all sprites and lifebar visibility and updates their totals. 
        /// </summary>
        private void ResetScreen()
        {
            UpdateSprites();
            SetLifeBars();
            UpdateLifeBars();
            UpdateLabels(); 
        }


        /// <summary>
        /// enables all button clicks and buttons for player attacks. 
        /// </summary>
        private void EnableAttackBtns()
        {
            atkBtn.Click += OnAttackButtonClick;
            atkBtn.Enabled = true;
            if (myGame.turnOrder[myGame.currentTurn].Mana >= myGame.turnOrder[myGame.currentTurn].ManaCost)
            {
                specialBtn.Click += OnSpecialButtonClick;
                specialBtn.Enabled = true;
            }
        }

        /// <summary>
        /// disables all button clicks and buttons for player attacks. 
        /// </summary>
        private void DisableAttackBtns()
        {
            atkBtn.Click -= OnAttackButtonClick;
            atkBtn.Enabled = false;
            specialBtn.Click -= OnSpecialButtonClick;
            specialBtn.Enabled = false;
        }
        #endregion

        #region Menu buttons

        /// <summary>
        /// triggered when user clicks quit button on menu strip. 
        /// Exits application. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteFile(); 
            Application.Exit(); 
        }

        /// <summary>
        /// triggered when user clicks restart game button on menu strip. 
        /// Restarts the game. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteFile(); 
            RestartGame(); 
        }

        /// <summary>
        /// triggered when user clicks statistics button on menu strip. 
        /// displays a text box showing game stats. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFileVariables();
            //strings will contain the words written on messageBox. 
            string message = $"Most Battles Won: {mostBattlesWon} \nTotal Enemies Defeated: {totalEnemiesDefeated}";
            string title = "Statistics";
            MessageBox.Show(message, title); //simple message box to display statistics. 
        }

        #endregion

        #region save File Stuff

        /// <summary>
        /// method that opens file and reads the contents, saving them to respective variables. 
        /// </summary>
        public static void ReadFile()
        {
            //create file if there is none, does not alter text if file already exists. 
            StreamWriter w = File.AppendText("UserSave.txt");
            w.Close(); //closes streamwriter. 
            StreamReader reader = new StreamReader("UserSave.txt");

            try
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(','); //separates values between commas. 
                    mostBattlesWon = int.Parse(data[0]);
                    totalEnemiesDefeated = int.Parse(data[1]);
                }
                reader.Close(); //closes streamreader. 
            }
            catch (Exception e) //just in case something breaks. 
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// method that writes to file. Overwrites what was previously written. 
        /// </summary>
        public static void WriteFile()
        { 
            StreamWriter writer = new StreamWriter("UserSave.txt"); //create streamwriter variable to write into UserSave text file. 
            writer.Write($"{mostBattlesWon},{totalEnemiesDefeated}"); //writes variables into text file. 
            writer.Close(); //closes streamwriter. 
        }

        /// <summary>
        /// resets text file as well as all statistics variables. 
        /// </summary>
        private void ResetFile()
        {
            File.WriteAllText("UserSave.txt", string.Empty);
            mostBattlesWon = 0;
            totalEnemiesDefeated = 0;
        }

        /// <summary>
        /// sets the file variables in GameForm class equal to the variables of the same name in the Game class. 
        /// </summary>
        private void UpdateFileVariables()
        {
            if(mostBattlesWon < myGame.CurrentBattlesWon)
                mostBattlesWon= myGame.CurrentBattlesWon;
            totalEnemiesDefeated += myGame.TotalEnemiesDefeated; 
        }
        #endregion
    }
}
