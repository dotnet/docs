//<snippet1>
// This code example demonstrates the Nullable<T>.Equals 
// methods.

using System;

class Sample 
{
    public static void Main() 
    {
    int? nullInt1 = 100;
    int? nullInt2 = 200;
    object myObj;

// Determine if two nullable of System.Int32 values are equal.
// The nullable objects have different values.
    Console.Write("1) nullInt1 and nullInt2 ");
    if (nullInt1.Equals(nullInt2))
        Console.Write("are");
    else
        Console.Write("are not");
    Console.WriteLine(" equal.");

// Determine if a nullable of System.Int32 and an object 
// are equal. The object contains the boxed value of the
// nullable object.

    myObj = (object)nullInt1;
    Console.Write("2) nullInt1 and myObj ");
    if (nullInt1.Equals(myObj))
        Console.Write("are");
    else
        Console.Write("are not");
    Console.WriteLine(" equal.");
    }
}

/*
This code example produces the following results:

1) nullInt1 and nullInt2 are not equal.
2) nullInt1 and myObj are equal.

*/
//</snippet1>