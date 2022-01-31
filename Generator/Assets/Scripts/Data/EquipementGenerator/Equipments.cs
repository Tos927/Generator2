using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Equipments
	{
		public string name;
		public Stats stats;
		public int damageBlock;
		public int levelRequiered;
		public EquipementType equipementType;
		public Sprite sprite;

		public Equipments(string _name, Stats _stats, int _damageBlock, int _levelRequiered, EquipementType _equipementType)
		{
			this.name = _name;
			this.stats = _stats;
			this.damageBlock = _damageBlock;
			this.levelRequiered = _levelRequiered;
			this.equipementType = _equipementType;
		}

        public virtual string GetDisplayStatsFromEquip(Equipments e)
        {
            string stats =

                "Level Required : " + e.levelRequiered + "\n" +
                "Damage Blocked : " + e.damageBlock + " %\n\n";

            if (e is Offensive o)
            {
                stats +=
                    "Attack Point : " + o.attackPoint + "\n" +
                    "Criticale Damage : " + o.criticalDamage + "\n" +
                    "Criticale Chance : " + o.criticalChance + "\n\n";
            }
            else if (e is Defensive d)
            {
                stats +=
                    "Physical Armor : " + d.physicalArmor + "\n" +
                    "Magical Armor : " + d.magicalArmor + "\n\n";
            }

            stats += GetStats(e, stats);

            return stats;
        }

        protected string GetStats(Equipments e, string stats)
        {
            foreach (var field in typeof(Stats).GetFields(BindingFlags.Instance |
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Public))
            {
                object t = field.GetValue(e.stats);
                switch (t)
                {
                    case 0:
                        break;
                    default:
                        stats +=
                            field.Name + " : " + t + "\n";
                        break;
                }
            }

            return stats;
        }
    }
}
