﻿using System;

namespace Backend
{
    /// <summary>
    /// This is used to determine the pattern of keys 
    /// so that sprites on the piano can be rendered 
    /// correctly regardless of how many keys are available
    /// </summary>
    public class DetermineKey
    {
        const string BasePattern = "wbwwbwbwwbwb";
        string _pattern;
        private readonly int _stringLength;
        public DetermineKey(int stringLength){
            this._stringLength = stringLength;
            GeneratePattern();
        }

        private void GeneratePattern(){
            int maxFit = _stringLength / BasePattern.Length;
            int remainder = _stringLength % BasePattern.Length;
            // uses the base pattern and multiplies it
            for (int i = 0; i < _stringLength; i++)
            {
                _pattern += BasePattern[i % BasePattern.Length];
            }

        }

        public bool IsWhite(int index){
            return _pattern[index] == 'w';
        }

        public int StringLength => _stringLength;

        public string Pattern { get => _pattern; private set => _pattern = value; }
    }
}