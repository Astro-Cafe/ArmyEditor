using GUI_04_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_04_02.Services
{
	public class TrooperEditorViaWindow : ITrooperEditorService
	{
		public void Edit(Trooper trooper)
		{
			// ablak fel

			new TrooperEditorWindow(trooper).ShowDialog();
		}
	}
}
