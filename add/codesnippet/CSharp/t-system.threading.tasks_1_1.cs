    using System.Threading.Tasks;   
    class Test
    {
        static int N = 1000;

        static void TestMethod()
        {
            // Using a named method.
            Parallel.For(0, N, Method2);

            // Using an anonymous method.
            Parallel.For(0, N, delegate(int i)
            {
                // Do Work.
            });

            // Using a lambda expression.
            Parallel.For(0, N, i =>
            {
                // Do Work.
            });
        }

        static void Method2(int i)
        {
            // Do work.
        }
    }