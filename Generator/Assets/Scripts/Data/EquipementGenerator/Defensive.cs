using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	public class Defensive : Equipments
	{
		protected int physicalArmor;
		protected int magicalArmor;

		public Defensive(string _name, Stats _stats, int _damageBlock, int _levelRequiered, EquipementType _equipementType, int _physicalArmor, int _magicalArmor)
        {
			this.name = _name;
			this.stats = _stats;
			this.damageBlock = _damageBlock;
			this.levelRequiered = _levelRequiered;
			this.equipementType = _equipementType;

			this.physicalArmor = _physicalArmor;
			this.magicalArmor = _magicalArmor;
        }
	}
}
