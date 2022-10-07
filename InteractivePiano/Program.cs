using System;
using InteractivePiano;
using Microsoft.Xna.Framework.Graphics;
using  PianoSimulator;

namespace InteractivePiano
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new InteractivePianoGame())
                game.Run();
        }
    }
}
