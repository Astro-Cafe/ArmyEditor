using GUI_04_02.Models;
using GUI_04_02.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_04_02.Logic
{
	public class ArmyLogic : IArmyLogic
	{
		IList<Trooper> Barracks;
		IList<Trooper> Army;
		IMessenger messenger;
		ITrooperEditorService editorservice;
		public ArmyLogic(IMessenger messenger, ITrooperEditorService editorservice)
		{
			this.messenger = messenger;
			this.editorservice = editorservice;
		}

		public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
		{
			Barracks = barracks;
			Army = army;
		}

		public void AddToArmy(Trooper trooper)
		{
			Army.Add(trooper.GetCopy());
			messenger.Send("Trooper added", "TrooperInfo");
		}
		public void RemoveFromArmy(Trooper trooper)
		{
			Army.Remove(trooper);
			messenger.Send("Trooper removed", "TrooperInfo");
		}

		public void EditTrooper(Trooper trooper)
		{
			editorservice.Edit(trooper);
		}

		public int AllCost
		{
			get
			{
				return Army.Count == 0 ? 0 : Army.Sum(t => t.Cost);
			}
		}
		public double AVGPower
		{
			get
			{
				return Math.Round(Army.Count == 0 ? 0 : Army.Average(t => t.Power),2);
			}
		}

		public double AVGSpeed
		{
			get	
			{
				return Math.Round(Army.Count == 0 ? 0 : Army.Average(t => t.Speed),2);
			}
		}
	}
}
