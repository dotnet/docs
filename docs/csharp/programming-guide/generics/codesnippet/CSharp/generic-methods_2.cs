            public static void TestSwap()
            {
                int a = 1;
                int b = 2;

                Swap<int>(ref a, ref b);
                System.Console.WriteLine(a + " " + b);
            }