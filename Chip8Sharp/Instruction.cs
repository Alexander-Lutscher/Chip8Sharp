using System;

namespace Chip8Sharp
{
    public class Instruction
    {
        public static short one = 1;
        private readonly byte[] _memory;
        public short ProgramCounter { get; private set; }
        private readonly short _maxProgramSize;

        public (byte, byte) CurrentInstruction => (_memory[ProgramCounter], _memory[ProgramCounter + 1]);


        public Instruction(byte[] memory, short counter, short maxProgramSize = 0xFFF)
        {
            _memory = memory;
            _maxProgramSize = maxProgramSize;

            MoveToInstruction(counter);
        }

        public void MoveToInstruction(short newCounter)
        {
            if (newCounter > _maxProgramSize)
                throw new IndexOutOfRangeException(
                    $"Invalid program counter:{newCounter} max counter position: {_maxProgramSize}");

            if (newCounter < 0x200)
            {
                throw new IndexOutOfRangeException($"program counter must be bigger than {0x200}");
            }

            ProgramCounter = newCounter;
        }

        public bool IsNotEmptyInstruction()
        {
            return (CurrentInstruction.Item1 != 0 || CurrentInstruction.Item2 != 0);
        }
        


        public void IncrementProgramCounter()
        {
            MoveToInstruction((short)(ProgramCounter + 2));
        }

        public void DecrementProgramCounter()
        {
            MoveToInstruction((short)(ProgramCounter - 2));
        }


    }
}