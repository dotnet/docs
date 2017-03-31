//<Snippet1>
// Example for the Attribute.GetCustomAttribute( ParameterInfo, Type ) method.
using System;
using System.Reflection;

namespace NDP_UE_CS 
{
//<Snippet2> 
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

        // This is the Message property for the attribute.
        public string Message
        {
            get { return usageMsg; }
            set { usageMsg = value; }
        }
    }
//</Snippet2>

    public class BaseClass 
    {
        // Assign an ArgumentUsage attribute to the strArray parameter.
        // Assign a ParamArray attribute to strList using the params keyword.
        public virtual void TestMethod(
            [ArgumentUsage("Must pass an array here.")]
            String[] strArray,
            params String[] strList)
        { }
    }

    public class DerivedClass : BaseClass
    {
        // Assign an ArgumentUsage attribute to the strList parameter.
        // Assign a ParamArray attribute to strList using the params keyword.
        public override void TestMethod(
            String[] strArray,
            [ArgumentUsage("Can pass a parameter list or array here.")]
            params String[] strList)
        { }
    }

    class CustomParamDemo 
    {
        static void Main( ) 
        {
            Console.WriteLine( 
                "This example of Attribute.GetCustomAttribute( Param" +
                "eterInfo, Type )\ngenerates the following output." );

            // Get the class type, and then get the MethodInfo object 
            // for TestMethod to access its metadata.
            Type clsType = typeof( DerivedClass );
            MethodInfo mInfo = clsType.GetMethod("TestMethod");

            // Iterate through the ParameterInfo array for the method parameters.
            ParameterInfo[] pInfoArray = mInfo.GetParameters();
            if (pInfoArray != null) 
            {
                foreach( ParameterInfo paramInfo in pInfoArray )
                {
                    // See if the ParamArray attribute is defined.
                    bool isDef = Attribute.IsDefined( 
                        paramInfo, typeof(ParamArrayAttribute));

                    if( isDef )
                        Console.WriteLine( 
                            "\nThe ParamArray attribute is defined " +
                            "for \nparameter {0} of method {1}.",
                            paramInfo.Name, mInfo.Name);

                    // See if ParamUsageAttribute is defined.  
                    // If so, display a message.
                    ArgumentUsageAttribute usageAttr = (ArgumentUsageAttribute)
                        Attribute.GetCustomAttribute( 
                            paramInfo, typeof(ArgumentUsageAttribute) );

                    if( usageAttr != null )
                    {
                        Console.WriteLine( 
                            "\nThe ArgumentUsage attribute is defined " +
                            "for \nparameter {0} of method {1}.",
                            paramInfo.Name, mInfo.Name );

                        Console.WriteLine( "\n    The usage " +
                            "message for {0} is:\n    \"{1}\".",
                            paramInfo.Name, usageAttr.Message);
                    }
                }
            }
            else
                Console.WriteLine( 
                    "The parameters information could not " +
                    "be retrieved for method {0}.", mInfo.Name);
        }
    }
}

/*
This example of Attribute.GetCustomAttribute( ParameterInfo, Type )
generates the following output.

The ArgumentUsage attribute is defined for
parameter strArray of method TestMethod.

    The usage message for strArray is:
    "Must pass an array here.".

The ParamArray attribute is defined for
parameter strList of method TestMethod.

The ArgumentUsage attribute is defined for
parameter strList of method TestMethod.

    The usage message for strList is:
    "Can pass a parameter list or array here.".
*/
//</Snippet1>
