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

		public Heroes(Stats stats, int _armor, int _mana, int _level, HeroClass _characterClass) : base(stats, _armor, _mana, _level)
		{
			this.characterClass = _characterClass;
		}
	}
}
