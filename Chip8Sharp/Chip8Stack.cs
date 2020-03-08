using System;
using System.Collections.Generic;
using System.Text;

namespace Chip8Sharp
{
    public class Chip8Stack<T>
    {
        private readonly T[] _array;
        private short _pointer;

        public Chip8Stack(int count)
        {
            _array = new T[count];
            _pointer = 0;
        }

        public T Pop()
        {
            _pointer--;
            return _array[_pointer+1];
        }

        public void Push(T value)
        {
            _pointer++;
            _array[_pointer] = value;
        }
    }
}
