using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Equipments
	{
		public string name;
		public Stats stats;
		public int damageBlock;
		public int levelRequiered;
		public EquipementType equipementType;
		public Sprite sprite;
	}
}
