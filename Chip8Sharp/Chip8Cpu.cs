using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Chip8Sharp
{
    public class Chip8Cpu
    {
        protected byte[] Memory = new byte[4096];
        protected byte[] ValueRegister = new byte[16];
        protected short InternalRegister = 0;
        
        protected byte DelayTimer = 0;
        protected byte SoundTimer = 0;

        private Instruction _instruction;
        protected byte StackPointer = 0;

        protected short[] Stack = new short[16];

        protected byte[,] Display = new byte[8, 32];


        public void Run(byte[] instruction)
        {
            Init(instruction);
            
            // PrintCurrentProgramToConsole();


        }


        /***
         * Can be used to Debug loader and verify that the proper program was
         * loaded and not change during runtime
         */
        private void PrintCurrentProgramToConsole()
        {
            var currentCounter = _instruction.ProgramCounter;

            while (_instruction.IsNotEmptyInstruction())
            {
                Trace.WriteLine(
                    $"0x {_instruction.CurrentInstruction.Item1:x2}" +
                              $"{_instruction.CurrentInstruction.Item2:x2}");
                _instruction.IncrementProgramCounter();
            }
        }

        private void Init(byte[] instruction)
        {
            CopyInstructionToMemory(instruction);
            _instruction = new Instruction(Memory, 0x200);
        }
        
        private void CopyInstructionToMemory(byte[] instruction)
        {
            for (var i = 0; i < instruction.Length; i++)
            {
                Memory[0x200 + i] = instruction[i];
            }
        }
    }
}
