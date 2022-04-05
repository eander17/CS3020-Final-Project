using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// base class for player character classes. 
    /// Derived from Character class. 
    /// </summary>
    class PlayerCharacter : Character
    {
        /// <summary>
        /// Constructor method for PlayerCharacter Class. 
        /// sets IsPlayerControlled variable to true. 
        /// sets IsAlive variable to true. 
        /// </summary>
        public PlayerCharacter()
        {
            IsPlayerControlled = true;
            IsAlive = true; 
        }

    }
}
