using System;
using System.Collections.Generic;
using System.Text;

namespace ExoProjetGénérateur.Data
{
	public class Defensive : Equipments
	{
		protected int physicalArmor;
		protected int magicalArmor;

		public Defensive(int _physicalArmor, int _magicalArmor)
        {
			this.physicalArmor = _physicalArmor;
			this.magicalArmor = _magicalArmor;
        }
	}
}
