using System;
using System.Reflection;

// Define a custom parameter attribute that takes a single message argument.
[AttributeUsage( AttributeTargets.Parameter )]
public class ArgumentUsageAttribute : Attribute
{
    // This is the attribute constructor.
    public ArgumentUsageAttribute( string UsageMsg )
    {
        this.usageMsg = UsageMsg;
    }

    // usageMsg is storage for the attribute message.
    protected string usageMsg;

    // Override ToString() to append the message to what the base generates.
    public override string ToString( )
    {
        return $"{base.ToString()}: {usageMsg}";
    }
}

// Define a custom parameter attribute that generates a GUID for each instance.
[AttributeUsage( AttributeTargets.Parameter )]
public class ArgumentIDAttribute : Attribute
{
    // This is the attribute constructor, which generates the GUID.
    public ArgumentIDAttribute( )
    {
        this.instanceGUID = Guid.NewGuid( );
    }

    // instanceGUID is storage for the generated GUID.
    protected Guid instanceGUID;

    // Override ToString() to append the GUID to what the base generates.
    public override string ToString( )
    {
        return $"{base.ToString()}.{instanceGUID.ToString()}";
    }
}

public class TestClass 
{
    // Assign an ArgumentID attribute to each parameter.
    // Assign an ArgumentUsage attribute to each parameter.
    public void TestMethod(
        [ArgumentID]
        [ArgumentUsage("Must pass an array here.")]
        String[] strArray,
        [ArgumentID]
        [ArgumentUsage("Can pass param list or array here.")]
        params String[] strList)
    { }
}

class AttributeEqualsDemo 
{
    // Create Attribute objects and compare them.
    static void Main() 
    {
        // Get the class type, and then get the MethodInfo object 
        // for TestMethod to access its metadata.
        Type clsType = typeof( TestClass );
        MethodInfo mInfo = clsType.GetMethod("TestMethod");

        // There will be two elements in pInfoArray, one for each parameter.
        ParameterInfo[] pInfoArray = mInfo.GetParameters();
        if (pInfoArray != null) 
        {
            // Create an instance of the argument usage attribute on strArray.
            ArgumentUsageAttribute arrayUsageAttr1 = (ArgumentUsageAttribute)
                Attribute.GetCustomAttribute( pInfoArray[0], 
                    typeof(ArgumentUsageAttribute) );

            // Create another instance of the argument usage attribute 
            // on strArray.
            ArgumentUsageAttribute arrayUsageAttr2 = (ArgumentUsageAttribute)
                Attribute.GetCustomAttribute( pInfoArray[0], 
                    typeof(ArgumentUsageAttribute) );

            // Create an instance of the argument usage attribute on strList.
            ArgumentUsageAttribute listUsageAttr = (ArgumentUsageAttribute)
                Attribute.GetCustomAttribute( pInfoArray[1], 
                    typeof(ArgumentUsageAttribute) );

            // Create an instance of the argument ID attribute on strArray.
            ArgumentIDAttribute arrayIDAttr1 = (ArgumentIDAttribute)
                Attribute.GetCustomAttribute( pInfoArray[0], 
                    typeof(ArgumentIDAttribute) );

            // Create another instance of the argument ID attribute on strArray.
            ArgumentIDAttribute arrayIDAttr2 = (ArgumentIDAttribute)
                Attribute.GetCustomAttribute( pInfoArray[0], 
                    typeof(ArgumentIDAttribute) );

            // Create an instance of the argument ID attribute on strList.
            ArgumentIDAttribute listIDAttr = (ArgumentIDAttribute)
                Attribute.GetCustomAttribute( pInfoArray[1], 
                    typeof(ArgumentIDAttribute) );

            // Compare various pairs of attributes for equality.
            Console.WriteLine("\nCompare a usage attribute instance to " +
                "another instance of the same attribute:" );
            Console.WriteLine($"   \"{arrayUsageAttr1}\" == \n" + 
                    $"   \"{arrayUsageAttr2}\"? {arrayUsageAttr1.Equals( arrayUsageAttr2)}");

            Console.WriteLine("\nCompare a usage attribute to " +
                "another usage attribute:" );
            Console.WriteLine($"   \"{arrayUsageAttr1}\" == \n" + 
                    $"   \"{listUsageAttr}\"? {arrayUsageAttr1.Equals(listUsageAttr)}");

            Console.WriteLine("\nCompare an ID attribute instance to " +
                "another instance of the same attribute:" );
            Console.WriteLine($"   \"{ arrayIDAttr1}\" == \n" + 
                    $"   \"{arrayIDAttr2}\"? {arrayIDAttr1.Equals(arrayIDAttr2)}");

            Console.WriteLine("\nCompare an ID attribute to another ID attribute:" );
            Console.WriteLine($"   \"{arrayIDAttr1}\" == \n" + 
                    $"   \"{listIDAttr}\"? {arrayIDAttr1.Equals(listIDAttr)}");
        }
        else
            Console.WriteLine( "The parameters information could " +
                "not be retrieved for method {0}.", mInfo.Name);
    }
    }
/*
The example displays the following output.
//         Compare a usage attribute instance to another instance of the same attribute:
//            "ArgumentUsageAttribute: Must pass an array here." ==
//            "ArgumentUsageAttribute: Must pass an array here."? True
//         
//         Compare a usage attribute to another usage attribute:
//            "ArgumentUsageAttribute: Must pass an array here." ==
//            "ArgumentUsageAttribute: Can pass param list or array here."? False
//         
//         Compare an ID attribute instance to another instance of the same attribute:
//            "ArgumentIDAttribute.22d1a176-4aca-427b-8230-0c1563e13187" ==
//            "ArgumentIDAttribute.7fa94bba-c290-48e1-a0de-e22f6c1e64f1"? False
//         
//         Compare an ID attribute to another ID attribute:
//            "ArgumentIDAttribute.22d1a176-4aca-427b-8230-0c1563e13187" ==
//            "ArgumentIDAttribute.b9eea70d-9c0f-459e-a984-19c46b6c8789"? False
*/
