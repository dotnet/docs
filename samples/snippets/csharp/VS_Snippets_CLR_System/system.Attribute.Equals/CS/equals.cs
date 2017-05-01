//<Snippet1>
// Example for the Attribute.Equals( object ) method.
using System;
using System.Reflection;

namespace NDP_UE_CS 
{
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
            return base.ToString( ) + ":" + usageMsg;
        }
    }

    // Define a custom parameter attribute that generates 
    // a GUID for each instance.
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
            return base.ToString( ) + "." + instanceGUID.ToString( );
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
        static void Main( ) 
        {
            Console.WriteLine( "This example of Attribute.Equals( object ) " +
                "generates the following output." );

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
                Console.WriteLine( "\nCompare a usage attribute instance to " +
                    "another instance of the same attribute:" );
                Console.WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}",
                    arrayUsageAttr1.ToString(), arrayUsageAttr2.ToString(), 
                    arrayUsageAttr1.Equals( arrayUsageAttr2 ) );

                Console.WriteLine( "\nCompare a usage attribute to " +
                    "another usage attribute:" );
                Console.WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}",
                    arrayUsageAttr1.ToString(), listUsageAttr.ToString(), 
                    arrayUsageAttr1.Equals( listUsageAttr ) );

                Console.WriteLine( "\nCompare an ID attribute instance to " +
                    "another instance of the same attribute:" );
                Console.WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}",
                    arrayIDAttr1.ToString(), arrayIDAttr2.ToString(), 
                    arrayIDAttr1.Equals( arrayIDAttr2 ) );

                Console.WriteLine( "\nCompare an ID attribute to another ID attribute:" );
                Console.WriteLine( "   \"{0}\" == \n   \"{1}\" ? {2}",
                    arrayIDAttr1.ToString(), listIDAttr.ToString(), 
                    arrayIDAttr1.Equals( listIDAttr ) );
            }
            else
                Console.WriteLine( "The parameters information could " +
                    "not be retrieved for method {0}.", mInfo.Name);
        }
    }
}

/*
This example of Attribute.Equals( object ) generates the following output.

Compare a usage attribute instance to another instance of the same attribute:
   "NDP_UE_CS.ArgumentUsageAttribute:Must pass an array here." ==
   "NDP_UE_CS.ArgumentUsageAttribute:Must pass an array here." ? True

Compare a usage attribute to another usage attribute:
   "NDP_UE_CS.ArgumentUsageAttribute:Must pass an array here." ==
   "NDP_UE_CS.ArgumentUsageAttribute:Can pass param list or array here." ? False

Compare an ID attribute instance to another instance of the same attribute:
   "NDP_UE_CS.ArgumentIDAttribute.06abf046-0c38-47ac-b215-09e1daa7f37d" ==
   "NDP_UE_CS.ArgumentIDAttribute.cea23c39-f14b-4e95-bee2-9f661d8cd64b" ? False

Compare an ID attribute to another ID attribute:
   "NDP_UE_CS.ArgumentIDAttribute.06abf046-0c38-47ac-b215-09e1daa7f37d" ==
   "NDP_UE_CS.ArgumentIDAttribute.bdeb6f3e-18aa-410b-bef6-9788956b008c" ? False
*/
//</Snippet1>
