﻿using System;
using System.Collections.Generic;

namespace operators
{
    public static class NameOfOperator
    {
        public static void Examples()
        {
            // <SnippetExamples>
            Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
            Console.WriteLine(nameof(List<int>));  // output: List
            Console.WriteLine(nameof(List<int>.Count));  // output: Count
            Console.WriteLine(nameof(List<int>.Add));  // output: Add

            var numbers = new List<int> { 1, 2, 3 };
            Console.WriteLine(nameof(numbers));  // output: numbers
            Console.WriteLine(nameof(numbers.Count));  // output: Count
            Console.WriteLine(nameof(numbers.Add));  // output: Add
            // </SnippetExamples>

            // <SnippetVerbatim>
            var @new = 5;
            Console.WriteLine(nameof(@new));  // output: new
            // </SnippetVerbatim>
        }

        private class Person
        {
            string name;

            // <SnippetExceptionMessage>
            public string Name
            {
                get => name;
                set => name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
            }
            // </SnippetExceptionMessage>
        }
    }
}