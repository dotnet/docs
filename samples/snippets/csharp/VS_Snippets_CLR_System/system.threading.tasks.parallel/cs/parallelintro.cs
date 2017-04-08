
    //<snippet07>
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
    //</snippet07>

    namespace LSDemo
    {
        //<snippet08>
        using System;
        using System.Threading.Tasks;

        class Demo
        {
            int N = 1000;

            void TestMethod()
            {
                Parallel.For(0, N, (i, loopState) =>
                {
                    Console.WriteLine(i);
                    if (i == 100)
                    {
                        loopState.Break();
                    }
                });
            }
        }
        //</snippet08>
    }
    

