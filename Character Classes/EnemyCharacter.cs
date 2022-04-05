using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// Base class for all NPC classes. 
    /// derived from Character class. 
    /// </summary>
    class EnemyCharacter : Character
    {
        /// <summary>
        /// constructor method for EnemyCharacter class. 
        /// Sets IsPlayerControlled variable to false. 
        /// Sets IsAlive variable to true. 
        /// </summary>
        public EnemyCharacter()
        {
            IsPlayerControlled = false;
            IsAlive = true; 
        }

    }
}
