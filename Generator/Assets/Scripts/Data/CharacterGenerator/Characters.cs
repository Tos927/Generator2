using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

namespace ExoProjetGénérateur.Data
{
	[Serializable]
	public class Characters
	{
		public string name;
		public Stats stats;
		public int life;
		public int armor;
		public int stamina;
		public int mana;
		public int level;

		public Sprite sprite;
	}
}
