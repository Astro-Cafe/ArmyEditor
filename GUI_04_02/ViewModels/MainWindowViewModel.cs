using GUI_04_02.Logic;
using GUI_04_02.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_04_02.ViewModels
{
	public class MainWindowViewModel : ObservableRecipient
	{
		IArmyLogic logic;
		public ObservableCollection<Trooper> Barrack { get; set; }
		public ObservableCollection<Trooper> Army { get; set; }

		private Trooper selectedFromBarracks;

		public Trooper SelectedFromBarracks
		{
			get { return selectedFromBarracks; }
			set 
			{ 
				SetProperty(ref selectedFromBarracks, value);
				(AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
				(EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

		private Trooper selectedFromArmy;

		public Trooper SelectedFromArmy
		{
			get { return selectedFromArmy; }
			set 
			{
				SetProperty(ref selectedFromArmy, value);
				(RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
			}
		}

		public ICommand AddToArmyCommand { get; set; }
		public ICommand RemoveFromArmyCommand { get; set; }
		public ICommand EditTrooperCommand { get; set; }

		public int AllCost
		{
			get
			{
				return logic.AllCost;
			}
		}
		public double AVGPower
		{
			get
			{
				return logic.AVGPower;
			}
		}
		public double AVGSpeed
		{
			get
			{
				return logic.AVGSpeed;
			}
		}

		public static bool IsInDesignMode
		{
			get
			{
				var prop = DesignerProperties.IsInDesignModeProperty;
				return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
			}
		}
		public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>()) //Todo hidden dependency resolve
		{

		}
		public MainWindowViewModel(IArmyLogic logic)
		{
			this.logic = logic;
			Barrack = new ObservableCollection<Trooper>();
			Army = new ObservableCollection<Trooper>();

			Barrack.Add(new Trooper()
			{
				Type ="Officer",
				Power = 8,
				Speed = 4
			});
			Barrack.Add(new Trooper()
			{
				Type = "AT soldier",
				Power = 8,
				Speed = 3
			});
			Barrack.Add(new Trooper()
			{
				Type = "Marksman",
				Power = 10,
				Speed = 1
			});
			Barrack.Add(new Trooper()
			{
				Type = "Medic",
				Power = 6,
				Speed = 7
			});
			Barrack.Add(new Trooper()
			{
				Type = "Engineer",
				Power = 8,
				Speed = 1
			});

			Army.Add(Barrack[2].GetCopy());
			Army.Add(Barrack[4].GetCopy());

			logic.SetupCollections(Barrack, Army);

			AddToArmyCommand = new RelayCommand(
				()=> logic.AddToArmy(SelectedFromBarracks),
				()=> SelectedFromBarracks != null
				);

			RemoveFromArmyCommand = new RelayCommand(
				() => logic.RemoveFromArmy(SelectedFromArmy),
				() => selectedFromArmy != null
				);

			EditTrooperCommand = new RelayCommand(
				() => logic.EditTrooper(SelectedFromBarracks),
				() => SelectedFromBarracks != null
				);

			Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recepient, msg) =>
			{
				OnPropertyChanged("AllCost");
				OnPropertyChanged("AVGSpeed");
				OnPropertyChanged("AVGPower");
			});
		}
	}
}
