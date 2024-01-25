using System;
using System.Threading.Tasks;

namespace MyNamespace;

public static class Utilities
{
    public static async Task ShowConsoleAnimation()
    {
        string[] animations = ["| -", "/ \\", "- |", "\\ /"];
        for (int i = 0; i < 20; i++)
        {
            // <Animation>
            foreach (string s in animations)
            {
                Console.Write(s);
                await Task.Delay(50);
                Console.Write("\b\b\b");
            }
            // </Animation>
        }
        Console.WriteLine();
    }
}

