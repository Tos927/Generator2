using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	public class Offensive : Equipments
	{
		protected int attackPoint;
		protected int criticalChance;
		protected int criticalDamage;
		protected Range range;

		public Offensive(int _attackPoint, int _criticalChance, int _criticalDamage, Range _range)
        {
			this.attackPoint = _attackPoint;
			this.criticalChance = _criticalChance;
			this.criticalDamage = _criticalDamage;
			this.range = _range;
        }
	}
}
