using System;

namespace nullablepatternmatching
{
    // <SnippetPatternMatchingNullable>
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            PatternMatchingNullable(i);

            int? j = null;
            PatternMatchingNullable(j);

            double d = 9.78654;
            PatternMatchingNullable(d);

            PatternMatchingSwitch(i);
            PatternMatchingSwitch(j);
            PatternMatchingSwitch(d);
        }

        static void PatternMatchingNullable(System.ValueType val)
        {
            if (val is int j) // Nullable types are not allowed in patterns
            {
                Console.WriteLine(j);
            }
            else if (val is null) // If val is a nullable type with no value, this expression is true
            {
                Console.WriteLine("val is a nullable type with the null value");
            }
            else
            {
                Console.WriteLine("Could not convert " + val.ToString());
            }
        }

        static void PatternMatchingSwitch(System.ValueType val)
        {
            switch (val)
            {
                case int number:
                    Console.WriteLine(number);
                    break;
                case long number:
                    Console.WriteLine(number);
                    break;
                case decimal number:
                    Console.WriteLine(number);
                    break;
                case float number:
                    Console.WriteLine(number);
                    break;
                case double number:
                    Console.WriteLine(number);
                    break;
                case null:
                    Console.WriteLine("val is a nullable type with the null value");
                    break;
                default:
                    Console.WriteLine("Could not convert " + val.ToString());
                    break;
            }
        }
    }
    // </SnippetPatternMatchingNullable>
}
