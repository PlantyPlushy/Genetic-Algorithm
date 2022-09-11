using System;
using PianoSimulator;

namespace KeyboardPiano
{
    class Program
    {
        // create user interface
        // able to read keys, esc to exit program

        static void Main(string[] args)
        {
            Piano piano = new Piano();
            Audio audio = new Audio();
            
            // while (true)
            // {
            //     Console.ReadKey().KeyChar;
            // }

            // char userKey = Console.ReadKey().KeyChar;
            // piano.StrikeKey(userKey);
            // for (int i = 0; i < 44100 * 3; i++)
            // {
            //     audio.Play(piano.Play());
            // }
            
            while (true)
            {
                char userKey = Console.ReadKey().KeyChar;
                piano.StrikeKey(userKey);
                for (int i = 0; i < 44100; i++)
                {
                    audio.Play(piano.Play());
                }
            }
        }
    }
}
