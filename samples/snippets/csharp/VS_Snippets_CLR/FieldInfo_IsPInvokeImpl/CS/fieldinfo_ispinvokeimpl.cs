// <Snippet1>
using System;
using System.Reflection;

public class Fieldinfo_IsPinvoke
{
    public string myField = "A public field";
   
    public static void Main()
    {
        Fieldinfo_IsPinvoke myObject = new Fieldinfo_IsPinvoke();
      
        // Get the Type and FieldInfo.
        Type myType1 = typeof(Fieldinfo_IsPinvoke);
        FieldInfo myFieldInfo = myType1.GetField("myField",
            BindingFlags.Public|BindingFlags.Instance);

        // Display the name, field and the PInvokeImpl attribute for the field.
        Console.Write("\n Name of class: {0}", myType1.FullName);
        Console.Write("\n Value of field: {0}", myFieldInfo.GetValue(myObject));
        Console.Write("\n IsPinvokeImpl: {0}", 
            myFieldInfo.IsPinvokeImpl );
    }
}
// </Snippet1>