/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medli.Core.Framework.IO;

namespace Medli.System.Framework.IO
{
    public class BinaryWriter
    {
        public Stream BaseStream;
        public BinaryWriter(Stream stream)
        {
            BaseStream = stream;
        }
        public void Write(byte dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(short dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(int dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(long dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(ushort dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(uint dat)
        {
            Medli.Core.Framework.IO.BinaryWriter.Write(dat);
        }
        public void Write(ulong dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public void Write(bool dat)
        {
            if (dat)
                Write((byte)1);
            else
                Write((byte)0);
        }
        public void Write(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public void Write(string dat)
        {
            Write((ushort)dat.Length);
            foreach (byte b in dat)
            {
                Write(b);
            }
        }
    }
}
