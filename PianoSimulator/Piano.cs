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
                Console.WriteLine(CalculateFrequency(i));
                _frequencyKey.Add(new PianoWire(CalculateFrequency(i), samplingRate));
            }
        }

        public string Keys => _keys;

        public List<string> GetPianoKeys()
        {
            List<string> strList = new List<string>();
            int i = 0;
                foreach (var k in _frequencyKey)
                {
                    strList.Add("Key " + _keys[i] + " is: " + k.NoteFrequency);
                    i++;
                }
            return strList;
        }

        public double Play()
        {
            double sum = 0;
            foreach (var i in _frequencyKey)
            {
                sum += i.Sample();
            }
            return sum;
        }

        public void StrikeKey(char key)
        {
            try
            {
                int indexOf = _keys.IndexOf(key);
                _frequencyKey[indexOf].Strike();
            }
            catch (Exception)
            {
                
            }
            
        }

        private double CalculateFrequency(int index){
            // return (2 * ((index - 24) / 12.0)) * 440;
            return Math.Pow(2,(index - 24) / 12.0) * 440;
        }
    }
}