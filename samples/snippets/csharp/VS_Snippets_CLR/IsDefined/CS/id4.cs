//<Snippet4>
using System;
using System.Reflection;

namespace IsDef4CS 
{
    public class TestClass 
    {
        // Assign the Obsolete attribute to a method.
        [Obsolete("This method is obsolete. Use Method2 instead.")]
        public void Method1()
        {}
        public void Method2()
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
            // See if the Obsolete attribute is defined for this method.
            bool isDef = Attribute.IsDefined(mInfo, typeof(ObsoleteAttribute));
            // Display the result.
            Console.WriteLine("The Obsolete Attribute {0} defined for {1} of class {2}.",
                isDef ? "is" : "is not", mInfo.Name, clsType.Name);
            // If it's defined, display the attribute's message.
            if (isDef) 
            {
                ObsoleteAttribute obsAttr = 
                                 (ObsoleteAttribute)Attribute.GetCustomAttribute( 
                                                    mInfo, typeof(ObsoleteAttribute));
                if (obsAttr != null)
                    Console.WriteLine("The message is: \"{0}\".",
                        obsAttr.Message);
                else
                    Console.WriteLine("The message could not be retrieved.");
            }
        }
    }
}

/*
 * Output:
 * The Obsolete Attribute is defined for Method1 of class TestClass.
 * The message is: "This method is obsolete. Use Method2 instead.".
 */
//</Snippet4>
