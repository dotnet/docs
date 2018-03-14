// <snippet1>
using System;
using System.Reflection;

class Example
{
    public static void Main()
    {
        string test = "abcdefghijklmnopqrstuvwxyz";

        // Get a PropertyInfo object representing the Chars property.
        PropertyInfo pinfo = typeof(string).GetProperty("Chars");

        // Show the first, seventh, and last letters
        ShowIndividualCharacters(pinfo, test, 0, 6, test.Length - 1);

        // Show the complete string.
        Console.Write("The entire string: ");
        for (int x = 0; x < test.Length; x++)
        {
            Console.Write(pinfo.GetValue(test, new Object[] {x}));
        }
        Console.WriteLine();
    }

    static void ShowIndividualCharacters(PropertyInfo pinfo, 
                                         object value,
                                         params int[] indexes)
    {
       foreach (var index in indexes) 
          Console.WriteLine("Character in position {0,2}: '{1}'",
                            index, pinfo.GetValue(value, new object[] { index }));
       Console.WriteLine();                          
    }                                      
}
// The example displays the following output:
//    Character in position  0: 'a'
//    Character in position  6: 'g'
//    Character in position 25: 'z'
//    
//    The entire string: abcdefghijklmnopqrstuvwxyz
// </snippet1>
