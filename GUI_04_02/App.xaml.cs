﻿using GUI_04_02.Logic;
using GUI_04_02.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_04_02
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Ioc.Default.ConfigureServices(
				new ServiceCollection()
				.AddSingleton<IArmyLogic, ArmyLogic>()
				.AddSingleton<ITrooperEditorService,TrooperEditorViaWindow>()
				.AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
				.BuildServiceProvider()

				);
		}
	}
}
