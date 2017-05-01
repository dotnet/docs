//<Snippet1>
// Example for the Attribute.TypeId property.
using System;
using System.Reflection;

namespace NDP_UE_CS 
{
    // Define a custom parameter attribute that takes a single message argument.
    [AttributeUsage( AttributeTargets.Parameter )]
    public class ArgumentUsageAttribute : Attribute
    {
        // The constructor saves the message and creates a unique identifier.
        public ArgumentUsageAttribute( string UsageMsg )
        {
            this.usageMsg = UsageMsg;
            this.instanceGUID = Guid.NewGuid( );
        }

        // This is storage for the attribute message and unique ID.
        protected string usageMsg;
        protected Guid instanceGUID;

        // This is the Message property for the attribute.
        public string Message
        {
            get { return usageMsg; }
            set { usageMsg = value; }
        }

        // Override TypeId to provide a unique identifier for the instance.
        public override object TypeId
        {
            get { return (object)instanceGUID; }
        }

        // Override ToString() to append the message to what the base generates.
        public override string ToString( )
        {
            return base.ToString( ) + ":" + usageMsg;
        }
    }

    public class TestClass 
    {
        // Assign an ArgumentUsage attribute to each parameter.
        // Assign a ParamArray attribute to strList using the params keyword.
        public void TestMethod(
            [ArgumentUsage("Must pass an array here.")]
            String[] strArray,
            [ArgumentUsage("Can pass a param list or array here.")]
            params String[] strList)
        { }
    }

    class AttributeTypeIdDemo 
    {
        static void ShowAttributeTypeIds( ) 
        {
            // Get the class type, and then get the MethodInfo object 
            // for TestMethod to access its metadata.
            Type clsType = typeof( TestClass );
            MethodInfo mInfo = clsType.GetMethod("TestMethod");

            // There will be two elements in pInfoArray, one for each parameter.
            ParameterInfo[] pInfoArray = mInfo.GetParameters();
            if (pInfoArray != null) 
            {
                // Create an instance of the param array attribute on strList.
                ParamArrayAttribute listArrayAttr = (ParamArrayAttribute)
                    Attribute.GetCustomAttribute( pInfoArray[1], 
                        typeof(ParamArrayAttribute) );

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

                // Display the attributes and corresponding TypeId values.
                Console.WriteLine( "\n\"{0}\" \nTypeId: {1}",
                    listArrayAttr.ToString(), listArrayAttr.TypeId );
                Console.WriteLine( "\n\"{0}\" \nTypeId: {1}",
                    arrayUsageAttr1.ToString(), arrayUsageAttr1.TypeId );
                Console.WriteLine( "\n\"{0}\" \nTypeId: {1}",
                    arrayUsageAttr2.ToString(), arrayUsageAttr2.TypeId );
                Console.WriteLine( "\n\"{0}\" \nTypeId: {1}",
                    listUsageAttr.ToString(), listUsageAttr.TypeId );
            }
            else
                Console.WriteLine( "The parameters information could " +
                    "not be retrieved for method {0}.", mInfo.Name );
        }

        static void Main( ) 
        {
            Console.WriteLine( 
                "This example of the Attribute.TypeId property\n" +
                "generates the following output." );
            Console.WriteLine( 
                "\nCreate instances from a derived Attribute " +
                "class that implements TypeId, \nand then " +
                "display the attributes and corresponding TypeId values:" );

            ShowAttributeTypeIds( );
        }
    }
}

/*
This example of the Attribute.TypeId property
generates the following output.

Create instances from a derived Attribute class that implements TypeId,
and then display the attributes and corresponding TypeId values:

"System.ParamArrayAttribute"
TypeId: System.ParamArrayAttribute

"NDP_UE_CS.ArgumentUsageAttribute:Must pass an array here."
TypeId: d03a23f4-2536-4478-920f-8b0426dec7f1

"NDP_UE_CS.ArgumentUsageAttribute:Must pass an array here."
TypeId: a1b412e8-3047-49fa-8d03-7660d37ef718

"NDP_UE_CS.ArgumentUsageAttribute:Can pass a param list or array here."
TypeId: 7ac2bf61-0327-48d6-a07e-eb9aaf3dd45e
*/
//</Snippet1>
