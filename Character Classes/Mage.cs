using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// class that contains all the information for the mage (alakazam) class. 
    /// contains base attack, special (psybeam), and variables. 
    /// INT based caster. 
    /// Does magic damage, VULN phys defence, RESIST magic Defence.
    /// </summary>
    class Mage : PlayerCharacter
    {

        /// <summary>
        /// constructor method for Mage class. 
        /// </summary>
        public Mage()
        {
            name = "Alakazam";
            Strength = 4;
            Defense = 12; //think armor class
            Speed = 6;    //think initiative bonus. 
            Intelligence = 10; //Mage Damage bonus 
            Wisdom = 5;
            MaxHP = 50;
            Hitpoints = MaxHP;
            MaxMana = 150; 
            Mana = MaxMana;       //spec atk? 
            ManaCost = 10; 
            PhysDef = -1;   //false == -1, means vulnerable
            MagDef = 1;     //true == 1, means resist. 
            Crit = false;
            Stunned = false; 
        }

        /// <summary>
        /// Mage's attack method. 
        /// hit determined by d20 roll + INT modifier (INT/4) VS target's defense score. 
        /// damage is 1d12 + INT mod. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Attack(Character target)
        {
            Crit = false;
            int roll = Rand.Next(1, 21);
            if (roll == 20)
                Crit = true;
            int atk = roll + (Intelligence); //determine hit to attack
            
            //if attack hits. 
            if (atk >= target.Defense || Crit == true)
            {
                int damage = 0; //damage is 1d12 + INT mod
                if (Crit)
                    damage = Rand.Next(1, 13) * 2 + (Intelligence); //crit doubles dice rolled. 
                else
                    damage = Rand.Next(1, 13) + (Intelligence); 
                     
                //if target is vulnerable to magic attack
                if (target.MagDef == -1)
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                //if target resists magic atk
                else if (target.MagDef == 1)
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
        /// Psybeam attack. High magic damage with a 1 in 4 chance to leave them confused. 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Special(Character target)
        {
            //if character has enough mana to cast. 
            if (Mana >= ManaCost)
            {
                Mana -= ManaCost;
                Crit = false;
                int roll = Rand.Next(1, 21);
                if (roll == 20)
                    Crit = true;
                int atk = roll + (Intelligence);

                //if attack hits. 
                if (atk >= target.Defense || Crit == true)
                {
                    if(Rand.Next(0,2) == 0)
                        target.Confused = true;
                    //damage is 2d8 plus INT. 
                    int damage = 0;
                    if (Crit)
                        damage = (Rand.Next(1, 9) + Rand.Next(1, 9)) * 2 + (Intelligence); //crit doubles dice rolled. 
                    else
                        damage = (Rand.Next(1, 9) + Rand.Next(1, 9)) + (Intelligence);

                    //if target VULN to magic atk. 
                    if (target.MagDef == -1)
                    {
                        target.Hitpoints -= 2 * damage;
                        return 2 * damage;
                    }
                    //if target RESIST magic atk. 
                    else if (target.MagDef == 1)
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
            else
                return 0; 
        }

    }
}
