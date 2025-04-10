//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// The example attribute is applied to the assembly.
[assembly:Example(ExampleKind.ThirdKind, Note="This is a note on the assembly.")]

// An enumeration used by the ExampleAttribute class.
public enum ExampleKind
{
    FirstKind,
    SecondKind,
    ThirdKind,
    FourthKind
};

// An example attribute. The attribute can be applied to all
// targets, from assemblies to parameters.
//
[AttributeUsage(AttributeTargets.All)]
public class ExampleAttribute : Attribute
{
    // Data for properties.
    private ExampleKind kindValue;
    private string noteValue;
    private string[] arrayStrings;
    private int[] arrayNumbers;

    // Constructors. The parameterless constructor (.ctor) calls
    // the constructor that specifies ExampleKind and an array of
    // strings, and supplies the default values.
    //
    public ExampleAttribute(ExampleKind initKind, string[] initStrings)
    {
        kindValue = initKind;
        arrayStrings = initStrings;
    }
    public ExampleAttribute(ExampleKind initKind) : this(initKind, null) {}
    public ExampleAttribute() : this(ExampleKind.FirstKind, null) {}

    // Properties. The Note and Numbers properties must be read/write, so they
    // can be used as named parameters.
    //
    public ExampleKind Kind { get { return kindValue; }}
    public string[] Strings { get { return arrayStrings; }}
    public string Note
    {
        get { return noteValue; }
        set { noteValue = value; }
    }
    public int[] Numbers
    {
        get { return arrayNumbers; }
        set { arrayNumbers = value; }
    }
}

// The example attribute is applied to the test class.
//
[Example(ExampleKind.SecondKind,
         new string[] { "String array argument, line 1",
                        "String array argument, line 2",
                        "String array argument, line 3" },
         Note="This is a note on the class.",
         Numbers = new int[] { 53, 57, 59 })]
public class Test
{
    // The example attribute is applied to a method, using the
    // parameterless constructor and supplying a named argument.
    // The attribute is also applied to the method parameter.
    //
    [Example(Note="This is a note on a method.")]
    public void TestMethod([Example] object arg) { }

    // Main() gets objects representing the assembly, the test
    // type, the test method, and the method parameter. Custom
    // attribute data is displayed for each of these.
    //
    public static void Main()
    {
        Assembly asm = Assembly.ReflectionOnlyLoad("Source");
        Type t = asm.GetType("Test");
        MethodInfo m = t.GetMethod("TestMethod");
        ParameterInfo[] p = m.GetParameters();

        Console.WriteLine($"\r\nAttributes for assembly: '{asm}'");
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(asm));
        Console.WriteLine($"\r\nAttributes for type: '{t}'");
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(t));
        Console.WriteLine($"\r\nAttributes for member: '{m}'");
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(m));
        Console.WriteLine($"\r\nAttributes for parameter: '{p}'");
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(p[0]));
    }

    private static void ShowAttributeData(
        IList<CustomAttributeData> attributes)
    {
        foreach( CustomAttributeData cad in attributes )
        {
            Console.WriteLine($"   {cad}");
            Console.WriteLine($"      Constructor: '{cad.Constructor}'");

            Console.WriteLine("      Constructor arguments:");
            foreach( CustomAttributeTypedArgument cata
                in cad.ConstructorArguments )
            {
                ShowValueOrArray(cata);
            }

            Console.WriteLine("      Named arguments:");
            foreach( CustomAttributeNamedArgument cana
                in cad.NamedArguments )
            {
                Console.WriteLine($"         MemberInfo: '{cana.MemberInfo}'");
                ShowValueOrArray(cana.TypedValue);
            }
        }
    }

    private static void ShowValueOrArray(CustomAttributeTypedArgument cata)
    {
        if (cata.Value.GetType() == typeof(ReadOnlyCollection<CustomAttributeTypedArgument>))
        {
            Console.WriteLine($"         Array of '{cata.ArgumentType}':");

            foreach (CustomAttributeTypedArgument cataElement in
                (ReadOnlyCollection<CustomAttributeTypedArgument>) cata.Value)
            {
                Console.WriteLine($"             Type: '{cataElement.ArgumentType}'  Value: '{cataElement.Value}'");
            }
        }
        else
        {
            Console.WriteLine($"         Type: '{cata.ArgumentType}'  Value: '{cata.Value}'");
        }
    }
}

/* This code example produces output similar to the following:

Attributes for assembly: 'source, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
   [System.Runtime.CompilerServices.CompilationRelaxationsAttribute((Int32)8)]
      Constructor: 'Void .ctor(Int32)'
      Constructor arguments:
         Type: 'System.Int32'  Value: '8'
      Named arguments:
   [System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows = True)]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
         MemberInfo: 'Boolean WrapNonExceptionThrows'
         Type: 'System.Boolean'  Value: 'True'
   [ExampleAttribute((ExampleKind)2, Note = "This is a note on the assembly.")]
      Constructor: 'Void .ctor(ExampleKind)'
      Constructor arguments:
         Type: 'ExampleKind'  Value: '2'
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on the assembly.'

Attributes for type: 'Test'
   [ExampleAttribute((ExampleKind)1, new String[3] { "String array argument, line 1", "String array argument, line 2", "String array argument, line 3" }, Note = "This is a note on the class.", Numbers = new Int32[3] { 53, 57, 59 })]
      Constructor: 'Void .ctor(ExampleKind, System.String[])'
      Constructor arguments:
         Type: 'ExampleKind'  Value: '1'
         Array of 'System.String[]':
             Type: 'System.String'  Value: 'String array argument, line 1'
             Type: 'System.String'  Value: 'String array argument, line 2'
             Type: 'System.String'  Value: 'String array argument, line 3'
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on the class.'
         MemberInfo: 'Int32[] Numbers'
         Array of 'System.Int32[]':
             Type: 'System.Int32'  Value: '53'
             Type: 'System.Int32'  Value: '57'
             Type: 'System.Int32'  Value: '59'

Attributes for member: 'Void TestMethod(System.Object)'
   [ExampleAttribute(Note = "This is a note on a method.")]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on a method.'

Attributes for parameter: 'System.Object arg'
   [ExampleAttribute()]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
*/
//</Snippet1>
