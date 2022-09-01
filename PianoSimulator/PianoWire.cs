using System;
using PianoSimulation;

namespace PianoSimulator
{
    public class PianoWire : IMusicalString
    {
        private CircularArray ca;
        private double noteFrequency;
        private int sampleRate;
        public PianoWire(double noteFreq, int sampleR)
        {
            noteFrequency = noteFreq;
            sampleRate = sampleR;
            ca = new CircularArray(Convert.ToInt32(sampleR/noteFreq));
        }

        public double NoteFrequency => noteFrequency;

        public int NumberOfSamples => sampleRate;
        
        // To optimize into a one-liner
        public double Sample(double decay = 0.996)
        {
            return ca.Shift(((ca[0] + ca[1]) / 2) * decay);
        }

        public void Strike()
        {
            double[] randomValues = new double[ca.Length];
            Random randy = new Random();
            for (int i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randy.NextDouble() - 0.5;
            }
            ca.Fill(randomValues);
        }
    }
}