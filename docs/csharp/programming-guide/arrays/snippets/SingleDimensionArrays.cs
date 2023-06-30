namespace arrays;

public static class SingleDimensionArrays
{
    internal struct SomeType
    {
        string thing;
    }

    public static void Examples()
    {
        Declarations();
    }

    private static void Declarations()
    {
        //<IntDeclaration>
        int[] array = new int[5];
        //</IntDeclaration>

        //<StringDeclaration>
        string[] stringArray = new string[6];
        //</StringDeclaration>

        // Declare and set array element values
        //<IntInitialization>
        int[] array1 = new int[] { 1, 3, 5, 7, 9 };
        //</IntInitialization>

        // <StringInitialization>
        string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        // </StringInitialization>

        //<ShorthandInitialization>
        int[] array2 = { 1, 3, 5, 7, 9 };
        string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        //</ShorthandInitialization>

        //<DeclareAllocate>
        int[] array3;
        array3 = new int[] { 1, 3, 5, 7, 9 };   // OK
        //array3 = {1, 3, 5, 7, 9};   // Error
        //</DeclareAllocate>

        //<FinalInstantiation>
        SomeType[] array4 = new SomeType[10];
        //</FinalInstantiation>
    }
}
