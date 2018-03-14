//<snippet1>
// This code example demonstrates the 
// Nullable<T>.ToString method.

using System;

class Sample 
{
    public static void Main() 
    {
    DateTime? nullableDate;

// Display the current date and time.
    nullableDate = DateTime.Now;
    Display("1)", nullableDate);

// Assign null (Nothing in Visual Basic) to nullableDate, then 
// display its value.
    nullableDate = null;
    Display("2)", nullableDate);
    }

// Display the text representation of a nullable DateTime.
    public static void Display(string title, DateTime? dspDT)
    {
    string msg = dspDT.ToString();

    Console.Write("{0} ", title);
    if (String.IsNullOrEmpty(msg))
        Console.WriteLine("The nullable DateTime has no defined value.");
    else
        Console.WriteLine("The current date and time is {0}.", msg);
    }
}

/*
This code example produces the following results:

1) The current date and time is 4/19/2005 8:28:14 PM.
2) The nullable DateTime has no defined value.

*/
//</snippet1>