// <Snippet5>
using System;
using System.Reflection;
using System.ComponentModel;

namespace CustAttrs5CS {
    public class AClass {
        public void ParamArrayAndDesc(
            // Add ParamArray (with the keyword) and Description attributes.
            [Description("This argument is a ParamArray")]
            params int[] args)
        {}
    }

    class DemoClass {
        static void Main(string[] args) {
            // Get the Class type to access its metadata.
            Type clsType = typeof(AClass);
            // Get the type information for the method.
            MethodInfo mInfo = clsType.GetMethod("ParamArrayAndDesc");
            if (mInfo != null) {
                // Get the parameter information.
                ParameterInfo[] pInfo = mInfo.GetParameters();
                if (pInfo != null) {
                    // Iterate through all the attributes for the parameter.
                    foreach(Attribute attr in 
                        Attribute.GetCustomAttributes(pInfo[0])) {
                        // Check for the ParamArray attribute.
                        if (attr.GetType() == typeof(ParamArrayAttribute))
                            Console.WriteLine("Parameter {0} for method {1} " +
                                "has the ParamArray attribute.",
                                pInfo[0].Name, mInfo.Name);
                        // Check for the Description attribute.
                        else if (attr.GetType() == 
                            typeof(DescriptionAttribute)) {
                            Console.WriteLine("Parameter {0} for method {1} " +
                                "has a description attribute.",
                                pInfo[0].Name, mInfo.Name);
                            Console.WriteLine("The description is: \"{0}\"",
                                ((DescriptionAttribute)attr).Description);
                        }
                    }
                }
            }
        }
    }
}

/*
 * Output:
 * Parameter args for method ParamArrayAndDesc has a description attribute.
 * The description is: "This argument is a ParamArray"
 * Parameter args for method ParamArrayAndDesc has the ParamArray attribute.
 */
// </Snippet5>