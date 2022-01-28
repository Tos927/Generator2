using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	public class Equipments
	{
		public string name;
		protected Stats stats;
		protected int damageBlock;
		protected int levelRequiered;
		EquipementType equipementType;

		public Equipments (string _name, Stats _stats, int _damageBlock, int _levelRequiered, EquipementType _equipementType)
        {
			this.name = _name;
			this.stats = _stats;
			this.damageBlock = _damageBlock;
			this.levelRequiered = _levelRequiered;
			this.equipementType = _equipementType;
        }
	}
}
