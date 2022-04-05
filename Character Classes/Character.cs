using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eander17RPGProject
{
    /// <summary>
    /// base class for all character entities including player and non player characters. 
    /// </summary>
    class Character
    {

        private Random rand = new Random();
        private int strength;
        private int defense;
        private int speed;
        private int intelligence;
        private int wisdom;
        private int hitpoints;
        private int maxMana; 
        private int mana;
        protected String name;
        protected Boolean isPlayerControlled;
        private Boolean isAlive;
        private int location;
        private int physDef;
        private int magDef;
        private int initiative;
        private int maxHP;
        private Boolean crit;
        private Boolean stunned;
        private Boolean confused; 
        private Boolean fireBreath;
        private int manaCost; 


        public int Strength { get => strength; set => strength = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Wisdom { get => wisdom; set => wisdom = value; }
        public int Hitpoints { get => hitpoints; set => hitpoints = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Location { get => location; set => location = value; }
        public string Name { get => name; set => name = value; }
        public bool IsPlayerControlled { get => isPlayerControlled; set => isPlayerControlled = value; }
        public int PhysDef { get => physDef; set => physDef = value; }
        public int MagDef { get => magDef; set => magDef = value; }
        public Random Rand { get => rand; set => rand = value; }
        public int Initiative { get => initiative; set => initiative = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public bool Crit { get => crit; set => crit = value; }
        public bool Stunned { get => stunned; set => stunned = value; }
        public bool FireBreath { get => fireBreath; set => fireBreath = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int ManaCost { get => manaCost; set => manaCost = value; }
        public bool Confused { get => confused; set => confused = value; }

        public virtual int Attack(Character target) { return -1; }

        public virtual int Special(Character target)
        {
            return -1; 
        }

        public virtual bool ChargeBreathAttack()
        {
            return false; 
        }

    }
}
