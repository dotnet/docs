namespace TestDynamicSnippets
{
    class UsingDynamic
    {
        //<Snippet50>
        static void Main(string[] args)
        {
            ExampleClass ec = new ExampleClass();
            // The following call to exampleMethod1 causes a compiler error
            // if exampleMethod1 has only one parameter. Uncomment the line
            // to see the error.
            //ec.exampleMethod1(10, 4);

            dynamic dynamic_ec = new ExampleClass();
            // The following line is not identified as an error by the
            // compiler, but it causes a run-time exception.
            dynamic_ec.exampleMethod1(10, 4);

            // The following calls also do not cause compiler errors, whether
            // appropriate methods exist or not.
            dynamic_ec.someMethod("some argument", 7, null);
            dynamic_ec.nonexistentMethod();
        }
        //</Snippet50>
    }

    class ExampleClass
    {
        public ExampleClass() { }
        public ExampleClass(int v) { }

        public void exampleMethod1(int i) { }

        public void exampleMethod2(string str) { }
    }

    class OtherExamples
    {
        static void Examples()
        {
            ExampleClass ec = new ExampleClass();

            //<Snippet51>
            dynamic d = 1;
            var testSum = d + 3;
            // Rest the mouse pointer over testSum in the following statement.
            System.Console.WriteLine(testSum);
            //</Snippet51>

            //<Snippet52>
            var testInstance = new ExampleClass(d);
            //</Snippet52>

            //<Snippet53>
            dynamic d1 = 7;
            dynamic d2 = "a string";
            dynamic d3 = System.DateTime.Today;
            dynamic d4 = System.Diagnostics.Process.GetProcesses();
            //</Snippet53>

            //<Snippet54>
            int i = d1;
            string str = d2;
            DateTime dt = d3;
            System.Diagnostics.Process[] procs = d4;
            //</Snippet54>

            //<Snippet55>
            // Valid.
            ec.exampleMethod2("a string");

            // The following statement does not cause a compiler error, even though ec is not
            // dynamic. A run-time exception is raised because the run-time type of d1 is int.
            ec.exampleMethod2(d1);
            // The following statement does cause a compiler error.
            //ec.exampleMethod2(7);
            //</Snippet55>
        }
    }
}
