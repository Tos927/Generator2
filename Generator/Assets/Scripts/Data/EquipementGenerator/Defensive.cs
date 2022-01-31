using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Defensive : Equipments
	{
		public int physicalArmor;
		public int magicalArmor;

		public Defensive(string _name, Stats _stats, int _damageBlock, int _levelRequiered, EquipementType _equipementType,
			int _physicalArmor, int _magicalArmor) : base(_name, _stats, _damageBlock, _levelRequiered, _equipementType)
		{
			this.physicalArmor = _physicalArmor;
			this.magicalArmor = _magicalArmor;
        }

        public override string GetDisplayStatsFromEquip(Equipments e)
        {
            string stats =

            "Level Required : " + e.levelRequiered + "\n" +
                "Damage Blocked : " + e.damageBlock + " %\n\n";

            if (e is Defensive d)
            {
                stats +=
                    "Physical Armor : " + d.physicalArmor + "\n" +
                    "Magical Armor : " + d.magicalArmor + "\n\n";
            }

            stats += GetStats(e, stats);

            return stats;
        }
    }
}
