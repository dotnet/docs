// <Snippet1>
using System;
using System.Reflection;
using System.Runtime.Serialization;

public class MyClass 
{
    public short myShort;

    // The following field will not be serialized.  
    [NonSerialized()]
    public int myInt;
}
public class Type_IsNotSerializable
{
    public static void Main()
    {  
        // Get the type of MyClass.
        Type myType = typeof(MyClass);
 
        // Get the fields of MyClass.
        FieldInfo[] myFields = myType.GetFields(BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);
        Console.WriteLine("\nDisplaying whether or not the field is serializable.\n");
      
        // Display whether or not the field is serializable.
        for(int i = 0; i < myFields.Length; i++)
            if(myFields[i].IsNotSerialized)
                Console.WriteLine("The {0} field is not serializable.", myFields[i]);
            else
                Console.WriteLine("The {0} field is not serializable.", myFields[i]);
    }
}
// </Snippet1>