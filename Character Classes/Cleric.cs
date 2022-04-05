using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// contains all information on cleric (chancey) class. 
    /// include attack, special (heal), and variables. 
    /// Wisdom based caster. 
    /// Low attack, Medium defence (both phys and magic) 
    /// </summary>
    class Cleric : PlayerCharacter
    {

        /// <summary>
        /// constructor method for Cleric class. 
        /// </summary>
        public Cleric()
        {
            name = "Chancey";
            Strength = 4;
            Defense = 12; //think armor class
            Speed = 5;
            Intelligence = 5;  
            Wisdom = 10;       //cleric casting stat. 
            MaxHP = 75;
            Hitpoints = MaxHP;  //maybe tweak later? 
            MaxMana = 100;  
            Mana = MaxMana;        
            ManaCost = 5; 
            PhysDef = 0;  
            MagDef = 0;  //0 means neither vuln nor resist. 
            Crit = false;
            Stunned = false; 
        }

        /// <summary>
        /// Cleric's attack method. 
        /// hit determined by d20 roll + strength modifier (STR/4) VS target's defense score. 
        /// damage is 1d8 + STR mod. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Attack(Character target)
        {
            Crit = false;
            int roll = Rand.Next(1, 21);
            if (roll == 20)  //checking for nat 20. 
                Crit = true; 
            int atk = roll + (Strength); //determine to hit attack. 

            //if atk hits. 
            if (atk >= target.Defense || Crit == true)
            {
                //damage is 1d8 + STR. 
                int damage = 0;

                if (Crit)
                    damage = Rand.Next(1, 9)*2 + (Strength); //Crit damage is 2d8 + STR mod. 
                else
                    damage = Rand.Next(1, 9) + (Strength);  //regular damage is 1d8 + STR mod. 

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
                //normal damage. 
                else
                {
                    target.Hitpoints -= damage;
                    return damage;
                }
            }
            else
                return 0;
        }

        /// <summary>
        /// Cleric's heal ability. Heals target for 1d12 + Wis modifier. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Special(Character target)
        {
            //verify character has enough mana to cast. 
            if (Mana >= ManaCost)
            {
                //heals is 1d12 + WIS mod. 
                int heals = Rand.Next(1, 13) + Wisdom;
                //verify heal doesn't heal past target's max HP. 
                if (heals > target.MaxHP - target.Hitpoints)
                    heals = (target.MaxHP - target.Hitpoints); //heals to max HP. 
                target.Hitpoints += heals;
                Mana -= ManaCost;
                return heals;
            }
            else
                return -1; 

        }

    }
}
