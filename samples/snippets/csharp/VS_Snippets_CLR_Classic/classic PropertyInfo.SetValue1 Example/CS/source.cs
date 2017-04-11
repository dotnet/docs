// <Snippet1>
using System;
using System.Reflection;
 
// Define a class with a property.
public class TestClass   
{
    private string caption = "A Default caption";
    public string Caption
    {
        get { return caption; }
        set 
        { 
            if (caption != value) 
            {
                caption = value;
            }
        }
    }
}
 
class TestPropertyInfo
{
    public static void Main()
    {
        TestClass t = new TestClass();
 
        // Get the type and PropertyInfo.
        Type myType = t.GetType();
        PropertyInfo pinfo = myType.GetProperty("Caption");
 
        // Display the property value, using the GetValue method.
        Console.WriteLine("\nGetValue: " + pinfo.GetValue(t, null));
 
        // Use the SetValue method to change the caption.
        pinfo.SetValue(t, "This caption has been changed.", null);
 
        //  Display the caption again.
        Console.WriteLine("GetValue: " + pinfo.GetValue(t, null));

        Console.WriteLine("\nPress the Enter key to continue.");
        Console.ReadLine();
    }
}

/*
This example produces the following output:
 
GetValue: A Default caption
GetValue: This caption has been changed

Press the Enter key to continue.
*/
// </Snippet1>

