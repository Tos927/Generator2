using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Heroes : Characters
	{
		public HeroClass characterClass;

		public Heroes(HeroClass _characterClass, string _name, Stats stats, int _armor, int _mana, int _level)
		{
			this.characterClass = _characterClass;

			this.name = _name;
			this.stats = stats;
			this.life = stats.vitality * 100;
			this.armor = _armor;
			this.stamina = stats.stamina * 100;
			this.mana = (stats.intellect * 80) + (stats.memory * 20);
			this.level = _level;

            /*switch (_characterClass)
            {
                case HeroClass.Paladin:
					héroClass = "Paladin";
                    break;
                case HeroClass.Thief:
                    break;
                case HeroClass.Archer:
                    break;
                default:
                    break;
            }*/
        }
	}
}
