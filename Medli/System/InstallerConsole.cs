﻿using System;
using System.Collections.Generic;
using System.Text;
using Medli.System.Framework;

namespace Medli.System
{
    public partial class Installer
    {

        /// <summary>
        /// Initializes the Medli installer console screen by 
        /// setting the default colour, the title and cursor position
        ///         
        ///         ////////////////////////////////////////////////////////////////////////////////
        ///         ---Menu bar---
        /// </summary>
        /// <param name="is_login">if set to <c>true</c> [is login].</param>
        public static void ScreenSetup(bool is_setup = false, bool is_login = false, bool is_welcome = false)
        {
            Console.BackgroundColor = DefaultColour;
            Console.Clear();
            //TODO
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            if (is_setup == true)
            {
                Console.WriteLine("                                   Medli Setup                                  ");
            }
            else if (is_login == true)
            {
                Console.WriteLine("                                   Medli Login                                  ");
            }
			else if (is_welcome == true)
			{
				Console.WriteLine("                                Welcome to Medli                                ");
			}
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = 7;
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Custom Write method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
        }

		/// <summary>
		/// Custom Write method for the installer console, sets the cursor position
		/// </summary>
		/// <param name="text"></param>
		public static void Write(char c)
		{
			Console.CursorLeft = 7;
			Console.Write(c);
		}

		/// <summary>
		/// Prints the suffix.
		/// </summary>
		/// <param name="text">The text.</param>
		public static void WriteSuffix(string text)
        {
            Console.Write(text + "\n");
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Prints the prefix.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void WritePrefix(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
        }

        /// <summary>
        /// Custom WriteLine method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLine(string text)
        {
            Write("\n");
            Console.CursorLeft = 7;
            Console.Write(text + "\n");
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Console.ReadLine method with indent of 7, used by the installer
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
			Console.CursorLeft = 7;
			//Console.CursorTop += 1;
			var text = string.Empty;
			ConsoleKey key;
			do
			{
				var keyInfo = Console.ReadKey(intercept: true);
				key = keyInfo.Key;

				if (key == ConsoleKey.Backspace && text.Length > 0)
				{
					text = text[0..^1];
				}
				else if (!char.IsControl(keyInfo.KeyChar))
				{
					Write(keyInfo.KeyChar);
					text += keyInfo.KeyChar;
				}
			} while (key != ConsoleKey.Enter);

			Console.CursorLeft = 7;
			text = text + "";
            return text;
        }

		public static string ReadPasswd()
		{
			Console.CursorLeft = 17;
			//Console.CursorTop += 1;
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

			Console.CursorLeft = 7;
			pass = pass + "";
			return pass;

		}

        /// <summary>
        /// Redirect method of PressAnyKey, indented by 7
        /// </summary>
        /// <param name="text"></param>
        public static void PressAnyKey(string text = "Press any key to continue...")
        {
            Console.CursorLeft = 7;
            WriteLine(text);
            Console.ReadKey(true);
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// The default colour for the installation console
        /// </summary>
        private static ConsoleColor DefaultColour = ConsoleColor.Blue;

    }
}
