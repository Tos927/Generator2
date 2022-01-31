using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Offensive : Equipments
	{
		public int attackPoint;
		public int criticalChance;
		public int criticalDamage;
		public Range range;

		public Offensive(string _name, Stats _stats, int _damageBlock, int _levelRequiered, 
			EquipementType _equipementType, int _attackPoint, int _criticalChance, 
			int _criticalDamage, Range _range) : base(_name, _stats, _damageBlock, _levelRequiered, _equipementType)
        {
			this.attackPoint = _attackPoint;
			this.criticalChance = _criticalChance;
			this.criticalDamage = _criticalDamage;
			this.range = _range;
        }

        public override string GetDisplayStatsFromEquip(Equipments e)
        {
            string stats = 

            "Level Required : " + e.levelRequiered + "\n" +
                "Damage Blocked : " + e.damageBlock + " %\n\n";

                if (e is Offensive o)
            {
                stats +=
                    "Attack Point : " + o.attackPoint + "\n" +
                    "Criticale Damage : " + o.criticalDamage + "\n" +
                    "Criticale Chance : " + o.criticalChance + "\n\n"; ;
            }


            stats += GetStats(e, stats);

            return stats;
        }
    }
}
