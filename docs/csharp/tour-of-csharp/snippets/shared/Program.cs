namespace TourOfCsharp;

class Program
{
    static void Main(string[] args)
    {
        global::Example.Main();
        Boxing();
        Types.Examples();
        ClassesObjects.Examples();
        Features.Examples();
    }

    private static void Boxing()
    {
        // <Boxing>
        int i = 123;
        object o = i;    // Boxing
        int j = (int)o;  // Unboxing            
        // </Boxing>
    }
}
