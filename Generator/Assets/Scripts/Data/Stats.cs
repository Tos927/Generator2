using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
    public struct Stats
    {
        private int vitality;
        private int memory;
        private int stamina;
        private int strength;
        private int dexterity;
        private int agility;
        private int intellect;
        private int faith;
        private int luck;

        public Stats(int _vitality, int _memory, int _stamina, int _strength,
            int _dexterity, int _agility, int _intellect, int _faith, int _luck)
        {
            this.vitality = _vitality;
            this.memory = _memory;
            this.stamina = _stamina;
            this.strength = _strength;
            this.dexterity = _dexterity;
            this.agility = _agility;
            this.intellect = _intellect;
            this.faith = _faith;
            this.luck = _luck;
        }
    }
}