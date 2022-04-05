using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// Class that contains all info on the Ogre (Snorlax) class. 
    /// Contains basic attack method, Special (rest) method, and variables. 
    /// Uses physical attack, VULN magic, RESIST phys, medium HP. 
    /// </summary>
    class Ogre: EnemyCharacter
    {
        /// <summary>
        /// constructor method for Ogre class. 
        /// </summary>
        public Ogre()
        {
            name = "Snorlax";
            Strength = 10;
            Defense = 12;
            Speed = 5;
            Intelligence = 4;
            Wisdom = 4;
            MaxHP = 100;
            Hitpoints = MaxHP;
            MaxMana = 50; 
            Mana = MaxMana;
            PhysDef = 1;  //1 means RESIST. 
            MagDef = -1;  // -1 means VULN. 
            Stunned = false;
            Crit = false; 
        }

        /// <summary>
        /// physical attack method. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Attack(Character target)
        {
            Crit = false;
            int roll = Rand.Next(1, 21);
            if (roll == 20)
                Crit = true; 

            //atk determines if they hit. atk vs target.Defense
            int atk = roll + (Strength); 

            //if atk hits. 
            if (atk >= target.Defense)
            {
                int damage = Rand.Next(1, 13) + (Strength); //damage is determined by 1d12 plus STR mod. 

                //if target VULN to phys atk. 
                if (target.PhysDef == -1) 
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                //if target RESIST phys atk. 
                else if (target.PhysDef == 1)  
                {
                    target.Hitpoints -= damage / 2;
                    return damage / 2;
                }
                //normal dmg. 
                else 
                {
                    target.Hitpoints -= damage;
                    return damage;
                }
            }
            else //attack misses. 
                return 0;
        }

        /// <summary>
        /// Snorlax's special ability: Rest
        /// Snorlax rests for a turn and gains 25 to 100 HP. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Special(Character target)
        {
            //verify enough mana to cast. 
            if (Mana >= 10)
            {
                int heals = Rand.Next(25, 50);

                //verify heals doesnt go past maxHP
                if (heals > target.MaxHP - target.Hitpoints)
                    heals = (target.MaxHP - target.Hitpoints); //heals to max if triggered. 

                target.Hitpoints += heals;
                Mana -= 10;
                Stunned = true; //causes snorlax to lose 1 turn. 
                return heals;
            }
            else
                return 0; 
        }

    }
}
