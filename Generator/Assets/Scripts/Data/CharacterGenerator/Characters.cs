using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public abstract class Characters
	{
		public string name;
		public Stats stats;
		public int life;
		public int armor;
		public int stamina;
		public int mana;
		public int level;

		public Sprite sprite;

		/*public Characters(HeroClass _characterClass, string _name, Stats stats, int _armor, int _mana, int _level)
		{
			this.characterClass = _characterClass;

			this.name = _name;
			this.stats = stats;
			this.life = stats.vitality * 100;
			this.armor = _armor;
			this.stamina = stats.stamina * 100;
			this.mana = (stats.intellect * 80) + (stats.memory * 20);
			this.level = _level;
		}*/
	}
}
