using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// class that controls game logic. 
    /// Controls the turn order, turns, NPCs, damage and attack. 
    /// creates and initializes character objects. 
    /// keeps track of current run (enemies defeated, battles cleared). 
    /// </summary>
    class Game
    {

        public event EventHandler PlayerTurn;
        public event EventHandler GameOver;
        public event EventHandler BattleWon;
        public event EnemyEventHandler EnemyTurnResult;
        public delegate void EnemyEventHandler(object sender, EnemyEventArgs e);
        static List<PlayerCharacter> players = new List<PlayerCharacter> { new Fighter(), new Mage(), new Cleric() };
         List<EnemyCharacter> enemies = new List<EnemyCharacter> { new Bandit(), new Bandit(), new Bandit() };
        public List<Character> turnOrder = new List<Character>();
        public int currentTurn = -1;
        public int currentRound = 1; 
        Random rand = new Random();

        private int mostBattlesWon = 0;
        private int totalEnemiesDefeated = 0;
        private int currentBattlesWon = 0;


        #region variable encapsulation

        public int MostBattlesWon { get => mostBattlesWon; set => mostBattlesWon = value; }
        public int TotalEnemiesDefeated { get => totalEnemiesDefeated; set => totalEnemiesDefeated = value; }
        public int CurrentBattlesWon { get => currentBattlesWon; set => currentBattlesWon = value; }

        #endregion

        /// <summary>
        /// first run to initialize actual game. 
        /// </summary>
        public void StartGame()
        {
            SpawnPlayers();
            SpawnEnemies();
            SetTurnOrder();
            InitializePlayerHP(); 
        }

        /// <summary>
        /// method that controls the game loop. determines whose turn it is, then triggers their respective turn methods. 
        /// </summary>
        public void NextTurn()
        {
            
            if (currentTurn < turnOrder.Count - 1)
            {
                currentTurn++;
            }
            else
            {
                currentTurn = 0;
            }
            if (!turnOrder[currentTurn].IsPlayerControlled)
            {
                //check if enemy is alive, then if stunned, then if confused before letting them take their turn. 
                if (turnOrder[currentTurn].IsAlive)
                {
                    if (NotStunned())
                    {
                        if (NotConfused(turnOrder[currentTurn]))
                            EnemyTurn(turnOrder[currentTurn]);
                    }
                    else
                        turnOrder[currentTurn].Stunned = false;
                }

                NextTurn();
            }
            else
            {
                if (turnOrder[currentTurn].IsAlive)
                    OnPlayerTurn();
                else
                    NextTurn();
            }
        }

        #region game setup

        /// <summary>
        /// method that sets each player's hitpoints to their hitpoint maximum. 
        /// </summary>
        private void InitializePlayerHP()
        {
            foreach(var player in players)
            {
                player.Hitpoints = player.MaxHP; 
            }
        }

        /// <summary>
        /// spawns players into game. adds them to turn order as well as determines their location. 
        /// </summary>
        private void SpawnPlayers()
        {
            for(int i = 0; i < players.Count; i++)
            {
                players[i].Location = i;
            }

            turnOrder.AddRange(players); 
        }

        /// <summary>
        /// spawns enemies into game. adds them to turn order and determines their location. 
        /// </summary>
        private void SpawnEnemies()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Location = i; 
            }
            turnOrder.AddRange(enemies); 
        }

        /// <summary>
        /// sets the turn order for characters in battle. based on DND initiative system, rolls a D20 and adds speed stat. ordered from highest to lowest. 
        /// </summary>
        private void SetTurnOrder()
        {
            foreach (var player in players)
            {
                player.Initiative = rand.Next(1, 21) + player.Speed; 
            }
            foreach(var enemy in enemies)
            {
                enemy.Initiative = rand.Next(1, 21) + enemy.Speed; 
            }
            turnOrder = turnOrder.OrderByDescending(x => x.Initiative).ToList(); 
        }

        #endregion

        #region enemy turn handling

        /// <summary>
        /// checks to see if character whose turn it is is stunned. 
        /// returns true if not stunned, false if stunned. 
        /// </summary>
        /// <returns></returns>
        private bool NotStunned()
        {
            if (turnOrder[currentTurn].Stunned) //stunned is a boolean. true if stunned, false if not stunned. 
            {
                string result = "";
                if (turnOrder[currentTurn].Name != "Snorlax")
                    result = $"{turnOrder[currentTurn].Name} is stunned and can't move!\r\n";
                else
                    result = "Snorlax is starting to wake up..."; 
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
                return false;
            }
            else
                return true; 
        }

        /// <summary>
        /// method that handles enemy confusion. 
        /// returns true if they are not confused, snap out of confusion, or stay confused but can still attack. 
        /// returns false if they hurt themselves in their confusion. 
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        private bool NotConfused(Character enemy)
        {
            //first check if they are confused. 
            if (!enemy.Confused)
                return true;
            int confusedRoll = rand.Next(1, 5); //determines how they're affected by confusion. 
            //roll of 1 means they hurt themselves. 
            if(confusedRoll == 1)
            {
                string result = $"{enemy.Name} is confused... It hurt itself in its confusion.";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
                enemy.Hitpoints -= rand.Next(1, 8);
                return false; 
            }
            //roll of 4 snaps them out of confusion. 
            else if(confusedRoll == 4)
            {
                string result = $"{enemy.Name} Snapped out of its confusion!";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
                enemy.Confused = false; 
                return true; 
            }
            //any other roll means they are still confused, but can still attack. 
            else
            {
                string result = $"{enemy.Name} is confused...";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
                return true; 
            }
 
        }

        /// <summary>
        /// game logic for enemy's turn. 
        /// determines who enemy attacks, and performs attack, then displays attack message to battle log. 
        /// finally checks to see if target was killed in attack. 
        /// </summary>
        /// <param name="enemy"></param>
        private void EnemyTurn(Character enemy)
        {
            if (turnOrder[currentTurn].Name == "Charizard")
            {
                CharizardTurn(enemy);
            }
            else if (turnOrder[currentTurn].Name == "Snorlax")
            {
                SnorlaxTurn(enemy);

            }
            else if (turnOrder[currentTurn].Name == "Magikarp")
                MagikarpTurn(enemy); 

        }

        /// <summary>
        /// game logic for Charizard's turn.
        /// </summary>
        /// <param name="charizard"></param>
        private void CharizardTurn(Character charizard)
        {
            //checks to see if Charizard's fire breath is charged and attempts to charge it if it isnt. 
            if (!charizard.FireBreath)
                charizard.FireBreath = charizard.ChargeBreathAttack(); 

            //charizard uses his special if it is charged. 
            if (charizard.FireBreath)
            {
                CharizardSpecialAttack(charizard);
            }
            else
            {
                string result = "Charizard uses a Swipe Attack!";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);

                //for loop to attack every character. 
                for (int i = 0; i < 3; i++)
                {
                    EnemyBasicAttack(charizard, i);
                }
            }
        }

        /// <summary>
        /// game logic for Snorlax's turn.
        /// </summary>
        /// <param name="snorlax"></param>
        private void SnorlaxTurn(Character snorlax)
        {
            if (snorlax.Hitpoints <= 30 && snorlax.Mana >= 10)
            {
                int heals = snorlax.Special(snorlax);

                string result = $"Snorlax uses Rest, they heal for {heals} hitpoints!";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
            }
            else
                EnemyBasicAttack(snorlax, rand.Next(0, 3)); 
        }

        /// <summary>
        /// game logic for Magikarp's turn. 
        /// </summary>
        /// <param name="magikarp"></param>
        private void MagikarpTurn(Character magikarp)
        {
            if (rand.Next(1, 5) == 4)
            {
                string result = "Magikarp uses splash... it has no effect.";
                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
            }
            else
                while(!EnemyBasicAttack(magikarp, rand.Next(0, 3))); 
        }


        /// <summary>
        /// basic attack method for enemies.
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="targetLocation"></param>
        /// <returns></returns>
        private bool EnemyBasicAttack(Character enemy, int targetLocation)
        {
            if (players[targetLocation].IsAlive)
            {
                int damage = enemy.Attack(players[targetLocation]);

                string result = "";

                //checking for a missed attack. 
                if (damage == 0)
                    result = $"{enemy.Name} attacks {players[targetLocation].Name}, but they missed!";
                else
                    result = $"{enemy.Name} attacks {players[targetLocation].Name} for {damage} damage.";

                EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                OnEnemyTurnResult(e);
                if (players[targetLocation].Hitpoints <= 0)
                    SetDead(players[targetLocation]);
                return true; 
            }
            return false; 
        }

        /// <summary>
        /// game logic for charizard's breath attack.
        /// </summary>
        /// <param name="charizard"></param>
        private void CharizardSpecialAttack(Character charizard)
        {
            bool checkAlive;
            do
            {
                int targetLocation = -1;

                targetLocation = rand.Next(0, 3);
                var target = (from player in turnOrder
                              where player.Location == targetLocation && player.IsPlayerControlled
                              select player).First();

                checkAlive = target.IsAlive;

                //checks to see if character charizard is attacking is alive. does not execute if they're already downed. 
                if (checkAlive)
                {
                    int damage = charizard.Special(players[targetLocation]);

                    string result = "";

                    //checking for missed attack. 
                    if (damage == 0)
                        result = $"Charizard uses their Breath attack on {target.Name}, but they missed!";
                    else
                        result = $"Charizard uses their Breath attack on {target.Name} for {damage} damage.";

                    EnemyEventArgs e = new EnemyEventArgs() { Message = result };
                    OnEnemyTurnResult(e);
                    if (target.Hitpoints <= 0)
                        SetDead(target);
                }
                else
                    CheckDeadTeam(); 
            } while (!checkAlive); //loops until a valid living target is found. 
        }

        #endregion

        #region defeated character methods

        /// <summary>
        /// sets deadChar isAlive value to false. 
        /// displays message to battle log,
        /// then checks to see if entire team is dead. 
        /// </summary>
        /// <param name="deadChar"></param>
        public void SetDead(Character deadChar)
        {
            deadChar.IsAlive = false;

            string result = $"{deadChar.Name} has fainted!";
            EnemyEventArgs e = new EnemyEventArgs() { Message = result };
            OnEnemyTurnResult(e);
            CheckDeadTeam(); 
        }

        /// <summary>
        /// checks both teams to determine their living status. 
        /// triggers game over conditions if either teams have no characters left. 
        /// </summary>
        private void CheckDeadTeam()
        {
            bool isAlive = false; 
            foreach(var player in players)
            {
                //isAlive is set to true if any character is alive.
                if (player.Hitpoints > 0)
                    isAlive = true; 
            }
            //if no character is alive, the game is lost and gameLost method is triggered. 
            if (!isAlive)
                GameLost();
            isAlive = false; 
            foreach(var enemy in enemies)
            {
                if (enemy.Hitpoints > 0)
                    isAlive = true; 
            }
            //if all enemies are defeated, the battle is won. 
            if (!isAlive)
                WinBattle(); 
        }

        #endregion

        #region battle handling methods

        /// <summary>
        /// displays message that user won battle, and asks if they'd like to play again. 
        /// </summary>
        private void WinBattle()
        {
            CurrentBattlesWon++; 
            string result = $"You won the battle!";
            EnemyEventArgs e = new EnemyEventArgs() { Message = result };
            OnEnemyTurnResult(e);
            OnBattleWon(); 
        }

        /// <summary>
        /// displays message that user lost, and asks if they'd like to play again. 
        /// </summary>
        private void GameLost()
        {
            if (currentBattlesWon > mostBattlesWon)
                mostBattlesWon = currentBattlesWon; 
            string result = $"You lose!";
            EnemyEventArgs e = new EnemyEventArgs() { Message = result };
            OnEnemyTurnResult(e);
            OnGameOver(); 
        }

        /// <summary>
        /// sets up next battle. creates new enemy list objects, keeps player objects intact. 
        /// First 3 rounds are pre-set, all afterwards are randomized. 
        /// </summary>
        public void NextBattle()
        {
            currentRound++; 
            enemies.Clear();

            //Snorlax round (round 2)
            if (currentRound == 2)
            {
                enemies.Add(new Ogre());
                enemies.Add(new Bandit());
                enemies.Add(new Bandit());
            }
            //Charizard round (round 3)
            else if (currentRound == 3)
            {
                enemies.Add(new Dragon());
            }
            //all rounds after round 3 are randomized. 
            else if (currentRound > 3)
                RandomBattle(); 

            turnOrder.Clear(); 
            SpawnEnemies();
            SpawnPlayers(); 
            SetTurnOrder(); 
        }

        /// <summary>
        /// method that randomly adds enemies for next battle. 
        /// </summary>
        private void RandomBattle()
        {
            for (int i = 0; i < 3; i++)
            {
                int randSelect = rand.Next(1, 21);

                if (randSelect < 10)
                    enemies.Add(new Bandit()); //adds magikarp if roll is less than 10
                else if (randSelect < 16)
                    enemies.Add(new Ogre());  //adds snorlax if rolling between 10 and 15
                else
                    enemies.Add(new Dragon()); //charizard is only added if d20 rolls a 16 or higher. 
            }
        }

        #endregion

        #region get methods

        /// <summary>
        /// returns the character associated with enemyNum parameter in turnOrder list. 
        /// </summary>
        /// <param name="enemyNum"></param>
        /// <returns></returns>
        public Character GetTarget(int enemyNum)
        {
            var target = from enemy in turnOrder
                         where !enemy.IsPlayerControlled && enemy.Location == enemyNum
                         select enemy;
           
            return target.First(); 
        }

        /// <summary>
        /// returns the player character associated with playerNum in turnOrder list. 
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public Character GetAlly(int playerNum)
        {
            var target = from ally in turnOrder
                         where ally.IsPlayerControlled && ally.Location == playerNum
                         select ally;
            return target.First(); 
        }

        /// <summary>
        /// returns the location of whoever's turn it is. 
        /// </summary>
        /// <returns></returns>
        public int GetCurrentTurnLocation()
        {
            return turnOrder[currentTurn].Location; 
        }

        #endregion

        #region event listeners

        /// <summary>
        /// event listener that is triggered on enemy turns. 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnemyTurnResult(EnemyEventArgs e)
        {
            if (EnemyTurnResult != null)
            {
                EnemyTurnResult(this, e);
            }
        }

        /// <summary>
        /// event listener that is triggered on player turn. 
        /// </summary>
        protected virtual void OnPlayerTurn()
        {
            if(PlayerTurn != null)
            {
                PlayerTurn(this, EventArgs.Empty); 
            }
        }

        /// <summary>
        /// event listener that is triggered on gameOver condition. 
        /// </summary>
        protected virtual void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// event listener that is triggered when a battle is won. 
        /// </summary>
        protected virtual void OnBattleWon()
        {
            if(BattleWon != null)
            {
                BattleWon(this, EventArgs.Empty); 
            }
        }

        #endregion
    }
}
