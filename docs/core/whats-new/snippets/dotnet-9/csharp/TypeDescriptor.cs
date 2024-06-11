using System;
using System.ComponentModel;

internal class TypeDescriptorExamples
{
    // <SnippetTypeDescriptor>
    public static void RunIt()
    {
        // The Type from typeof() is passed to a different method.
        // The trimmer doesn't know about ExampleClass anymore
        // and thus there will be warnings when trimming.
        Test(typeof(ExampleClass));
        Console.ReadLine();
    }

    private static void Test(Type type)
    {
        // When publishing self-contained + trimmed,
        // this line produces warnings IL2026 and IL2067.
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);

        // When publishing self-contained + trimmed,
        // the property count is 0 here instead of 2.
        Console.WriteLine($"Property count: {properties.Count}");

        // To avoid the warning and ensure reflection
        // can see the properties, register the type:
        TypeDescriptor.RegisterType<ExampleClass>();
        // Get properties from the registered type.
        properties = TypeDescriptor.GetPropertiesFromRegisteredType(type);

        Console.WriteLine($"Property count: {properties.Count}");
    }

    public class ExampleClass
    {
        public string? Property1 { get; set; }
        public int Property2 { get; set; }
    }
    // </SnippetTypeDescriptor>
}
