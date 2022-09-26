using GUI_04_02.Models;
using System.Collections.Generic;

namespace GUI_04_02.Logic
{
	public interface IArmyLogic
	{
		int AllCost { get; }
		double AVGPower { get; }
		double AVGSpeed { get; }

		void AddToArmy(Trooper trooper);
		void RemoveFromArmy(Trooper trooper);
		void EditTrooper(Trooper trooper);
		void SetupCollections(IList<Trooper> barracks, IList<Trooper> army);
	}
}