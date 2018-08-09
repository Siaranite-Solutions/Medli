﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Medli.Common;
using Medli.System;
using Medli.Apps;

namespace Medli
{
    public class Shell
    {
        public static void Prompt(string cmdline)
        {
            // String variables of the parameters for shell loop:
            var command = cmdline.ToLower();
            var cmdCI = cmdline;
            // String arrays from the splitting of the shell loop parameter:
            string[] cmdCI_args = cmdCI.Split(' ');
            string[] cmd_args = command.Split(' ');

            if (command == "cls")
            {
                Console.Clear();
            }
            else if (command == "newshell")
            {
                Console.Clear();
                CommandConsole newConsole = new CommandConsole();
                newConsole.Initialize();
            }
            else if (command.StartsWith("echo $"))
            {
                //Console.WriteLine(usr_vars.Retrieve(cmdCI.Remove(0, 6)));
            }
            else if (cmdline.StartsWith("echo "))
            {
                //Applications.echo.Main(args);
                Console.WriteLine(cmdCI_args[1]);
            }
            else if (command == "test_serial")
            {
                //Hardware.HAL.COM2.WriteLine("Hello, World!");
            }
            else if (command == "panic")
            {
                int a = 10;
                int b = 0;
                Console.WriteLine((a / b).ToString());
            }
            else if (command == "help help")
            {
                //Applications.help.RunHelp();
            }
            else if (command == "shutdown")
            {
                //usr_vars.SaveVars();
                Sys.Power.Shutdown();
            }
            else if (command == "cpu_flags")
            {
                //CPUInfo.ListFlags();
            }
            else if (command == "cpu_info")
            {
                //CPUInfo.LSCPU();
            }
            else if (command == "reboot")
            {
                //usr_vars.SaveVars();
                Sys.Power.Reboot();
            }
            else if (command == "meminfo")
            {
                SystemFunctions.PrintTotalRAM();
            }
            else if (command == "licence")
            {
                Console.WriteLine("");
            }
            else if (command == "time")
            {
                Time.printTime();
            }
            else if (command == "date")
            {
                Time.printDate();
            }
            else if (command == "host")
            {
                Console.WriteLine(Kernel.Host);
            }
            else if (command == "lspci")
            {
                SystemFunctions.lspci();
            }
            else if (command == "cd ..")
            {
                FS.CDP();
            }
            else if (command.StartsWith("cd "))
            {
                FS.cd(cmdCI.Remove(0, 3));
            }
            else if (command == "dir")
            {
                FS.Dir();
            }
            else if (command.StartsWith("dir "))
            {
                FS.Dir(cmdCI_args[1]);
            }
            else if (command.StartsWith("copy "))
            {
                if (File.Exists(cmdCI_args[1]))
                {
                    File.Copy(Paths.CurrentDirectory + cmdCI_args[1], cmdCI_args[2]);
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
            else if (command == "list_vols")
            {
                FS.ListVols();
            }
            else if (command == "list_vol")
            {
                FS.ListVol();
            }
            else if (command.StartsWith("mv"))
            {
                FS.mv(Paths.CurrentDirectory + cmdCI_args[1], cmdCI_args[2]);
            }
            else if (command.StartsWith("rm "))
            {
                if (cmd_args[1] == "-r")
                {
                    FS.del(cmdCI.Remove(0, 6), true);
                }
                else
                {
                    FS.del(cmdCI.Remove(0, 3), false);
                }
            }
            else if (command == "ram_info")
            {
                SystemFunctions.PrintInfo();
            }
            else if (command == "ram_used")
            {
                SystemFunctions.PrintUsedRAM();
            }
            else if (command == "ram_free")
            {
                SystemFunctions.PrintFreeRAM();
            }
            else if (command == "ram_total")
            {
                SystemFunctions.PrintTotalRAM();
            }
            else if (command.StartsWith("mkdir"))
            {
                FS.Makedir(Directory.GetCurrentDirectory() + cmdCI_args[1]);
            }
            else if (command == "")
            {

            }
            else
            {
                Console.WriteLine("Invalid command: " + cmdCI);
            }
        }
    }
}
			/*
			else if (command == "tui")
			{
				TUI.TUI.Run();
				Console.Clear();
				Console.WriteLine("TUI Session closed. Press any key to continue...");
				Console.ReadKey(true);
			}
			else if (command == "cowsay")
			{
				Apps.Cowsay.Cow("Say something using 'Cowsay <message>'");
				Console.WriteLine(@"You can also use 'cowsay -f' tux for penguin, cow for cow and 
sodomized-sheep for, you guessed it, a sodomized-sheep");
			}
			else if (command.StartsWith("cowsay"))
			{
				Apps.Cowsay.Run(cmdCI_args);
			}
			else if (command == "print vars")
			{

			}
			else if (command == "umc")
			{
				Internals.UserManagementConsole.Run();
			}
			else if (command.StartsWith("$"))
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.Store(cmdCI_args[0].Remove(0, 1), cmdCI_args[1]);
			}
			else if (command.StartsWith("run "))
			{
				if (!File.Exists(KernelVariables.currentdir + cmdCI_args[1]))
				{
					Console.WriteLine("File doesn't exist!");
				}
				else
				{
					Apps.ApolloScript.Run(KernelVariables.currentdir + cmdCI_args[1]);
				}
			}
			else if (command.StartsWith("edit "))
			{
				Apps.TextEditor.Run(cmdCI_args[1]);
			}
			else if (command == "edit")
			{
				Console.WriteLine("Usage: edit <filename>");
				Console.WriteLine("Launches the text editor using the filename specified");
			}
			
			else if (command.StartsWith("cv "))
			{
				Apps.TextViewer.Run(cmdCI_args[1]);
			}
			else if (command == "miv")
			{
				Apps.MIV.Run();
			}
			else if (command.StartsWith("miv "))
			{
				Apps.MIV.Run(cmdCI.Remove(0, 4));
			}
			else if (command == "help")
			{
				Apps.Help.Run();
			}
			else if (command == "savevars")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.SaveVars();
			}
			else if (command == "loadvars")
			{
				//Console.WriteLine("Dictionaries not yet implemented!");
				usr_vars.ReadVars();
			}
			else if (command.StartsWith("help "))
			{
				Apps.Help.Specific(cmd_args[1]);
			}
			else if (command == "pause")
			{
				Environment_variables.PressAnyKey();
			}

			*/