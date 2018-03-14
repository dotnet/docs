// <Snippet1>
using System;
using System.Reflection;
using System.Globalization;

public class Example
{
    private string myString;
    public Example()
    {
        myString = "Old value";
    }

    public string StringProperty
    {
        get
        {
            return myString;
        }
    }
}

public class FieldInfo_SetValue
{
    public static void Main()
    {
        Example myObject = new Example();
        Type myType = typeof(Example);
        FieldInfo myFieldInfo = myType.GetField("myString", 
            BindingFlags.NonPublic | BindingFlags.Instance); 

        // Display the string before applying SetValue to the field.
        Console.WriteLine( "\nThe field value of myString is \"{0}\".", 
        myFieldInfo.GetValue(myObject)); 
        // Display the SetValue signature used to set the value of a field.
        Console.WriteLine( "Applying SetValue(Object, Object)."); 
   
        // Change the field value using the SetValue method. 
        myFieldInfo.SetValue(myObject, "New value"); 
        // Display the string after applying SetValue to the field.
        Console.WriteLine( "The field value of mystring is \"{0}\".", 
            myFieldInfo.GetValue(myObject));
    }
}

/* This code example produces the following output:

The field value of myString is "Old value".
Applying SetValue(Object, Object).
The field value of mystring is "New value".
 */
// </Snippet1>