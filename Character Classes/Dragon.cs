using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// class that contains all info on Dragon (charizard) class. 
    /// contains attack (tail swipe), special (firebreath), and fireBreath recharge method. 
    /// HIGH STR and INT, RESIST phys atk, RESIST magic atk, High HP, Low speed. 
    /// </summary>
    class Dragon: EnemyCharacter
    {
        
        /// <summary>
        /// constructor method for Dragon (charizard) class. 
        /// </summary>
        public Dragon()
        {
            name = "Charizard";
            Strength = 12;
            Defense = 14;
            Speed = 2;
            Intelligence = 12;
            Wisdom = 0;
            MaxHP = 150;
            Hitpoints = MaxHP;            
            Mana = 0;
            PhysDef = 1;  // 1 means RESIST. 
            MagDef = 1;
            Stunned = false;
            FireBreath = true; //boolean var that determines whether charizard CAN use fireBreath attack. 
            Crit = false; 
        }


        /// <summary>
        /// Dragon Fire Breath Attack.  
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override int Special(Character target)
        {
            int atk = Rand.Next(1, 21) + (Intelligence); //atk variable determines whether the attack can hit against target's defense. 

            //if atk hits. 
            if (atk >= target.Defense)
            {
                int damage = 0; //damage determined by 4d6 + INT mod. 
                
                for (int i = 0; i < 4; i++)
                {
                    damage += Rand.Next(1, 7); 
                }
                
                damage += (Intelligence); 

                //if target VULN to magic damage. 
                if (target.MagDef == -1) 
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                //if target RESIST magic damage. 
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
            //attack missed. 
            else 
                return 0;
            

        }

        /// <summary>
        /// dragon swipe attack. 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="roll"></param>
        /// <returns></returns>
        public override int Attack(Character target)
        {
            int roll = Rand.Next(1, 21); 

            if (roll == 20)
                Crit = true;
            else
                Crit = false; 
            
            int atk = roll + (Strength);

            //if attack hits. 
            if (atk >= target.Defense || Crit == true)
            {
                int damage = 0;  //damage is 2d8 + STR mod. 
                if (Crit)
                    damage = (Rand.Next(1, 9) + Rand.Next(1, 9)) * 2 + (Strength); //crit is double dice rolled. 
                else
                    damage = (Rand.Next(1, 9) + Rand.Next(1, 9)) + (Strength);

                //if target VULN phys attack. 
                if (target.PhysDef == -1)
                {
                    target.Hitpoints -= 2 * damage;
                    return damage * 2;
                }
                // if target RESIST phys attack. 
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
            //attack missed. 
            else
                return 0;

        }

        /// <summary>
        /// Charizard can only charge his breath attack if he rolls a 5 or 6 on a d6. 
        /// </summary>
        public override bool ChargeBreathAttack()
        {
            if (Rand.Next(1, 7) >= 5)
                return true;
            else
                return false;
        }
    }
}
