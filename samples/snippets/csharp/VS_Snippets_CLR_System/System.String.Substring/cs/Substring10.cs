//<snippet10>
using System;

public class SubStringTest {
    public static void Main() {
        string [] info = { "Name: Felica Walker", "Title: Mz.", 
                           "Age: 47", "Location: Paris", "Gender: F"};
        int found = 0;

        Console.WriteLine("The initial values in the array are:");
        foreach (string s in info)
            Console.WriteLine(s);

        Console.WriteLine("\nWe want to retrieve only the key information. That is:");        
        foreach (string s in info) {
            found = s.IndexOf(": ");
            Console.WriteLine("   {0}", s.Substring(found + 2));
        }
    }
}
// The example displays the following output:
//       The initial values in the array are:
//       Name: Felica Walker
//       Title: Mz.
//       Age: 47
//       Location: Paris
//       Gender: F
//       
//       We want to retrieve only the key information. That is:
//          Felica Walker
//          Mz.
//          47
//          Paris
//          F
//</snippet10>
