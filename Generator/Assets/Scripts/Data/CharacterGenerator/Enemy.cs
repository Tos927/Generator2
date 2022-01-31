using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Enemy : Characters
	{
		public EnemyClass enemyClass;

		public Enemy(Stats stats, int _armor, int _mana, int _level, EnemyClass _enemyClass) : base(stats, _armor, _mana, _level)
		{
			this.enemyClass = _enemyClass;
		}
	}
}
