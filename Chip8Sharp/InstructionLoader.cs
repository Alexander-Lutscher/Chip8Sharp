using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chip8Sharp
{
    public class InstructionLoader
    {
        public byte[] Load(String path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
