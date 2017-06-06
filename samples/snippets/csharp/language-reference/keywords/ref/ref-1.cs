class RefExample
{
    static void Method(ref int i)
    {
        i = i + 44;
    }

    static void Main()
    {
        int val = 1;
        Method(ref val);
        Console.WriteLine(val);
        // Output: 45
    }
}
