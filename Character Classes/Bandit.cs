using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// Class that contains all info on Bandit (magikarp) class. 
    /// Contains basic attack and variables. 
    /// Does not have a casting ability. 
    /// Weak attack, VULN phys atk, VULN magic atk, no magic, higher speed.
    /// </summary>
    class Bandit : EnemyCharacter
    {
        /// <summary>
        ///  Constructor method for Bandit class. 
        /// </summary>
        public Bandit()
        {
            name = "Magikarp";
            Strength = 4;
            Defense = 8;
            Speed = 12;
            Intelligence = 0;
            Wisdom = 0;
            MaxHP = 50;
            Hitpoints = MaxHP;
            MaxMana = 0; 
            Mana = MaxMana;
            PhysDef = -1;  //-1 means VULN. 
            MagDef = -1;
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
            int atk = Rand.Next(1, 21) + (Strength); //atk variable determines whether the attack can hit against target's defense. 

            //if atk hits. 
            if (atk >= target.Defense)
            {
                int damage = Rand.Next(1, 9) + (Strength); //damage is 1d8 plus STR mod. 

                //if target VULN phys dmg. 
                if (target.PhysDef == -1)  
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                //if target RESIST phys dmg. 
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

    }
}
