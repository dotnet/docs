    [Conditional("CONDITION1")]
    public static void Method1(int x)
    {
        Console.WriteLine("CONDITION1 is defined");
    }
    
    [Conditional("CONDITION1"), Conditional("CONDITION2")]  
    public static void Method2()
    {
        Console.WriteLine("CONDITION1 or CONDITION2 is defined");
    }