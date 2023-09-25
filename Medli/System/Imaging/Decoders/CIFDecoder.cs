﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          CIF Decoder
* PROGRAMMERS:      Myvar
*                   https://github.com/Myvar/CosmosGuiFramework/blob/master/CosmosGuiFramework/CGF.System/Imaging/Decoders/CIFDecoder.cs
*/

using Medli.System;
using Medli.System.Framework.Core;
using Medli.System.Framework;
using Medli.System.Framework.IO;

namespace Medli.System.Imaging.Decoders
{
    public class CIFDecoder : IImageDecoder
    {
        public int[] Map { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string MagicNumber { get; set; }

        public CIFDecoder()
        {
            MagicNumber = "CIF"; //magicnumber
        }

        public void Load(byte[] raw)
        {
            Framework.IO.BinaryReader str = new Framework.IO.BinaryReader(raw);

            Width = str.GetInt32();
            Height = str.GetInt32();
            Map = new int[Width * Height];

            for (int i = 0; i < Width * Height; i++)
            {
                Map[i] = str.GetInt32();//read hex value of pixle
            }
        }

        public string ReadMagicNumber(byte[] raw)
        {
            // RWStream str = new RWStream(raw);
            return "CIF";//str.ReadString();//magicnumber
        }
    }
}
