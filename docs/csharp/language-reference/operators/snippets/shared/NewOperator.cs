using System;
using System.Collections.Generic;
using System.Linq;

namespace operators
{
    public static class NewOperator
    {
        public static void Examples()
        {
            Constructor();
            ConstructorWithInitializer();
            Array();
            ArrayInitialization();
            AnonymousType();
        }

        private static void Constructor()
        {
            // <SnippetConstructor>
            var dict = new Dictionary<string, int>();
            dict["first"] = 10;
            dict["second"] = 20;
            dict["third"] = 30;

            Console.WriteLine(string.Join("; ", dict.Select(entry => $"{entry.Key}: {entry.Value}")));
            // Output:
            // first: 10; second: 20; third: 30
            // </SnippetConstructor>
        }

        private static void ConstructorWithInitializer()
        {
            // <SnippetConstructorWithInitializer>
            var dict = new Dictionary<string, int>
            {
                ["first"] = 10,
                ["second"] = 20,
                ["third"] = 30
            };

            Console.WriteLine(string.Join("; ", dict.Select(entry => $"{entry.Key}: {entry.Value}")));
            // Output:
            // first: 10; second: 20; third: 30
            // </SnippetConstructorWithInitializer>
        }

        private static void Array()
        {
            // <SnippetArray>
            var numbers = new int[3];
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;

            Console.WriteLine(string.Join(", ", numbers));
            // Output:
            // 10, 20, 30
            // </SnippetArray>
        }

        private static void ArrayInitialization()
        {
            // <SnippetArrayInitialization>
            var a = new int[3] { 10, 20, 30 };
            var b = new int[] { 10, 20, 30 };
            var c = new[] { 10, 20, 30 };
            Console.WriteLine(c.GetType());  // output: System.Int32[]
            // </SnippetArrayInitialization>
        }

        private static void AnonymousType()
        {
            // <SnippetAnonymousType>
            var example = new { Greeting = "Hello", Name = "World" };
            Console.WriteLine($"{example.Greeting}, {example.Name}!");
            // Output:
            // Hello, World!
            // </SnippetAnonymousType>
        }
    }
}