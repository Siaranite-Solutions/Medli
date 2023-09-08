﻿using Makar.Ring0;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Makar
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
            OSLvl0.PrintInfo();
        }

        protected override void Run()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine(pass);


			Console.WriteLine("Divide by zero test");
			Console.ReadKey(true);
			int a = 100;
			int b = 0;
			/*
			int c = a / b;
			Console.WriteLine(a / b);
			Console.WriteLine(c);
			Console.WriteLine(100 / 4);
			*/
			try
			{
				System.IO.File.WriteAllText("blah", "blah");
			}
			catch
			{
				throw new Exception();
			}
			

		}
    }
}
