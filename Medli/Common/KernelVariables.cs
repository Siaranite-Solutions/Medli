﻿using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli
{
    public partial class Kernel
    {
		public static string KernelVersion = "0.3.3";
		public static bool IsLive;
		public static bool Running;
		public static string Hostname;

		public static string logo = $@"
   __    _                             
   /|   / |            |  |  o   
  / |  /  |  ___    ___|  |  |   
 /  | /   | |___|  |   |  |  |    
/   |/    | |___   |___|  |_ |    
                                            
The C# free and open source Operating System
";
		public static string welcome = $@"
Welcome to Medli version: { KernelVersion }
Developed by Siaranite Solutions & Arawn Davies
Copyright (C) Siaranite Solutions, Arawn Davies 2021, All Rights Reserved
Released under the BSD-3 Clause Clear licence
";

		public static string licence = @"
The Clear BSD License

Copyright (C) 2021 Siaranite Solutions, Arawn Davies
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, 
are permitted (subject to the limitations in the disclaimer below) provided that 
the following conditions are met:

* Redistributions of source code must retain the above copyright notice, 
  this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice, 
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.
* Neither the name of [Owner Organization] nor the names of its contributors 
  may be used to endorse or promote products derived from this software without 
  specific prior written permission.
NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY THIS LICENSE. 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS"" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.";


        /// <summary>
        /// See 'Installer.username' - same string and value
        /// - Redefined for global usage in Medli
        /// </summary>
        public static string username;

        /// <summary>
        /// Defines where the PC information is stored as a file
        /// with it's location stored as a string
        /// </summary>
        public static string pcinfo = Common.Paths.System + MEnvironment.dir_ext + "pcinfo.sys";

        /// <summary>
        /// Defines where the user information is stored as a file,
        /// with it's location stored as a string
        /// </summary>
        public static string usrinfo = Common.Paths.System + MEnvironment.dir_ext + "usrinfo.sys";

        /// <summary>
        /// See 'Installer.MInit' for first declaration, shares the same value
        /// - Redefined for global usage in Medli
        /// </summary>
        public static string pcname;

    }
}
