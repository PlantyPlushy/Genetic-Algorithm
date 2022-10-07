using System;
using PianoSimulation;

namespace PianoSimulator
{
    /// <summary>
    /// Defines an array that wraps around itself
    /// </summary>
    public class CircularArray : IRingBuffer
    {
        private double[] _array;
        // private int _length;
        private int _frontOfArr;
        /// <summary>
        /// Circular Array constructor
        /// </summary>
        /// <param name="size">Size of array</param>
        public CircularArray(int size)
        {
            _array = new double[size];
            // _length = 0;
            _frontOfArr = 0;
        }

        public double this[int index] {
            get => _array[(_frontOfArr + index) % _array.Length];
            private set => _array[(_frontOfArr + index) % _array.Length] = value;
            }

        public int Length => _array.Length;

        public void Fill(double[] array)
        {
            //if this if statement is hit something is wrong
            if (array.Length != _array.Length)
            {
                throw new IndexOutOfRangeException("Array lengths do not match");
            }
            
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public double Shift(double value)
        {
            double removed = this[0];
            this[0] = value;
            if (_frontOfArr >= _array.Length - 1)
            {
                _frontOfArr = 0;
            } else
            {
                _frontOfArr++;
            }
            return removed;
        }
    }
}
