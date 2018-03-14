using System;
using System.IO;
using System.ComponentModel;

public class Class1{
    // <Snippet1>
    [TypeConverter(typeof(MyClassConverter))]
     public class MyClass {
        // Insert code here.
     }
    // </Snippet1>

    public class MyClassConverter:TypeConverter
    {

    }
    // <Snippet2>
    public static int Main() {
        // Creates a new instance of MyClass.
        MyClass myNewClass = new MyClass();
     
        // Gets the attributes for the instance.
        AttributeCollection attributes = TypeDescriptor.GetAttributes(myNewClass);
     
        /* Prints the name of the type converter by retrieving the 
         * TypeConverterAttribute from the AttributeCollection. */
        TypeConverterAttribute myAttribute = 
            (TypeConverterAttribute)attributes[typeof(TypeConverterAttribute)];
        
        Console.WriteLine("The type conveter for this class is: " + 
            myAttribute.ConverterTypeName);
     
        return 0;
     }
    // </Snippet2>
}
