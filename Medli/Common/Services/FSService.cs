﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;
using System.IO;
using Medli.System;

namespace Medli.Common.Services
{
	public class FSService
	{
        private static string driveID = @"0:\";

        public static CosmosVFS vFS;

		public static string ServiceName = "FSSRV";

		public static AccessPriority Priority = AccessPriority.MID;

		public static bool Active = false;

		public static bool CheckVolumes()
		{
			var volumes = vFS.GetVolumes();
			foreach (var vol in volumes)
			{
				return true;
			}
			return false;
		}

		public static string ServicePath;

		public static LoggingService ServiceLogger;

        public static void Format()
        {
            if (Active == true)
            {
                var mydrive = new DiskManager(driveID);
                mydrive.Format("FAT32", false);
            }
        }

        public static void ChangeDriveLabel()
        {
            if (Active == true)
            {
                var mydrive = new DiskManager(driveID);
                mydrive.ChangeDriveLetter(@"1:\");
            }
        }

        /// <summary>
        /// Initialise the filesystem service
        /// </summary>
        /// <returns></returns>
        public static bool Init()
		{
            if (Kernel.IsLive == true)
            {
                Active = false;
                return false;
            }
            vFS = new CosmosVFS();
			Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(vFS);
			if (CheckVolumes() == false) {
				Console.WriteLine("Running Medli in Live User mode.");
				Console.WriteLine("FS operations are disabled!");
				Kernel.IsLive = true;
				Active = false;
				return false;
			}
			else
			{
				if ((File.Exists(Paths.System + @"live.user")) || Kernel.IsLive == true)
                {
					Console.WriteLine("OS in recovery mode! Live User mode enabled...");
					Kernel.IsLive = true;
					Paths.CurrentDirectory = "LIVE";
					Active = false;
					return false;
				}
				else
				{
					/*
					int i = 0;
					for (i = 0; i < Paths.OSDirectories.Length; i++)
					{
						if (!Directory.Exists(Paths.OSDirectories[i]))
						{
							AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Paths.OSDirectories[i] + "...");
							System.FS.Makedir(Paths.OSDirectories[i], true);
						}
					}*/
					Paths.CreateDirectories();
                    ServiceLogger = new LoggingService(Paths.SystemLogs + @"\fs.log");
					ServiceLogger.Record("FS Service logger initialized.");
                    var mydrive = new DiskManager(driveID);
                    ServiceLogger.Record("Filesystem service running on " + mydrive.Name);
					Kernel.IsLive = false;
					Level3.ReadHostname();
                    Directory.SetCurrentDirectory(Paths.Root);
                    Paths.CurrentDirectory = Paths.Root;
					Active = true;
					return true;
				}
			}
		}
	}
}
