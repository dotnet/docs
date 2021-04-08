using System;
using System.Collections.Generic;

namespace operators
{
    public static class TypeTestingAndConversionOperators
    {
        public static void Examples()
        {
            Cast();
            IsOperatorExample.Main();
            IsOperatorWithInt();
            IsOperatorDeclarationPattern();
            AsOperator();
            TypeOf();
            TypeOfUnboundGeneric();
            TypeOfExample.Main();
        }

        private static void Cast()
        {
            // <SnippetCast>
            double x = 1234.7;
            int a = (int)x;
            Console.WriteLine(a);   // output: 1234

            IEnumerable<int> numbers = new int[] { 10, 20, 30 };
            IList<int> list = (IList<int>)numbers;
            Console.WriteLine(list.Count);  // output: 3
            Console.WriteLine(list[1]);  // output: 20
            // </SnippetCast>
        }

        // <SnippetIsWithReferenceConversion>
        public class Base { }

        public class Derived : Base { }

        public static class IsOperatorExample
        {
            public static void Main()
            {
                object b = new Base();
                Console.WriteLine(b is Base);  // output: True
                Console.WriteLine(b is Derived);  // output: False

                object d = new Derived();
                Console.WriteLine(d is Base);  // output: True
                Console.WriteLine(d is Derived); // output: True
            }
        }
        // </SnippetIsWithReferenceConversion>

        private static void IsOperatorWithInt()
        {
            // <SnippetIsWithInt>
            int i = 27;
            Console.WriteLine(i is System.IFormattable);  // output: True

            object iBoxed = i;
            Console.WriteLine(iBoxed is int);  // output: True
            Console.WriteLine(iBoxed is long);  // output: False
            // </SnippetIsWithInt>
        }

        private static void IsOperatorDeclarationPattern()
        {
            // <SnippetIsDeclarationPattern>
            int i = 23;
            object iBoxed = i;
            int? jNullable = 7;
            if (iBoxed is int a && jNullable is int b)
            {
                Console.WriteLine(a + b);  // output 30
            }
            // </SnippetIsDeclarationPattern>
        }

        private static void AsOperator()
        {
            // <SnippetAsOperator>
            IEnumerable<int> numbers = new[] { 10, 20, 30 };
            IList<int> indexable = numbers as IList<int>;
            if (indexable != null)
            {
                Console.WriteLine(indexable[0] + indexable[indexable.Count - 1]);  // output: 40
            }
            // </SnippetAsOperator>
        }

        private static void TypeOf()
        {
            // <SnippetTypeOf>
            void PrintType<T>() => Console.WriteLine(typeof(T));

            Console.WriteLine(typeof(List<string>));
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
            // Output:
            // System.Collections.Generic.List`1[System.String]
            // System.Int32
            // System.Int32
            // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
            // </SnippetTypeOf>
        }

        private static void TypeOfUnboundGeneric()
        {
            // <SnippetTypeOfUnboundGeneric>
            Console.WriteLine(typeof(Dictionary<,>));
            // Output:
            // System.Collections.Generic.Dictionary`2[TKey,TValue]
            // </SnippetTypeOfUnboundGeneric>
        }

        // <SnippetTypeCheckWithTypeOf>
        public class Animal { }

        public class Giraffe : Animal { }

        public static class TypeOfExample
        {
            public static void Main()
            {
                object b = new Giraffe();
                Console.WriteLine(b is Animal);  // output: True
                Console.WriteLine(b.GetType() == typeof(Animal));  // output: False

                Console.WriteLine(b is Giraffe);  // output: True
                Console.WriteLine(b.GetType() == typeof(Giraffe));  // output: True
            }
        }
        // </SnippetTypeCheckWithTypeOf>
    }
}