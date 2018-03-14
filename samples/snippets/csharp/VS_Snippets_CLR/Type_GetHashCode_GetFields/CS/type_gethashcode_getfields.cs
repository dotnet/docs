// <Snippet1>
using System;
using System.Security;
using System.Reflection;

class FieldsSample
{
    public static void Main()						  
    {
        Type myType = typeof(System.Net.IPAddress);
        FieldInfo [] myFields = myType.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
        Console.WriteLine ("\nThe IPAddress class has the following nonpublic fields: ");
        foreach (FieldInfo myField in myFields) 
        {
            Console.WriteLine(myField.ToString());
        }
        Type myType1 = typeof(System.Net.IPAddress);
        FieldInfo [] myFields1 = myType1.GetFields();
        Console.WriteLine ("\nThe IPAddress class has the following public fields: ");
        foreach (FieldInfo myField in myFields1) 
        {
            Console.WriteLine(myField.ToString());
        }
        try
        {
            Console.WriteLine("The HashCode of the System.Windows.Forms.Button type is: {0}",
                typeof(System.Windows.Forms.Button).GetHashCode());
        }		
        catch(SecurityException e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Message: "+e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Message: "+e.Message);

        }		
    }
}	
// </Snippet1>
