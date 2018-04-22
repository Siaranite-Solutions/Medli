﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	class Multiscreen : Command
	{
		public override string Name
		{
			get
			{
				return "screen";
			}
		}

		public override string Summary
		{
			get
			{
				return "Switches the current terminal to a new multiscreen terminal";
			}
		}

		public void Switch(int screen)
		{
			if (screen != System.CoreInfo.CurrentScreen)
			{
				System.CoreInfo.ChangeScreen(screen);
			}
			else
			{

			}
		}

		public override void Execute(string param)
		{
			if (param == "get")
			{
				Console.WriteLine(System.CoreInfo.CurrentScreen);
			}
			else
			{
				try
				{
					int screen = Int32.Parse(param);
					Switch(screen);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Invalid option!");
				}

			}
		}
		public override void Help()
		{
			Console.WriteLine("screen [option]");
			Console.WriteLine(Summary);
			Console.WriteLine("[get] returns the current screen");
			Console.WriteLine("[number from 1-4] switches to the specified screen");
		}
	}
}