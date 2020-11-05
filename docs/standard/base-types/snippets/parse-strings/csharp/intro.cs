using System;

class Intro
{
    public static void Intro1()
    {
        //<snippet1>
        string s = "You win some. You lose some.";

        string[] subs = s.Split();

        foreach (string sub in subs)
        {
            Console.WriteLine($"Substring: {sub}");
        }

        // This example produces the following output:
        //
        // Substring: You
        // Substring: win
        // Substring: some.
        // Substring: You
        // Substring: lose
        // Substring: some.
        //</snippet1>
    }

    public static void Intro2()
    {
        //<snippet2>
        string s = "You win some. You lose some.";

        string[] subs = s.Split(' ', '.');

        foreach (string sub in subs)
        {
            Console.WriteLine($"Substring: {sub}");
        }

        // This example produces the following output:
        //
        // Substring: You
        // Substring: win
        // Substring: some
        // Substring:
        // Substring: You
        // Substring: lose
        // Substring: some
        // Substring:
        //</snippet2>
    }

    public static void Intro3()
    {
        //<snippet3>
        string s = "You win some. You lose some.";
        char[] separators = new char[] { ' ', '.' };

        string[] subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string sub in subs)
        {
            Console.WriteLine($"Substring: {sub}");
        }

        // This example produces the following output:
        //
        // Substring: You
        // Substring: win
        // Substring: some
        // Substring: You
        // Substring: lose
        // Substring: some
        //</snippet3>
    }
}
