//<snippet1>
// This code example demonstrates the 
// Nullable<T>.GetValueOrDefault methods.

using System;

class Sample 
{
    public static void Main() 
    {
    float? mySingle = 12.34f;
    float? yourSingle = -1.0f;

   Console.WriteLine("*** Display a value or the default value ***\n");
// Display the values of mySingle and yourSingle.

    Display("A1", mySingle, yourSingle);

// Assign the value of mySingle to yourSingle, then display the values 
// of mySingle and yourSingle. The yourSingle variable is assigned the 
// value 12.34 because mySingle has a value.

    yourSingle = mySingle.GetValueOrDefault();
    Display("A2", mySingle, yourSingle);

// Assign null (Nothing in Visual Basic) to mySingle, which means no value is
// defined for mySingle. Then assign the value of mySingle to yourSingle and
// display the values of both variables. The default value of all binary zeroes 
// is assigned to yourSingle because mySingle has no value.

    mySingle = null;
    yourSingle = mySingle.GetValueOrDefault();
    Display("A3", mySingle, yourSingle);

// Reassign the original values of mySingle and yourSingle.
    mySingle = 12.34f;
    yourSingle = -1.0f;

    Console.Write("\n*** Display a value or the ");
    Console.WriteLine("specified default value ***\n");

// Display the values of mySingle and yourSingle.
    Display("B1", mySingle, yourSingle);

// Assign the value of mySingle to yourSingle, then display the values 
// of mySingle and yourSingle. The yourSingle variable is assigned the 
// value 12.34 because mySingle has a value.

    yourSingle = mySingle.GetValueOrDefault(-222.22f);
    Display("B2", mySingle, yourSingle);

// Assign null (Nothing in Visual Basic) to mySingle, which means no value is
// defined for mySingle. Then assign the value of mySingle to yourSingle and
// display the values of both variables. The specified default value of -333.33
// is assigned to yourSingle because mySingle has no value.

    mySingle = null;
    yourSingle = mySingle.GetValueOrDefault(-333.33f);
    Display("B3", mySingle, yourSingle);

    }

// Display the values of two nullable of System.Single structures.
// The Console.WriteLine method automatically calls the ToString methods of 
// each input argument to display its values. If no value is defined for a
// nullable type, the ToString method for that argument returns the empty
// string ("").
    public static void Display(string title, float? dspMySingle, float? dspYourSingle)
    {
    Console.WriteLine("{0}) mySingle = [{1}], yourSingle = [{2}]", 
                      title, dspMySingle, dspYourSingle);    
    }
}

/*
This code example produces the following results:

A1) mySingle = [12.34], yourSingle = [-1]
A2) mySingle = [12.34], yourSingle = [12.34]
A3) mySingle = [], yourSingle = [0]

*** Display a value or the specified default value ***

B1) mySingle = [12.34], yourSingle = [-1]
B2) mySingle = [12.34], yourSingle = [12.34]
B3) mySingle = [], yourSingle = [-333.33]

*/
//</snippet1>