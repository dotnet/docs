using System;

public class RegExExamples
{
    public static void Example1()
    {
        // <Snippet1>
        String[] expressions = { "16 + 21", "31 * 3", "28 / 3",
                               "42 - 18", "12 * 7",
                               "2, 4, 6, 8" };
        String pattern = @"(\d+)\s+([-+*/])\s+(\d+)";

        foreach (string expression in expressions)
        {
            foreach (System.Text.RegularExpressions.Match m in
            System.Text.RegularExpressions.Regex.Matches(expression, pattern))
            {
                int value1 = Int32.Parse(m.Groups[1].Value);
                int value2 = Int32.Parse(m.Groups[3].Value);
                switch (m.Groups[2].Value)
                {
                    case "+":
                        Console.WriteLine($"{m.Value} = {value1 + value2}");
                        break;
                    case "-":
                        Console.WriteLine($"{m.Value} = {value1 - value2}");
                        break;
                    case "*":
                        Console.WriteLine($"{m.Value} = {value1 * value2}");
                        break;
                    case "/":
                        Console.WriteLine($"{m.Value} = {value1 / value2:N2}");
                        break;
                }
            }
        }

        // The example displays the following output:
        //       16 + 21 = 37
        //       31 * 3 = 93
        //       28 / 3 = 9.33
        //       42 - 18 = 24
        //       12 * 7 = 84
        // </Snippet1>
    }

    public static void Example2()
    {
        // <Snippet2>
        String input = "[This is captured\ntext.]\n\n[\n" +
                       "[This is more captured text.]\n]\n" +
                       "[Some more captured text:\n   Option1" +
                       "\n   Option2][Terse text.]";
        String pattern = @"\[([^\[\]]+)\]";
        int ctr = 0;

        foreach (System.Text.RegularExpressions.Match m in
           System.Text.RegularExpressions.Regex.Matches(input, pattern))
        {
            Console.WriteLine($"{++ctr}: {m.Groups[1].Value}");
        }

        // The example displays the following output:
        //       1: This is captured
        //       text.
        //       2: This is more captured text.
        //       3: Some more captured text:
        //          Option1
        //          Option2
        //       4: Terse text.
        // </Snippet2>
    }

    public static void Example3()
    {
        // <Snippet3>
        String input = "abacus -- alabaster - * - atrium -+- " +
                       "any -*- actual - + - armoire - - alarm";
        String pattern = @"\s-\s?[+*]?\s?-\s";
        String[] elements = System.Text.RegularExpressions.Regex.Split(input, pattern);

        foreach (string element in elements)
            Console.WriteLine(element);

        // The example displays the following output:
        //       abacus
        //       alabaster
        //       atrium
        //       any
        //       actual
        //       armoire
        //       alarm
        // </Snippet3>
    }
}
