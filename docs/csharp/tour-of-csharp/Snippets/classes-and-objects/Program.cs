using System;

namespace ClassesAndObjects
{
    public class Program
    {
        static void PointExample()
        {
            // <CreatePoints>
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 20);
            // </CreatePoints>
        }

        static void PairExample()
        {
            // <CreatePairObject>
            Pair<int,string> pair = new Pair<int,string> { First = 1, Second = "two" };
            int i = pair.First;     // TFirst is int
            string s = pair.Second; // TSecond is string
            // </CreatePairObject>
        }

        static void Point3DExample()
        {
            // <ImplicitCastToBase>
            Point a = new Point(10, 20);
            Point b = new Point3D(10, 20, 30);
            // </ImplicitCastToBase>
        }

        static void StringFormatExample()
        {
            // <CompilerParams>
            int x = 3, y = 4, z = 5;

            string s = "x={0} y={1} z={2}";
            object[] args = new object[3];
            args[0] = x;
            args[1] = y;
            args[2] = z;
            Console.WriteLine(s, args);
            // </CompilerParams>
        }

        static void ExpressionExample()
        {
            // <UseExpressions>
            Expression e = new Operation(
                new VariableReference("x"),
                '+',
                new Constant(3));
            // </UseExpressions>
        }

        public static void Main(string[] args)
        {
            PointExample();
            PairExample();
            Point3DExample();
            RefExample.SwapExample();
            OutExample.OutUsage();

            // <UseParamsArgs>
            int x = 3, y = 4, z = 5;
            Console.WriteLine("x={0} y={1} z={2}", x, y, z);
            // </UseParamsArgs>

            Squares.WriteSquares();

            EntityExample.Usage();

            ExpressionExample();

            InheritanceExample.ExampleUsage();

            OverloadingExample.UsageExample();

            ListExamples.ExampleCode.ListExampleOne();
            ListExamples.ExampleCode.ListExampleTwo();
            ListExamples.ExampleCode.ListExampleThree();
            ListExamples.EventExample.Usage();
            ListExamples.ExampleCode.ListExampleFour();
        }
    }
}

namespace Snippets
{
    // <ConsoleExtract>
    public class Console
    {
        public static void Write(string fmt, params object[] args) { }
        public static void WriteLine(string fmt, params object[] args) { }
        // ...
    }
    // </ConsoleExtract>
}
