//<snippet1>
using System;

public class ConcatTest {
    public static void Main() {

        // we want to simply quickly add this person's name together
        string fName = "Simon";
        string mName = "Jake";
        string lName = "Harrows";

        // because we want a name to appear with a space in between each name, 
        // put a space on the front of the middle, and last name, allowing for
        // the fact that a space may already be there
        mName = " " + mName.Trim();
        lName = " " + lName.Trim();

        // this line simply concatenates the two strings
        Console.WriteLine("Welcome to this page, '{0}'!", string.Concat( string.Concat(fName, mName), lName ) );
    }
}
// The example displays the following output:
//        Welcome to this page, 'Simon Jake Harrows'!
// </snippet1>