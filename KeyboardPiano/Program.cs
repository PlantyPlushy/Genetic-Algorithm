using System;
using System.Diagnostics;
using PianoSimulator;

namespace KeyboardPiano
{
    class Program
    {
        private const int BufferSize = 4096;
        private const int SampleRate = 44100;
        private const int LoopsPerSec = 50;
        private const int SamplesPerLoop = SampleRate/LoopsPerSec;
        private const int MillisecondsPerLoop = 1000 / LoopsPerSec;

        static void Main(string[] args)
        {
            Piano piano = new Piano("q2w3er5t6y7ui9o0p", SampleRate);
            Audio audio = new Audio(BufferSize, SampleRate);
            Stopwatch stopwatch = new Stopwatch();
 
            Console.Write(
                " _______________________________________ \n" +
                "|  | | | |  |  | | | | | |  |  | | | |  |\n" +
                "|  | | | |  |  | | | | | |  |  | | | |  |\n" +
                "|  |2| |3|  |  |5| |6| |7|  |  |9| |0|  |\n" +
                "|  |_| |_|  |  |_| |_| |_|  |  |_| |_|  |\n" +
                "|   |   |   |   |   |   |   |   |   |   |\n" + 
                "| q | w | e | r | t | y | u | i | o | p |\n" +
                "|___|___|___|___|___|___|___|___|___|___|\n");
            Console.WriteLine("Press any of the available keys above or ESC to exit");

            stopwatch.Start();

            while (true)
            {
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
                for (int i = 0; i < SamplesPerLoop; i++)
                {
                    audio.Play(piano.Play());
                }
                while (stopwatch.Elapsed.TotalMilliseconds < MillisecondsPerLoop)
                {
                }
                stopwatch.Restart();
            }
        }
    }
}
