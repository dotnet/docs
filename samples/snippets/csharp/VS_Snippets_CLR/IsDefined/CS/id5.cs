//<Snippet5>
using System;
using System.Reflection;

namespace IsDef5CS 
{
    public class TestClass 
    {
        // Assign a ParamArray attribute to the parameter using the keyword.
        public void Method1(params String[] args)
        {}
    }

    public class DemoClass 
    {
        static void Main(string[] args) 
        {
            // Get the class type to access its metadata.
            Type clsType = typeof(TestClass);
            // Get the MethodInfo object for Method1.
            MethodInfo mInfo = clsType.GetMethod("Method1");
            // Get the ParameterInfo array for the method parameters.
            ParameterInfo[] pInfo = mInfo.GetParameters();
            if (pInfo != null) 
            {
                // See if the ParamArray attribute is defined.
                bool isDef = Attribute.IsDefined(pInfo[0], 
                                                 typeof(ParamArrayAttribute));
                // Display the result.
                Console.WriteLine("The ParamArray attribute {0} defined for " +
                                  "parameter {1} of method {2}.",
                                  isDef ? "is" : "is not",
                                  pInfo[0].Name, 
                                  mInfo.Name);
            }
            else
                Console.WriteLine("The parameters information could " +
                            "not be retrieved for method {0}.", mInfo.Name);
        }
    }
}

/*
 * Output:
 * The ParamArray attribute is defined for parameter args of method Method1.
 */
//</Snippet5>
