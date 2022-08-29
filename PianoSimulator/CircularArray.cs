﻿using System;
using PianoSimulation;

namespace PianoSimulator
{
    public class CircularArray : IRingBuffer
    {
        private double[] _array;
        // private int _length;
        private int _frontOfArr;

        public CircularArray(int size)
        {
            _array = new double[size];
            // _length = 0;
            _frontOfArr = 0;
        }

        public double this[int index] => (_frontOfArr + index) % _array.Length;

        public int Length => _array.Length;

        public void Fill(double[] array)
        {
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
            throw new NotImplementedException();
        }
    }
}
