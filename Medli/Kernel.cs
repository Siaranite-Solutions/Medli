﻿using Medli.System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.Common.Drivers;
using IL2CPU.API.Attribs;
using System.Drawing;

namespace Medli
{
    public static partial class Kernel
    {

        [ManifestResourceStream(ResourceName = "Medli.Logo.bmp")]
        public static byte[] logoImage;

        /// <summary>
        /// List of kernel services (filesystem, logging etc.)
        /// </summary>
		public static List<Daemon> Daemons = new List<Daemon>();

        /// <summary>
        /// 
        /// </summary>
        public static List<Driver> Drivers = new List<Driver>();

        /// <summary>
        /// Custom console implementation object
        /// </summary>
        //public static System.Framework.AConsole AConsole;

        /// <summary>
        /// 
        /// </summary>
        public static string Consolemode = "VGATextmode";

        /// <summary>
        /// Bitmap Logo
        /// </summary>
        public static Sys.Graphics.Bitmap BitmapLogo;

        /// <summary>
        /// 
        /// </summary>
        public static void DrawLogo()
        {
            Sys.Graphics.Bitmap bitmap = new Sys.Graphics.Bitmap(logoImage);
			//DrawImage(0, 0, 90, 37, bitmap);
        }
    }
}
