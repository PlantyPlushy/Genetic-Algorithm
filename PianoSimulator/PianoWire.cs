using System;
using PianoSimulation;

namespace PianoSimulator
{
    public class PianoWire : IMusicalString
    {
        private CircularArray _ca;
        private double _noteFrequency;
        private int _sampleRate;
        public PianoWire(double noteFreq, int sampleR)
        {
            _noteFrequency = noteFreq;
            _sampleRate = sampleR;
            _ca = new CircularArray(Convert.ToInt32(sampleR/noteFreq));
        }

        public double NoteFrequency => _noteFrequency;

        public int NumberOfSamples => _sampleRate;
        
        public double Sample(double decay = 0.996)
        {
            return _ca.Shift(((_ca[0] + _ca[1]) / 2) * decay);
        }

        public void Strike()
        {
            double[] randomValues = new double[_ca.Length];
            Random randy = new Random();
            for (int i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randy.NextDouble() - 0.5;
            }
            _ca.Fill(randomValues);
        }
    }
}