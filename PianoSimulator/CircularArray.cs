using System;
using PianoSimulation;

namespace PianoSimulator
{
    public class CircularArray : IRingBuffer
    {
        private double[] _array;
        private int _length;

        public CircularArray(int size)
        {
            _length = size;
        }

        public double this[int index] => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public void Fill(double[] array)
        {
            throw new NotImplementedException();
        }

        public double Shift(double value)
        {
            throw new NotImplementedException();
        }
    }
}
