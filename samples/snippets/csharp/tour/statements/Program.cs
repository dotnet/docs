using System;
using System.Collections.Generic;
using System.IO;

namespace Statements
{
    public class Program
    {
        static void Declarations(string[] args)
        {
            int a;
            int b = 2, c = 3;
            a = 1;
            Console.WriteLine(a + b + c);
        }

        static void ConstantDeclarations(string[] args)
        {
            const float pi = 3.1415927f;
            const int r = 25;
            Console.WriteLine(pi * r * r);
        }

        static void Expressions(string[] args)
        {
            int i;
            i = 123;                // Expression statement
            Console.WriteLine(i);   // Expression statement
            i++;                    // Expression statement
            Console.WriteLine(i);   // Expression statement
        }

        static void IfStatement(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments");
            }
            else 
            {
                Console.WriteLine("One or more arguments");
            }
        }

        static void SwitchStatement(string[] args)
        {
            int n = args.Length;
            switch (n) 
            {
                case 0:
                    Console.WriteLine("No arguments");
                    break;
                case 1:
                    Console.WriteLine("One argument");
                    break;
                default:
                Console.WriteLine($"{n} arguments");
                break;
            }
        }

        static void WhileStatement(string[] args)
        {
            int i = 0;
            while (i < args.Length) 
            {
                Console.WriteLine(args[i]);
                i++;
            }
        }

        static void DoStatement(string[] args)
        {
            string s;
            do 
            {
                s = Console.ReadLine();
                if (string.IsNullOrEmpty(s)) 
                    Console.WriteLine(s);
            } while (!string.IsNullOrEmpty(s));
        }

        static void ForStatement(string[] args)
        {
            for (int i = 0; i < args.Length; i++) 
            {
                Console.WriteLine(args[i]);
            }
        }

        static void ForEachStatement(string[] args)
        {
            foreach (string s in args) 
            {
                Console.WriteLine(s);
            }
        }

        static void BreakStatement(string[] args)
        {
            while (true) 
            {
                string s = Console.ReadLine();
                if (string.IsNullOrEmpty(s)) 
                    break;
                Console.WriteLine(s);
            }
        }

        static void ContinueStatement(string[] args)
        {
            for (int i = 0; i < args.Length; i++) 
            {
                if (args[i].StartsWith("/")) 
                    continue;
                Console.WriteLine(args[i]);
            }
        }

        static void GoToStatement(string[] args)
        {
            int i = 0;
            goto check;
            loop:
            Console.WriteLine(args[i++]);
            check:
            if (i < args.Length) 
                goto loop;
        }

        static int Add(int a, int b) 
        {
            return a + b;
        }
        static void ReturnStatement(string[] args)
        {
           Console.WriteLine(Add(1, 2));
           return;
        }

        static IEnumerable<int> Range(int from, int to) 
        {
            for (int i = from; i < to; i++) 
            {
                yield return i;
            }
            yield break;
        }
        static void YieldStatement(string[] args)
        {
            foreach (int i in Range(-10,10)) 
            {
                Console.WriteLine(i);
            }
        }

        static double Divide(double x, double y) 
        {
            if (y == 0) 
                throw new DivideByZeroException();
            return x / y;
        }
        static void TryCatch(string[] args) 
        {
            try 
            {
                if (args.Length != 2) 
                {
                    throw new InvalidOperationException("Two numbers required");
                }
                double x = double.Parse(args[0]);
                double y = double.Parse(args[1]);
                Console.WriteLine(Divide(x, y));
            }
            catch (InvalidOperationException e) 
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                Console.WriteLine("Good bye!");
            }
        }

        static void CheckedUnchecked(string[] args) 
        {
            int x = int.MaxValue;
            unchecked 
            {
                Console.WriteLine(x + 1);  // Overflow
            }
            checked 
            {
                Console.WriteLine(x + 1);  // Exception
            }     
        }

        static void UsingStatement(string[] args) 
        {
            using (TextWriter w = File.CreateText("test.txt")) 
            {
                w.WriteLine("Line one");
                w.WriteLine("Line two");
                w.WriteLine("Line three");
            }
        }

        public static void Main(string[] args)
        {
            Declarations(args);

            ConstantDeclarations(args);

            Expressions(args);

            IfStatement(args);

            SwitchStatement(args);

            WhileStatement(args);

            Console.WriteLine("Type Mesages. Enter a blank line to end");
            DoStatement(args);
            
            ForStatement(args);

            ForEachStatement(args);

            Console.WriteLine("Type Mesages. Enter a blank line to end");
            BreakStatement(args);
            
            ContinueStatement(args);

            GoToStatement(args);
           
           ReturnStatement(args);

           YieldStatement(args);

           TryCatch(args);

           try {
               CheckedUnchecked(args);
           } catch (OverflowException e)
           {
               Console.WriteLine("Caught Expected Exception");
           }

           var a = new Account();
           a.Withdraw(-5);
           a.Withdraw(2);

           UsingStatement(args);
        }
    }

    class Account
    {
        decimal balance;
        private readonly object sync = new object();
        public void Withdraw(decimal amount) 
        {
            lock (sync) 
            {
                if (amount > balance) 
                {
                    throw new Exception(
                        "Insufficient funds");
                }
                balance -= amount;
            }
        }
    }
}
