﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL;
using Cosmos.HAL.BlockDevice;

namespace Medli.Hardware
{
    class AddDisks
    {
        private static Core.MemoryStream a = new(1024);
		//private static Core.MemoryStream a = new Core.MemoryStream(1024);
		/*
		 * instead of fully naming type as RandomClass.RandomMethod example = new SpecificClass.CustomObject(1337);
		 *						 we now do RandomClass.RandomMethod example = new(1337);
		 *
		 */
		private static char b = 'a';

		public static void Detect()
		{
			int num = 1;
			for (int index = 0; index < BlockDevice.Devices.Count; ++index)
			{
				if (BlockDevice.Devices[index] is ATA_PIO)
				{
					ATA_PIO device = (ATA_PIO)BlockDevice.Devices[index];
                    if (device.DriveType == ATA_PIO.SpecLevel.ATA)
                    {
                        device.ReadBlock(0UL, 2U, ref a.Data);
                        Devices.dev.Add(new Devices.device()
                        {
                            name = "/dev/sd" + b.ToString(),
                            dev = (BlockDevice)device
                        });
                        ++b;
                    }

				}
				else if (BlockDevice.Devices[index] is Partition)
				{
					Partition device1 = BlockDevice.Devices[index] as Partition;
					Devices.device device2 = new Devices.device();
					device2.name = "/dev/sda" + num.ToString();
					device2.dev = (BlockDevice)device1;
					++num;
					Devices.dev.Add(device2);
				}
			}
		}
	}
}
