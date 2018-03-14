// <Snippet1>
using System;
using System.Reflection;
  
public class MyClass
{
    public string MyField = "Microsoft";
}

public class FieldInfo_FieldHandle
{
    public static void Main()
    {
    
        MyClass myClass =new MyClass();

        // Get the type of MyClass.
        Type myType = typeof(MyClass);

        try
        {
            // Get the field information of MyField.
            FieldInfo myFieldInfo = myType.GetField("MyField", BindingFlags.Public 
                | BindingFlags.Instance);
      
            // Determine whether or not the FieldInfo object is null.
            if(myFieldInfo!=null)
            {
                // Get the handle for the field.
                RuntimeFieldHandle myFieldHandle=myFieldInfo.FieldHandle;

                DisplayFieldHandle(myFieldHandle);
            }
            else
            {
                Console.WriteLine("The myFieldInfo object is null.");
            }
        }  
        catch(Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }

    public static void DisplayFieldHandle(RuntimeFieldHandle myFieldHandle)
    {
        // Get the type from the handle.
        FieldInfo myField = FieldInfo.GetFieldFromHandle(myFieldHandle);      
      
        // Display the type.
        Console.WriteLine("\nDisplaying the field from the handle.\n");
        Console.WriteLine("The type is {0}.", myField.ToString());
    }
}
// </Snippet1>

