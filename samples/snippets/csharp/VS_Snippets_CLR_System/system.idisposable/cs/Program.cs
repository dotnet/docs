static class Program
{
    static void Main()
    {
        using var disposable = new BaseClassWithSafeHandle();
    }
}
