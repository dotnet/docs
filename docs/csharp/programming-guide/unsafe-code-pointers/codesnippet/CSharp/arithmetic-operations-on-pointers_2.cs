class PointerArithmetic
{
    unsafe static void Main() 
    {
        int* memory = stackalloc int[30];
        long difference;
        int* p1 = &memory[4];
        int* p2 = &memory[10];

        difference = p2 - p1;

        System.Console.WriteLine("The difference is: {0}", difference);
    }
}
// Output:  The difference is: 6