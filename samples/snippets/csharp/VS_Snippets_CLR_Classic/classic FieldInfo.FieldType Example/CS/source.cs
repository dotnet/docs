// <Snippet1>
using System;
using System.Reflection;

public class TestClass
{
    // Define a field.
    private string field = "private field";
}
 
public class Example
{
    public static void Main()
    {
        var cl= new TestClass();
  
        // Get the type and FieldInfo.
        Type t = cl.GetType();
        FieldInfo fi = t.GetField("field", 
            BindingFlags.Instance | BindingFlags.NonPublic);
  
        // Get and display the field type.
        Console.WriteLine("Field Name: {0}.{1}", t.FullName, fi.Name);
        Console.WriteLine("Field Value: '{0}'", fi.GetValue(cl));
        Console.WriteLine("Field Type: {0}", fi.FieldType);
    }
}
// The example displays the following output:
//       Field Name: TestClass.field
//       Field Value: 'private field'
//       Field Type: System.String
// </Snippet1>

