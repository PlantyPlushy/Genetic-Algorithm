using System;
using InteractivePiano;
using  PianoSimulator;

namespace InteractivePiano
{
    public static class Program
    {
        private const int BufferSize = 4096;
        private const int SampleRate = 44100;
        private const int LoopsPerSec = 50;
        private const int SamplesPerLoop = SampleRate/LoopsPerSec;
        private const int MillisecondsPerLoop = 1000 / LoopsPerSec;
        [STAThread]
        static void Main()
        {

            using (var game = new InteractivePianoGame())
                game.Run();
            Piano piano = new Piano(samplingRate: SampleRate);
            Audio audio = new Audio(BufferSize, SampleRate);
            while (true)
            {
                //Detects if a key is hit or not
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    } 
                    char userKey = key.KeyChar;
                    piano.StrikeKey(userKey);
                }
                //Plays the audio 
                for (int i = 0; i < SamplesPerLoop; i++)
                {
                    audio.Play(piano.Play());
                }
            }
            
            
        }
    }
}
