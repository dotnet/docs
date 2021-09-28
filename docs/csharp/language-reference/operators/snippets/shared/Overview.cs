﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace operators
{
    public static class Overview
    {
        public static void Examples()
        {
            GeneralExamples();
            InterpolatedString();
            Lambda();
            Query();
        }

        private static void GeneralExamples()
        {
            // <SnippetExpressions>
            int a, b, c;
            a = 7;
            b = a;
            c = b++;
            b = a + b * c;
            c = a >= 100 ? b : c / 10;
            a = (int)Math.Sqrt(b * b + c * c);
            
            string s = "String literal";
            char l = s[s.Length - 1];
            
            var numbers = new List<int>(new[] { 1, 2, 3 });
            b = numbers.FindLast(n => n > 1);
            // </SnippetExpressions>
        }

        private static void InterpolatedString()
        {
            // <SnippetInterpolatedString>
            var r = 2.3;
            var message = $"The area of a circle with radius {r} is {Math.PI * r * r:F3}.";
            Console.WriteLine(message);
            // Output:
            // The area of a circle with radius 2.3 is 16.619.
            // </SnippetInterpolatedString>
        }

        private static void Lambda()
        {
            // <SnippetLambda>
            int[] numbers = { 2, 3, 4, 5 };
            var maximumSquare = numbers.Max(x => x * x);
            Console.WriteLine(maximumSquare);
            // Output:
            // 25
            // </SnippetLambda>
        }

        private static void Query()
        {
            // <SnippetQuery>
            var scores = new[] { 90, 97, 78, 68, 85 };
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;
            Console.WriteLine(string.Join(" ", highScoresQuery));
            // Output:
            // 97 90 85
            // </SnippetQuery>
        }
    }
}
