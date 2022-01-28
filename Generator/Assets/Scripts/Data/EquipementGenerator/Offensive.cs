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

		/*public int attackPointGet
        {
            get { return attackPoint; }
        }*/

		public Offensive(string _name, Stats _stats, int _damageBlock, int _levelRequiered, EquipementType _equipementType, int _attackPoint, int _criticalChance, int _criticalDamage, Range _range)
        {
			this.name = _name;
			this.stats = _stats;
			this.damageBlock = _damageBlock;
			this.levelRequiered = _levelRequiered;
			this.equipementType = _equipementType;

			this.attackPoint = _attackPoint;
			this.criticalChance = _criticalChance;
			this.criticalDamage = _criticalDamage;
			this.range = _range;
        }
	}
}
