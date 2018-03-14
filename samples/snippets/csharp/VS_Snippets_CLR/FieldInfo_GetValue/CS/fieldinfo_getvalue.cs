// <Snippet1>
using System;
using System.Reflection;

public class FieldsClass
{
    public string fieldA;
    public string fieldB;
     
    public FieldsClass()
    {
        fieldA = "A public field";
        fieldB = "Another public field";
    }
}

public class Example
{
    public static void Main()
    {
        FieldsClass fieldsInst = new FieldsClass();
        // Get the type of FieldsClass.
        Type fieldsType = typeof(FieldsClass);

        // Get an array of FieldInfo objects.
        FieldInfo[] fields = fieldsType.GetFields(BindingFlags.Public 
            | BindingFlags.Instance);
        // Display the values of the fields.
        Console.WriteLine("Displaying the values of the fields of {0}:",
            fieldsType);
        for(int i = 0; i < fields.Length; i++)
        {
            Console.WriteLine("   {0}:\t'{1}'",
                fields[i].Name, fields[i].GetValue(fieldsInst));
        }
    }
}
// The example displays the following output:
//     Displaying the values of the fields of FieldsClass:
//        fieldA:      'A public field'
//        fieldB:      'Another public field'
// </Snippet1>


