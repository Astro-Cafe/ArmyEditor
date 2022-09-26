using GUI_04_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_04_02.ViewModels
{
	public class TrooperEditorWindowViewModel
	{
		public Trooper Current { get; set; }

		public TrooperEditorWindowViewModel()
		{

		}
		public  void Setup(Trooper trooper)
		{
			this.Current = trooper;
		}
	}
}
