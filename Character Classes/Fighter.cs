using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// Class that contains all details for fighter (hitmonlee) 
    /// include attack, special attack, and variables. 
    /// STR based caster. 
    /// strong physical power, RESIST phys atk, low magic power, VULN magic atk, Average speed. 
    /// </summary>
    class Fighter : PlayerCharacter
    {
        /// <summary>
        /// constructor method for Fighter class. 
        /// </summary>
        public Fighter()
        {
            name = "Hitmonlee";
            Strength = 10;
            Defense = 16; //think armor class
            Speed = 8;     
            Intelligence = 5; //no relevance to fighter.  
            Wisdom = 5;       //same. 
            MaxHP = 100;
            Hitpoints = MaxHP;  
            MaxMana = 100; 
            Mana = MaxMana;       //spec atk? 
            ManaCost = 10; 
            PhysDef = 1;  //True (1) means resistant 
            MagDef = -1;  //False (-1) means vulnerable
            Crit = false;
            Stunned = false; 
        }

        /// <summary>
        /// fighter's attack method. 
        /// hit determined by d20 roll + strength modifier (STR/4) VS target's defense score. 
        /// damage is 1d12 + STR mod. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Attack(Character target)
        {
            Crit = false; 
            int roll = Rand.Next(1, 21);
            if (roll == 20)
                Crit = true; 
            int atk = roll + (Strength); //determine to hit attack. 

            //check for hit/crit. 
            if (atk >= target.Defense || Crit == true) 
            {
                int damage = 0;  //damage is 1d12 + STR mod. 
                if (Crit)
                    damage = Rand.Next(1, 13) * 2 + (Strength); //dice rolled doubled if crit. 
                else
                    damage = Rand.Next(1, 13) + (Strength); 

                //if target is weak to physical attack. 
                if (target.PhysDef == -1)
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                //if target is resistant to physical attack. 
                else if (target.PhysDef == 1)
                {
                    target.Hitpoints -= damage / 2;
                    return damage / 2;
                }
                //standard damage. 
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
        /// Fighter special attack. Less damaging strike that Stuns target.
        /// Stunned enemy loses 1 turn. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Special(Character target)
        {
            //check character have available mana. 
            if (Mana >= ManaCost)
            {
                Mana -= ManaCost; //decrement mana by mana cost. 
                Crit = false;

                int roll = Rand.Next(1, 21);
                if (roll == 20)
                    Crit = true;
                int atk = roll + (Strength); //determine to hit attack. 

                //if attack hits past targets AC (armor class)
                if (atk >= target.Defense || Crit == true)
                {
                    target.Stunned = true;
                    int damage = 0;  //damage is 1d6 + STR mod. 
                    if (Crit)
                        damage = Rand.Next(1, 7) * 2 + (Strength);
                    else
                        damage = Rand.Next(1, 7) + (Strength);

                    //if target is vulnerable to Phys atk. 
                    if (target.PhysDef == -1)
                    {
                        target.Hitpoints -= 2 * damage;
                        return damage * 2;
                    }
                    //if target resists phys atk. 
                    else if (target.PhysDef == 1)
                    {
                        target.Hitpoints -= damage / 2;
                        return damage / 2;
                    }
                    //standard damage. 
                    else
                    {
                        target.Hitpoints -= damage;
                        return damage;
                    }
                }
                else
                    return 0;
            }
            else
                return 0; 
        }

    }
}
