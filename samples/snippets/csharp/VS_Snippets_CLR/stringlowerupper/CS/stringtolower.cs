//<snippet1>
using System;

public class ToLowerTest {
    public static void Main() {

        string [] info = {"Name", "Title", "Age", "Location", "Gender"};

        Console.WriteLine("The initial values in the array are:");
        foreach (string s in info)
            Console.WriteLine(s);

        Console.WriteLine("{0}The lowercase of these values is:", Environment.NewLine);        

        foreach (string s in info)
            Console.WriteLine(s.ToLower());

        Console.WriteLine("{0}The uppercase of these values is:", Environment.NewLine);        

        foreach (string s in info)
            Console.WriteLine(s.ToUpper());
    }
}
// The example displays the following output:
//       The initial values in the array are:
//       Name
//       Title
//       Age
//       Location
//       Gender
//       
//       The lowercase of these values is:
//       name
//       title
//       age
//       location
//       gender
//       
//       The uppercase of these values is:
//       NAME
//       TITLE
//       AGE
//       LOCATION
//       GENDER
//</snippet1>
