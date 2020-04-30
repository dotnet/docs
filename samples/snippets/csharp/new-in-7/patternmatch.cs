using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    public class Patterns
    {
        public static void IsPatternTestOne()
        {
            // <SnippetSimpleIsPattern>
            object count = 5;

            if (count is int number)
                Console.WriteLine(number);
            else
                Console.WriteLine($"{count} is not an integer");
            // </SnippetSimpleIsPattern>
        }

        public static void SwitchPatternSimple()
        {
            // <SnippetSimpleSwitchPattern>
            test(5);

            void test(object obj)
            {
                switch (obj)
                {
                    case int i:
                        Console.WriteLine($"The object is an integer: {i}");
                        break;
                    case null:
                        Console.WriteLine($"The object is null");
                        break;
                    default:
                        Console.WriteLine($"The object is some other type");
                        break;
                }
            }
            // </SnippetSimpleSwitchPattern>
        }
        public static void SwitchPatternFull()
        {
            test(5);

            // <SnippetNullableSwitch>
            int? answer = 42;
            test(answer);
            // </SnippetNullableSwitch>

            // <SnippetTestLong>
            long longValue = 12;
            test(longValue);
            // </SnippetTestLong>
            // <SnippetMoreTests>
            double pi = 3.14;
            test(pi);
            string sum = "12";
            test(sum);
            answer = null;
            test(answer);
            // </SnippetMoreTests>
            // <SnippetTestWhenClause>
            string message = "This is a longer message";
            test(message);
            // </SnippetTestWhenClause>

            void test(object obj)
            {
                switch (obj)
                {
                    // <SnippetConstantCase>
                    case 5:
                        Console.WriteLine("The object is 5");
                        break;
                    // </SnippetConstantCase>
                    case int i:
                        Console.WriteLine($"The object is an integer: {i}");
                        break;
                        // <SnippetMoreCases>
                    case long l:
                        Console.WriteLine($"The object is a long: {l}");
                        break;
                    case double d:
                        Console.WriteLine($"The object is a double: {d}");
                        break;
                        // <SnippetWhenClause>
                    case string s when s.StartsWith("This"):
                        Console.WriteLine($"This was a string that started with the word 'This': {s}");
                        break;
                        // </SnippetWhenClause>
                    case string s:
                        Console.WriteLine($"The object is a string: {s}");
                        break;
                    // </SnippetMoreCases>
                    case null:
                        Console.WriteLine($"The object is null");
                        break;
                    default:
                        Console.WriteLine($"The object is some other type");
                        break;
                }
            }
        }
    }
}
