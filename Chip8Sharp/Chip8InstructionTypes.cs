using System;
using System.Collections.Generic;
using System.Text;

namespace Chip8Sharp
{
    public enum Chip8InstructionTypes
    {
        General = 0x0,
        Jump = 0x1,
        Call = 0x2,
        SkipEqualX = 0x3,
        SkipNotEqualX = 0x4,
        SkipEqualXY = 0x5,
        WriteToVx = 0x6,
        AddToVx = 0x7,
        ApplyVyToVx = 0x8,
        SkipNotEqualXY = 0x9,
        SetI = 0xA,
        JumpAddV0 = 0xB,
        Random = 0xC,
        Draw = 0xD,
        SkipByInput = 0xE,
        Misc = 0xF
    }

    public enum XtoYOperation
    {
        MoveYToX = 0x0,
        Or = 0x1,
        And = 0x2,
        XOR = 0x3,
        Add = 0x4,
        SubXY = 0x5,
        ShiftRight = 0x6, 
        SubYX = 0x7,
        ShiftLeft = 0xE
    }

    public enum MiscOperation
    {
        GetDelay = 0x07,
        GetKey = 0x0A,
        SetDelayTimer = 0x15,
        SetSoundTimer = 0x18,
        AddXToI = 0x1E,
        SetIToSpriteAtX = 0x29,
        StoreBinaryCodedDecimalOfXInI = 0x33,
        DumpToI = 0x55,
        LoadFromI = 0x65
    }
}
