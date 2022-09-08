using System;
using System.Collections.Generic;
using PianoSimulation;

namespace PianoSimulator
{
    public class Piano : IPiano
    {
        private string _keys;
        private List<IMusicalString> _frequencyKey;
        public Piano(string keys = "q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ",  int samplingRate = 44100)
        {
            this._keys = keys;
            _frequencyKey = new List<IMusicalString>();
            for (int i = 0; i < keys.Length; i++)
            {
                // double frequency = (2 * ((i - 24) - 12)) * 440; 
                _frequencyKey.Add(new PianoWire(CalculateFrequency(i), samplingRate));
            }
        }

        public string Keys => _keys;

        public List<string> GetPianoKeys()
        {
            throw new NotImplementedException();
        }

        public double Play()
        {
            throw new NotImplementedException();
        }

        public void StrikeKey(char key)
        {
            throw new NotImplementedException();
        }

        private double CalculateFrequency(int index){
            return (2 * ((index - 24) - 12)) * 440;
        }
    }
}