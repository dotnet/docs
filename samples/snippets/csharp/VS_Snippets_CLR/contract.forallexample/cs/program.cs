//<Snippet1>
using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
namespace AssumeEx
{
    class Program
    {
        // Start application with at least two arguments
        static void Main(string[] args)
        {
            args[1] = null;
            Contract.Requires(args != null && Contract.ForAll(0, args.Length, i => args[i] != null));
            // test the ForAll method.  This is only for purpose of demonstrating how ForAll works.
            CheckIndexes(args);
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push(null);
            numbers.Push("four");
            numbers.Push("five");
            Contract.Requires(numbers != null && !Contract.ForAll(numbers, (String x) => x != null));
            // test the ForAll generic overload.  This is only for purpose of demonstrating how ForAll works.
            CheckTypeArray(numbers);
        }

        private static bool CheckIndexes(string[] args)
        {
            try
            {
                if (args != null && !Contract.ForAll(0, args.Length, i => args[i] != null))
                    throw new ArgumentException("The parameter array has a null element", "args");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        private static bool CheckTypeArray(IEnumerable<String> xs)
        {
            try
            {
                if (xs != null && !Contract.ForAll(xs, (String x) => x != null))
                    throw new ArgumentException("The parameter array has a null element", "indexes");
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
//</Snippet1>