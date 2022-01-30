using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Enemy : Characters
	{
		public EnemyClass enemyClass;

		public Enemy(EnemyClass _enemyClass, string _name, Stats stats, int _armor, int _mana, int _level)
		{
			this.enemyClass = _enemyClass;

			this.name = _name;
			this.stats = stats;
			this.life = stats.vitality * 100;
			this.armor = _armor;
			this.stamina = stats.stamina * 100;
			this.mana = (stats.intellect * 80) + (stats.memory * 20);
			this.level = _level;
		}
	}
}
