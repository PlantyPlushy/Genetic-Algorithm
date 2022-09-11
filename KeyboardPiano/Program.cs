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
            Piano piano = new Piano("q2w3er5t6y7ui9o0p");
            Audio audio = new Audio(4096);
 
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
 
            while (true)
            {
                // Console.Write( Console.KeyAvailable);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    } 
                    char userKey = key.KeyChar;
                    piano.StrikeKey(userKey);
                }
                audio.Play(piano.Play());
            }
        }
    }
}
