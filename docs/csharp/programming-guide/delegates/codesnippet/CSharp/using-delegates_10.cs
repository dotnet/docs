    delegate void Delegate1();
    delegate void Delegate2();

    static void method(Delegate1 d, Delegate2 e, System.Delegate f)
    {
        // Compile-time error.
        //Console.WriteLine(d == e);

        // OK at compile-time. False if the run-time type of f 
        // is not the same as that of d.
        System.Console.WriteLine(d == f);
    }