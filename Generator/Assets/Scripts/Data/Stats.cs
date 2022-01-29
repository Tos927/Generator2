using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
    [Serializable]
    public struct Stats
    {
        public int vitality;
        public int memory;
        public int stamina;
        public int strength;
        public int dexterity;
        public int agility;
        public int intellect;
        public int faith;
        public int luck;

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