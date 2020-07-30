using System;
using System.Collections.Generic;

namespace operators
{
    public static class Overview
    {
        public static void Examples()
        {
            // <SnippetExpressions>
            int a, b, c;
            a = 7;
            b = a;
            c = b++;
            b = a + b * c;
            a = (int)Math.Sqrt(b * b + c * c);
            c = a >= 100 ? b : c / 10;
            
            string s;
            char l;
            s = "String literal";
            a = s.Length;
            l = s[3];
            
            var numbers = new List<int>(new[] { 1, 2, 3 });
            b = numbers.FindLast(n => n > 1);

            Console.WriteLine("void method invocation is also an expression");
            // </SnippetExpressions>
        }
    }
}
