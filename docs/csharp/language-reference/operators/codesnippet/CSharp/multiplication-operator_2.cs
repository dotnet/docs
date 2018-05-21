    public class Pointer
    {
        unsafe static void Main()
        {
            int i = 5;
            int* j = &i;
            System.Console.WriteLine(*j);
        }
    }
    /*
    Output:
    5
    */